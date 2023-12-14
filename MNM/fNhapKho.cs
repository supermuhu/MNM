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
using System.Globalization;
using System.Diagnostics.Contracts;

namespace MNM2
{
    public partial class fNhapKho : UserControl
    {
        public fNhapKho()
        {
            InitializeComponent();
        }
        private void cboMaLK_Load()
        {
            cboMaLK.DataSource = null;
            if (cboPhieuNhap.SelectedValue == null && cboPhieuNhap.Text != "-1") return;
            cboMaLK.DisplayMember = "id_sanpham";
            cboMaLK.ValueMember = "id_sanpham";
            cboMaLK.DataSource = Data.GetData("select * from sanpham");
        }
        private void cboPhieuNhap_Load()
        {
            String querry;
            querry = "select * from phieunhap";
            cboPhieuNhap.DataSource = null;
            cboPhieuNhap.DisplayMember = "id_phieunhap";
            cboPhieuNhap.ValueMember = "id_phieunhap";
            DataTable dt = Data.GetData(querry);
            dt.Rows.Add("-1");
            cboPhieuNhap.DataSource = dt;
        }
        private void dgvPhieuNhap_Load()
        {
            dgvPhieuNhap.DataSource = null;
            if (cboPhieuNhap.SelectedValue == null) return;
            String query = "select s.id_sanpham, s.tensanpham , c.soluongsp, c.gianhap, c.thanhtien, p.ngaynhap\r\nfrom phieunhap p inner join chitietphieunhap c on p.id_phieunhap = c.id_phieunhap\r\ninner join sanpham s on c.id_sanpham = s.id_sanpham\r\nwhere p.id_phieunhap = @id";
            dgvPhieuNhap.DataSource = Data.GetData(query, new SqlParameter("@id",cboPhieuNhap.SelectedValue));
            dgvPhieuNhap.Columns[0].HeaderText = "Mã sản phẩm";
            dgvPhieuNhap.Columns[1].HeaderText = "Tên sản phẩm";
            dgvPhieuNhap.Columns[2].HeaderText = "Số lượng";
            dgvPhieuNhap.Columns[3].HeaderText = "Giá nhập";
            dgvPhieuNhap.Columns[4].HeaderText = "Thành tiền";
            dgvPhieuNhap.Columns[5].HeaderText = "Ngày nhập";
            dgvPhieuNhap.Columns[0].Width = 125;
            dgvPhieuNhap.Columns[1].Width = 125;
            dgvPhieuNhap.Columns[2].Width = 95;
            dgvPhieuNhap.Columns[3].Width = 125;
            dgvPhieuNhap.Columns[4].Width = 125;
            dgvPhieuNhap.Columns[5].Width = 100;
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            culture.NumberFormat.NumberGroupSeparator = ".";
            String s = Data.Scalar("select tongtien from phieunhap where id_phieunhap = @id",
                new SqlParameter("@id", cboPhieuNhap.SelectedValue));
            double money = 0;
            if (s != null) money = Convert.ToDouble(s);
            txtTongTien.Text = money.ToString("N", culture) + " VNĐ";
        }
        private void emptyText()
        {
            nmrSoLuong.Value = 1;
            txtGiaNhap.Clear();
            txtNgayNhap.Clear();
        }
        private void cboPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvPhieuNhap_Load();
            cboMaLK_Load();
        }

        private void fNhapKho_Load(object sender, EventArgs e)
        {
            cboPhieuNhap_Load();
            cboPhieuNhap.SelectedIndex = cboPhieuNhap.Items.Count - 1;
        }

        private void cboMaLK_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenLinhKien.Clear();
            if (cboMaLK.SelectedValue == null) return;
            txtTenLinhKien.Text = Data.Scalar("select tensanpham from sanpham where id_sanpham = @id",
                new SqlParameter("@id", cboMaLK.SelectedValue));
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            emptyText();
            cboPhieuNhap.SelectedIndex = cboPhieuNhap.Items.Count - 1;
            foreach (Control c in groupBox2.Controls)
            {
                c.Enabled = true;
            }
            txtTenLinhKien.Enabled = false;
            txtNgayNhap.Enabled = false;
            btnNhapKho.Enabled = true;
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if(cboMaLK.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn linh kiện");
                return;
            }
            if (String.IsNullOrEmpty(txtGiaNhap.Text.Trim()))
            {
                MessageBox.Show("Chưa có giá nhập linh kiện");
                txtGiaNhap.Focus();
                return;
            }
            if (cboPhieuNhap.Text != "-1")
            {
                if(!String.IsNullOrEmpty(Data.Scalar("select * from chitietphieunhap where id_phieunhap = @idp and id_sanpham = @idsp",
                    new SqlParameter("@idp", cboPhieuNhap.SelectedValue),
                    new SqlParameter("@idsp", cboMaLK.SelectedValue))))
                {
                    MessageBox.Show("Sản phẩm đã trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                String query = "insert into chitietphieunhap values (@id, @sp, @sl, @gianhap, @thanhtien)";
                SqlParameter[] args =
                {
                    new SqlParameter("@id", cboPhieuNhap.SelectedValue),
                    new SqlParameter("@sp", cboMaLK.SelectedValue),
                    new SqlParameter("@sl", nmrSoLuong.Value),
                    new SqlParameter("@gianhap", txtGiaNhap.Text.Trim()),
                    new SqlParameter("@thanhtien", nmrSoLuong.Value * Convert.ToDecimal(txtGiaNhap.Text.Trim()))
                }; 
                if (Data.Excute(query, args))
                {
                    emptyText();
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    emptyText();
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                if(Data.Excute("insert into phieunhap values (0, @ngaynhap)",
                    new SqlParameter("@ngaynhap", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))))
                {
                    cboPhieuNhap_Load();
                    cboPhieuNhap.SelectedIndex = cboPhieuNhap.Items.Count - 2;
                    String query = "insert into chitietphieunhap values (@id, @sp, @sl, @gianhap, @thanhtien)";
                    SqlParameter[] args =
                    {
                        new SqlParameter("@id", cboPhieuNhap.SelectedValue),
                        new SqlParameter("@sp", cboMaLK.SelectedValue),
                        new SqlParameter("@sl", nmrSoLuong.Value),
                        new SqlParameter("@gianhap", txtGiaNhap.Text.Trim()),
                        new SqlParameter("@thanhtien", Convert.ToDouble(nmrSoLuong.Value.ToString()) * Convert.ToDouble(txtGiaNhap.Text.Trim()))
                    };
                    if(Data.Excute(query, args))
                    {
                        emptyText();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        emptyText();
                        MessageBox.Show("Thêm thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            dgvPhieuNhap_Load();
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(Control c in groupBox2.Controls)
            {
                c.Enabled = false;
            }
            btnNhapKho.Enabled = false;
            if (dgvPhieuNhap.Rows.Count == 0) return;
            int i = dgvPhieuNhap.SelectedCells[0].RowIndex;
            cboMaLK.SelectedValue = dgvPhieuNhap.Rows[i].Cells[0].Value.ToString();
            nmrSoLuong.Value = Convert.ToDecimal(dgvPhieuNhap.Rows[i].Cells[2].Value.ToString());
            txtGiaNhap.Text = dgvPhieuNhap.Rows[i].Cells[3].Value.ToString();
            txtNgayNhap.Text = dgvPhieuNhap.Rows[i].Cells[5].Value.ToString();
        }
    }
}
