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
    public partial class fThanhToan : UserControl
    {
        public fThanhToan()
        {
            InitializeComponent();
        }
        private void emptyText()
        {
            txtID.Text = "";
            txtName.Text = "";
        }
        private void dgvPhuongthuc_Load() 
        {
            dgvPhuongThuc.DataSource = Data.GetData("select * from phuongthucthanhtoan");
            dgvPhuongThuc.Columns[0].HeaderText = "Mã phương thức";
            dgvPhuongThuc.Columns[1].HeaderText = "Tên phương thức";
            dgvPhuongThuc.Columns[0].Width = 105;
            dgvPhuongThuc.Columns[1].Width = 170;

        }
        private void fThanhToan_Load(object sender, EventArgs e)
        {
            dgvPhuongthuc_Load();
        }

        private void dgvPhuongThuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhuongThuc.Rows.Count == 0) 
                return;
            int i = dgvPhuongThuc.SelectedCells[0].RowIndex;
            txtID.Text = dgvPhuongThuc.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dgvPhuongThuc.Rows[i].Cells[1].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            emptyText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Đang chọn 1 phương thức");
                return;
            }
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa có tên phương thức");
                txtName.Focus();
                return;
            }
            if (Data.Excute("insert into phuongthucthanhtoan values (@ten)", new SqlParameter("@ten", txtName.Text.Trim())))
            {
                emptyText();
                dgvPhuongthuc_Load();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Chưa có tên nhóm linh kiện");
                txtName.Focus();
                return;
            }
            if (Data.Excute("update phuongthucthanhtoan set tenthanhtoan = @ten where id_thanhtoan = @id",
                new SqlParameter("@id", txtID.Text),
                new SqlParameter("@ten", txtName.Text)))
            {
                emptyText();
                dgvPhuongthuc_Load();
            }
        }
    }
}
