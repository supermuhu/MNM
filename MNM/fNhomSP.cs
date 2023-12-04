using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace MNM2
{
    public partial class fNhomSP : UserControl
    {
        public fNhomSP()
        {
            InitializeComponent();
        }
        private void dgvNhomSP_Load()
        {
            dgvNhomSP.DataSource = Data.GetData("select * from nhomsanpham");
        }
        private void fNhomSP_Load(object sender, EventArgs e)
        {
            dgvNhomSP_Load();
        }

        private void dgvNhomSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhomSP.Rows.Count == 0) return;
            int index = dgvNhomSP.SelectedCells[0].RowIndex;
            txtID.Text = dgvNhomSP.Rows[index].Cells[0].Value.ToString();
            txtName.Text = dgvNhomSP.Rows[index].Cells[1].Value.ToString();
            txtNgayTao.Text = dgvNhomSP.Rows[index].Cells[2].Value.ToString();
            txtNgayCapNhat.Text = dgvNhomSP.Rows[index].Cells[3].Value.ToString();
            txtID.ReadOnly = true;
        }
        private void emptyText()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtNgayTao.Text = "";
            txtNgayCapNhat.Text = "";
            txtID.ReadOnly = false;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            emptyText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chưa có mã nhóm linh kiện");
                txtID.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa có tên nhóm linh kiện");
                txtName.Focus();
                return;
            }
            if (txtID.Text == Data.Scalar("select * from nhomsanpham where id_nhom = @id",
                new SqlParameter("@id", txtID.Text)))
            {
                MessageBox.Show("Trùng mã nhóm linh kiện");
                txtID.Focus();
                return;
            }
            String query = "insert into nhomsanpham values (@id, @ten, @ngaytao, @ngaycapnhat)";
            SqlParameter[] args =
            {
                new SqlParameter("@id", txtID.Text),
                new SqlParameter("@ten", txtName.Text),
                new SqlParameter("@ngaytao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvNhomSP_Load();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtID.ReadOnly == false)
            {
                MessageBox.Show("Chưa chọn nhóm để sửa");
                return;
            }
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa có tên nhóm linh kiện");
                txtName.Focus();
                return;
            }
            String query = "update nhomsanpham " +
                "set tennhom = @ten," +
                "ngaycapnhat = @ngaycapnhat " +
                "where id_nhom = @id";
            SqlParameter[] args =
            {
                new SqlParameter("@id", txtID.Text),
                new SqlParameter("@ten", txtName.Text),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvNhomSP_Load();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn chắc chắn muốn xoá nhóm linh kiện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.No)
            {
                return;
            }
            if (txtID.ReadOnly == false)
            {
                MessageBox.Show("Chưa chọn nhóm muốn xoá");
                return;
            }
            if (Data.Excute("delete chitietphieuxuat where id_sanpham in (select id_sanpham from sanpham where id_loai in (select id_loai from loaisanpham where id_nhom = @id))", new SqlParameter("@id", txtID.Text))
                && Data.Excute("delete chitietphieunhap where id_sanpham in (select id_sanpham from sanpham where id_loai in (select id_loai from loaisanpham where id_nhom = @id))", new SqlParameter("@id", txtID.Text))
                && Data.Excute("delete from sanpham where id_loai in (select id_loai from loaisanpham where id_nhom = @id)", new SqlParameter("@id", txtID.Text))
                && Data.Excute("delete from thuonghieu where id_nhom = @id", new SqlParameter("@id", txtID.Text))
                && Data.Excute("delete from loaisanpham where id_nhom = @id", new SqlParameter("@id", txtID.Text))
                && Data.Excute("delete from nhomsanpham where id_nhom = @id", new SqlParameter("@id", txtID.Text)))
            {
                emptyText();
                dgvNhomSP_Load();
            }
        }
    }
}
