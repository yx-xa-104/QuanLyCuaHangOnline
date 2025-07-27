using BLL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmKhachHang : Form
    {
        private KhachHang_BLL kh_bll = new KhachHang_BLL();
        private bool isAdding = false;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = kh_bll.GetAllKhachHang();
        }

        private void SetControlState(bool isEditing)
        {
            txtMaKH.Enabled = isAdding;
            txtTenKH.Enabled = isEditing;
            txtSoDienThoai.Enabled = isEditing;
            txtDiaChi.Enabled = isEditing;

            btnLuu.Enabled = isEditing;
            btnBoQua.Enabled = isEditing;

            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing;

            dgvKhachHang.Enabled = !isEditing;
        }

        private void ClearInputs()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            SetControlState(true);
            ClearInputs();
            txtMaKH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                isAdding = false;
                SetControlState(true);
                txtTenKH.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa.", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string maKH = dgvKhachHang.SelectedRows[0].Cells["MaKH"].Value.ToString();
                    if (kh_bll.XoaKhachHang(maKH))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadData();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.", "Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.", "Thông báo");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHang_DTO kh = new KhachHang_DTO
            {
                MaKH = txtMaKH.Text.Trim(),
                TenKH = txtTenKH.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            if (isAdding)
            {
                if (kh_bll.ThemKhachHang(kh))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    LoadData();
                    SetControlState(false);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại thông tin.", "Lỗi");
                }
            }
            else // Sửa
            {
                if (kh_bll.SuaKhachHang(kh))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    LoadData();
                    SetControlState(false);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                dgvKhachHang_CellClick(null, new DataGridViewCellEventArgs(0, dgvKhachHang.SelectedRows[0].Index));
            }
            else
            {
                ClearInputs();
            }
        }
    }
}