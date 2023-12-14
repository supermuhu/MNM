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
using System.Xml.Linq;

namespace MNM2
{
    public partial class fLoaiSP : UserControl
    {
        public fLoaiSP()
        {
            InitializeComponent();
        }
        private void emptyText()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtNgayTao.Text = "";
            txtCapNhat.Text = "";
            txtMaLoai.ReadOnly = false;
        }
        private void cboNhomLK_Load()
        {
            cboNhomLK.DataSource = null;
            cboNhomLK.ValueMember = "id_nhom";
            cboNhomLK.DisplayMember = "tennhom";
            cboNhomLK.DataSource = Data.GetData("select * from nhomsanpham");
        }
        private void dgvLoaiSP_Load()
        {
            dgvLoaiSP.DataSource = null;
            if (cboNhomLK.SelectedValue == null) return;
            dgvLoaiSP.DataSource = Data.GetData("select * from loaisanpham where id_nhom = @id",
                new SqlParameter("@id", cboNhomLK.SelectedValue));
            dgvLoaiSP.Columns[0].HeaderText = "Mã loại";
            dgvLoaiSP.Columns[1].HeaderText = "Mã nhóm";
            dgvLoaiSP.Columns[2].HeaderText = "Tên loại";
            dgvLoaiSP.Columns[3].HeaderText = "Ngày tạo";
            dgvLoaiSP.Columns[4].HeaderText = "Ngày cập nhật";
            dgvLoaiSP.Columns[0].Width = 85;
            dgvLoaiSP.Columns[1].Width = 85;
            dgvLoaiSP.Columns[2].Width = 151;
            dgvLoaiSP.Columns[3].Width = 110;
            dgvLoaiSP.Columns[4].Width = 110;
        }
        private void fLoaiSP_Load(object sender, EventArgs e)
        {
            cboNhomLK_Load();
        }

        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvLoaiSP.Rows.Count == 0) return;
            int index = dgvLoaiSP.SelectedCells[0].RowIndex;
            txtMaLoai.Text = dgvLoaiSP.Rows[index].Cells[0].Value.ToString();
            txtTenLoai.Text = dgvLoaiSP.Rows[index].Cells[2].Value.ToString();
            txtNgayTao.Text = dgvLoaiSP.Rows[index].Cells[3].Value.ToString();
            txtCapNhat.Text = dgvLoaiSP.Rows[index].Cells[4].Value.ToString();
            txtMaLoai.ReadOnly = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboNhomLK.SelectedIndex = 0;
            emptyText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Chưa có mã loại linh kiện");
                txtMaLoai.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Chưa có tên nhóm linh kiện");
                txtTenLoai.Focus();
                return;
            }
            if (txtMaLoai.Text.Trim() == Data.Scalar("select * from loaisanpham where id_loai = @id",
                new SqlParameter("@id", txtMaLoai.Text.Trim())))
            {
                MessageBox.Show("Trùng mã loại linh kiện");
                txtMaLoai.Focus();
                return;
            }
            String query = "insert into loaisanpham values (@id, @nhom, @ten, @ngaytao, @ngaycapnhat)";
            SqlParameter[] args =
            {
                new SqlParameter("@id", txtMaLoai.Text.Trim()),
                new SqlParameter("@nhom", cboNhomLK.SelectedValue),
                new SqlParameter("@ten", txtTenLoai.Text.Trim()),
                new SqlParameter("@ngaytao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvLoaiSP_Load();
            }
        }

        private void cboNhomLK_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtNgayTao.Text = "";
            txtCapNhat.Text = "";
            txtMaLoai.ReadOnly = false;
            dgvLoaiSP_Load();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtMaLoai.ReadOnly == false)
            {
                MessageBox.Show("Chưa chọn loại linh kiện nào để sửa");
                return;
            }
            if (String.IsNullOrEmpty(txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Chưa có tên nhóm linh kiện");
                txtTenLoai.Focus();
                return;
            }
            String query = "update loaisanpham " +
                "set id_nhom = @nhom," +
                "tenloai = @ten," +
                "ngaycapnhat = @ngaycapnhat " +
                "where id_loai = @id";
            SqlParameter[] args =
            {
                new SqlParameter("@id", txtMaLoai.Text.Trim()),
                new SqlParameter("@nhom", cboNhomLK.SelectedValue),
                new SqlParameter("@ten", txtTenLoai.Text.Trim()),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvLoaiSP_Load();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn chắc chắn muốn xoá loại linh kiện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.No)
            {
                return;
            }
            if (txtMaLoai.ReadOnly == false)
            {
                MessageBox.Show("Chưa chọn loại muốn xoá");
                return;
            }
            if (Data.Excute("delete chitietphieuxuat where id_sanpham in (select id_sanpham from sanpham where id_loai = @id)", new SqlParameter("@id", txtMaLoai.Text))
                && Data.Excute("delete chitietphieunhap where id_sanpham in (select id_sanpham from sanpham where id_loai = @id)", new SqlParameter("@id", txtMaLoai.Text))
                && Data.Excute("delete from sanpham where id_loai = @id", new SqlParameter("@id", txtMaLoai.Text))
                && Data.Excute("delete from loaisanpham where id_loai = @id", new SqlParameter("@id", txtMaLoai.Text)))
            {
                emptyText();
                dgvLoaiSP_Load();
            }
        }
    }
}
