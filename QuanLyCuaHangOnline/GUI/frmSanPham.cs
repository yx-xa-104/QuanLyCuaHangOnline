using BLL;
using DAL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmSanPham : Form
    {
        private SanPham_BLL sp_bll = new SanPham_BLL();
        private DanhMuc_BLL dm_bll = new DanhMuc_BLL();
        private bool isAdding = false;
        private string currentImagePath = string.Empty;

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDanhMuc();
            SetControlState(false); // Bắt đầu ở trạng thái chỉ xem
        }
        private void LoadData()
        {
            DataTable dt = sp_bll.GetAllSanPham();
            dgvSanPham.DataSource = dt;
        }

        // Thiết lập trạng thái của các controls
        private void SetControlState(bool isEditing)
        {
            txtMaSP.Enabled = isEditing; // Chỉ cho phép nhập mã khi thêm mới
            txtTenSP.Enabled = isEditing;
            cboMaDanhMuc.Enabled = isEditing;
            txtSoLuongTon.Enabled = isEditing;
            txtDonGia.Enabled = isEditing;
            btnMoFile.Enabled = isEditing;

            btnLuu.Enabled = isEditing;
            btnBoQua.Enabled = isEditing;

            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing;

            dgvSanPham.Enabled = !isEditing;
        }

        // Xóa trắng các ô nhập liệu
        private void ClearInputs()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            cboMaDanhMuc.SelectedIndex = -1;
            txtSoLuongTon.Clear();
            txtDonGia.Clear();
            picHinhAnh.Image = null;
            currentImagePath = string.Empty;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                cboMaDanhMuc.SelectedValue = row.Cells["MaDanhMuc"].Value.ToString();
                txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();

                // Lấy tên file ảnh từ CSDL
                string imageName = row.Cells["HinhAnh"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(imageName))
                {
                    // Ảnh được lưu trong thư mục Images của ứng dụng
                    string imagePath = Path.Combine(Application.StartupPath, "Images", imageName);
                    if (File.Exists(imagePath))
                    {
                        picHinhAnh.ImageLocation = imagePath;
                    }
                    else
                    {
                        picHinhAnh.Image = null;
                    }
                }
                else
                {
                    picHinhAnh.Image = null;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            SetControlState(true);
            ClearInputs();
            txtMaSP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                isAdding = false;
                SetControlState(true);
                txtTenSP.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maSP = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["MaSP"].Value);
                    if (sp_bll.XoaSanPham(maSP))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các giá trị đầu vào cơ bản
                if (cboMaDanhMuc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cho sản phẩm.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTenSP.Text) || string.IsNullOrWhiteSpace(txtMaSP.Text))
                {
                    MessageBox.Show("Mã sản phẩm và Tên sản phẩm không được để trống.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xử lý hình ảnh 
                string imageName = "";
                if (!string.IsNullOrEmpty(currentImagePath))
                {
                    string targetDirectory = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(targetDirectory)) Directory.CreateDirectory(targetDirectory);
                    imageName = Path.GetFileName(currentImagePath);
                    string destinationPath = Path.Combine(targetDirectory, imageName);
                    File.Copy(currentImagePath, destinationPath, true);
                }
                else if (dgvSanPham.SelectedRows.Count > 0 && !isAdding)
                {
                    imageName = dgvSanPham.SelectedRows[0].Cells["HinhAnh"].Value?.ToString() ?? "";
                }

                // Tạo đối tượng DTO và chuyển đổi kiểu dữ liệu
                SanPham_DTO sp = new SanPham_DTO
                {
                    MaSP = int.Parse(txtMaSP.Text.Trim()),
                    TenSP = txtTenSP.Text.Trim(),
                    MaDanhMuc = cboMaDanhMuc.SelectedValue.ToString(),
                    SoLuongTon = int.Parse(txtSoLuongTon.Text),
                    DonGia = decimal.Parse(txtDonGia.Text),
                    HinhAnh = imageName
                };

                // Gọi BLL để thực thi
                if (isAdding)
                {
                    if (sp_bll.ThemSanPham(sp))
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        SetControlState(false);
                    }
                }
                else // Chế độ Sửa
                {
                    if (sp_bll.SuaSanPham(sp))
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        SetControlState(false);
                    }
                }
            }
            catch (FormatException) // Bắt lỗi nếu người dùng nhập chữ vào ô số
            {
                MessageBox.Show("Vui lòng kiểm tra lại 'Mã sản phẩm', 'Số lượng tồn' và 'Đơn giá'.\nChúng phải là những con số hợp lệ.", "Lỗi Định Dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Hiển thị các lỗi khác từ CSDL
                MessageBox.Show("Đã xảy ra lỗi:\n\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                currentImagePath = string.Empty;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            // Hiển thị lại dữ liệu của dòng đang chọn
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                dgvSanPham_CellClick(dgvSanPham, new DataGridViewCellEventArgs(0, dgvSanPham.SelectedRows[0].Index));
            }
            else
            {
                ClearInputs();
            }
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.ImageLocation = open.FileName;
                currentImagePath = open.FileName; // Lưu đường dẫn đầy đủ của ảnh đã chọn
            }
        }
      
        private void LoadDanhMuc()
        {
            DataTable dt = dm_bll.GetAllDanhMuc();
            cboMaDanhMuc.DataSource = dt;
            cboMaDanhMuc.DisplayMember = "TenDanhMuc"; // Hiển thị Tên danh mục
            cboMaDanhMuc.ValueMember = "MaDanhMuc";   // Lấy giá trị là Mã danh mục
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            DataTable dt = sp_bll.GetAllSanPham();
            DataView dv = new DataView(dt);

            // Lọc dữ liệu trên cả MaSP và TenSP
            // Cần chuyển đổi MaSP sang string để so sánh
            dv.RowFilter = $"CONVERT(MaSP, 'System.String') LIKE '%{keyword}%' OR TenSP LIKE '%{keyword}%'";

            dgvSanPham.DataSource = dv;
        }

        private void cboMaDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}