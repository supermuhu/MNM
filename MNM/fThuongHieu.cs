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
using DevExpress.Utils.Behaviors;

namespace MNM2
{
    public partial class fThuongHieu : UserControl
    {
        public fThuongHieu()
        {
            InitializeComponent();
        }
        private void cboNhomLK_Load()
        {
            cboNhomLK.DataSource = null;
            cboNhomLK.ValueMember = "id_nhom";
            cboNhomLK.DisplayMember = "tennhom";
            cboNhomLK.DataSource = Data.GetData("select * from nhomsanpham");
        }
        private void dgvThuongHieu_Load()
        {
            if(cboNhomLK.Items.Count == 0)
            {
                dgvThuongHieu.DataSource = null;
                return;
            }
            dgvThuongHieu.DataSource = Data.GetData("select * from thuonghieu where id_nhom = @id",
                new SqlParameter("@id", cboNhomLK.SelectedValue));
        }
        private void cboNhomLK_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvThuongHieu_Load();
        }
        private void fThuongHieu_Load(object sender, EventArgs e)
        {
            cboNhomLK_Load();
        }
        private void emptyText()
        {
            txtMaTH.Text = "";
            txtTenThuongHieu.Text = "";
            txtNgayTao.Text = "";
            txtNgayCapNhat.Text = "";
        }
        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThuongHieu.SelectedCells[0].Value == null) return;
            int index = dgvThuongHieu.SelectedCells[0].RowIndex;
            txtMaTH.Text = dgvThuongHieu.Rows[index].Cells[0].Value.ToString();
            txtTenThuongHieu.Text = dgvThuongHieu.Rows[index].Cells[2].Value.ToString();
            txtNgayTao.Text = dgvThuongHieu.Rows[index].Cells[3].Value.ToString();
            txtNgayCapNhat.Text = dgvThuongHieu.Rows[index].Cells[4].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if(cboNhomLK.Items.Count != 0) cboNhomLK.SelectedIndex = 0;
            emptyText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(cboNhomLK.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhóm linh kiện");
                return;
            }
            if(txtTenThuongHieu.Text == "")
            {
                MessageBox.Show("Chưa có tên thương hiệu");
                txtTenThuongHieu.Focus();
                return;
            }
            String query = "insert into thuonghieu values (@id, @ten, @ngaytao, @ngaycapnhat)";
            SqlParameter[] args =
            {
                new SqlParameter("@id", cboNhomLK.SelectedValue),
                new SqlParameter("@ten", txtTenThuongHieu.Text),
                new SqlParameter("@ngaytao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvThuongHieu_Load();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboNhomLK.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhóm linh kiện");
                return;
            }
            if (txtTenThuongHieu.Text == "")
            {
                MessageBox.Show("Chưa có tên thương hiệu");
                txtTenThuongHieu.Focus();
                return;
            }
            String query = "update thuonghieu set " +
                "id_nhom = @id_nhom," +
                "tenthuonghieu = @ten," +
                "ngaycapnhat = @ngaycapnhat " +
                "where id_thuonghieu = @id";
            SqlParameter[] args =
            {
                new SqlParameter("@id_nhom", cboNhomLK.SelectedValue),
                new SqlParameter("@ten", txtTenThuongHieu.Text),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@id", txtMaTH.Text)
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvThuongHieu_Load();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
