using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNM2
{
    public partial class fKhachHang : UserControl
    {
        public fKhachHang()
        {
            InitializeComponent();
        }

        private void chkboMa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboMa.Checked)
            {
                tkMa.Enabled = true;
            }
            else
            {
                tkMa.Text = "";
                tkMa.Enabled = false;
            }
        }

        private void chkboEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboEmail.Checked)
            {
                tkEmail.Enabled = true;
            }
            else
            {
                tkEmail.Text = "";
                tkEmail.Enabled = false;
            }
        }

        private void chkboTen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboTen.Checked)
            {
                tkTen.Enabled = true;
            }
            else
            {
                tkTen.Text = "";
                tkTen.Enabled = false;
            }
        }

        private void chkboSDT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboSDT.Checked)
            {
                tkSDT.Enabled = true;
            }
            else
            {
                tkSDT.Text = "";
                tkSDT.Enabled = false;
            }
        }

        private void chkboDiaChi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboDiaChi.Checked)
            {
                tkDiaChi.Enabled = true;
            }
            else
            {
                tkDiaChi.Text = "";
                tkDiaChi.Enabled = false;
            }
        }

        private void dateTao_CheckedChanged(object sender, EventArgs e)
        {
            if (dateTao.Checked)
            {
                tkDateTao.Enabled = true;
            }
            else
            {
                tkDateTao.Enabled = false;
            }
        }

        private void dateCapNhat_CheckedChanged(object sender, EventArgs e)
        {
            if (dateCapNhat.Checked)
            {
                tkDateCapNhat.Enabled = true;
            }
            else
            {
                tkDateCapNhat.Enabled = false;
            }
        }
        private void dgvKhachHang_Load()
        {
            dgvKhachHang.DataSource = Data.GetData("select * from khachhang");
            dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns[1].HeaderText = "Email";
            dgvKhachHang.Columns[2].HeaderText = "Tên";
            dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
            dgvKhachHang.Columns[4].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[5].HeaderText = "Ngày tạo";
            dgvKhachHang.Columns[6].HeaderText = "Ngày cập nhật";
            dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 150;
            dgvKhachHang.Columns[2].Width = 150;
            dgvKhachHang.Columns[3].Width = 100;
            dgvKhachHang.Columns[4].Width = 150;
            dgvKhachHang.Columns[5].Width = 110;
            dgvKhachHang.Columns[6].Width = 110;
        }
        private void emptyText()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtEmail.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtNgayTao.Text = "";
            txtCapNhat.Text = "";
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang_Load();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            emptyText();
            dgvKhachHang_Load();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhachHang.Rows.Count == 0) return;
            int i = dgvKhachHang.SelectedCells[0].RowIndex;
            txtMaKH.Text = dgvKhachHang.Rows[i].Cells[0].Value.ToString();
            txtEmail.Text = dgvKhachHang.Rows[i].Cells[1].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[i].Cells[2].Value.ToString();
            txtDienThoai.Text = dgvKhachHang.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[i].Cells[4].Value.ToString();
            txtNgayTao.Text = dgvKhachHang.Rows[i].Cells[5].Value.ToString();
            txtCapNhat.Text = dgvKhachHang.Rows[i].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Chưa có tên khách hàng");
                txtTenKH.Focus();
                return;
            }
            String query = "insert into khachhang values (@email, @ten, @sdt, @diachi, @ngaytao, @ngaycapnhat)";
            SqlParameter[] args =
            {
                new SqlParameter("@email", txtEmail.Text),
                new SqlParameter("@ten", txtTenKH.Text),
                new SqlParameter("@sdt", txtDienThoai.Text),
                new SqlParameter("@diachi", txtDiaChi.Text),
                new SqlParameter("@ngaytao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvKhachHang_Load();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Chưa chọn khách hàng cần sửa");
                return;
            }
            if (String.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Chưa có tên khách hàng");
                txtTenKH.Focus();
                return;
            }
            String query = "update khachhang " +
                "set email = @email," +
                "ten = @ten," +
                "sodienthoai = @sdt," +
                "diachi = @diachi," +
                "ngaycapnhat = @ngaycapnhat " +
                "where id_khachhang = @id";
            SqlParameter[] args =
            {
                new SqlParameter("@email", txtEmail.Text),
                new SqlParameter("@ten", txtTenKH.Text),
                new SqlParameter("@sdt", txtDienThoai.Text),
                new SqlParameter("@diachi", txtDiaChi.Text),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@id",txtMaKH.Text)
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvKhachHang_Load();
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
