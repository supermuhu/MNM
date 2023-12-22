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
using System.Drawing.Printing;
using DevExpress.ClipboardSource.SpreadsheetML;

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

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            Font font = new Font("Calibri", 20, FontStyle.Bold);
            e.Graphics.DrawString("Phiếu nhập", font, Brushes.Black, new RectangleF(0, 30, e.PageBounds.Width, 30), format);
            font = new Font("Calibri", 13);

            // Vẽ thông tin khách hàng
            format.Alignment = StringAlignment.Near;
            String maphieu = cboPhieuNhap.SelectedValue.ToString();
            e.Graphics.DrawString("Phiếu nhập: " + maphieu, font, Brushes.Black, new PointF(50, 110));
            //String tenban = "Tên khách hàng: " + cboKhachHang.SelectedValue + " - " + DateTime.Now.ToString();
            //e.Graphics.DrawString(tenban, font, Brushes.Black, new PointF(50, 140));

            // Vẽ bảng giá
            int x = 20;
            int y = 150;
            int rowHeight = 30;

            e.Graphics.DrawLine(Pens.Black, x, y, x + 800, y);
            font = new Font("Calibri", 11);
            //e.Graphics.DrawString("Mã linh kiện", font, Brushes.Black, new RectangleF(x, y, 130, rowHeight), format);
            e.Graphics.DrawString("Tên linh kiện", font, Brushes.Black, new RectangleF(x, y, 200, rowHeight), format);
            e.Graphics.DrawString("Số lượng", font, Brushes.Black, new RectangleF(x + 200, y, 80, rowHeight), format);
            e.Graphics.DrawString("Giá nhập", font, Brushes.Black, new RectangleF(x + 280, y, 170, rowHeight), format);
            e.Graphics.DrawString("Thành tiền", font, Brushes.Black, new RectangleF(x + 450, y, 170, rowHeight), format);
            e.Graphics.DrawString("Ngày nhập", font, Brushes.Black, new RectangleF(x + 620, y, 200, rowHeight), format);


            y += rowHeight;
            e.Graphics.DrawLine(Pens.Black, x, y, x + 800, y);
            //Lấy dữ liệu
            foreach (DataGridViewRow row in dgvPhieuNhap.Rows)
            {
                e.Graphics.DrawString(row.Cells[1].Value.ToString(), font, Brushes.Black, new RectangleF(x, y, 200, rowHeight), format);
                e.Graphics.DrawString(row.Cells[2].Value.ToString(), font, Brushes.Black, new RectangleF(x + 200, y, 70, rowHeight), format);
                e.Graphics.DrawString(row.Cells[3].Value.ToString(), font, Brushes.Black, new RectangleF(x + 270, y, 170, rowHeight), format);
                e.Graphics.DrawString(row.Cells[4].Value.ToString(), font, Brushes.Black, new RectangleF(x + 440, y, 170, rowHeight), format);
                e.Graphics.DrawString(row.Cells[5].Value.ToString(), font, Brushes.Black, new RectangleF(x + 610, y, 200, rowHeight), format); 
                y += rowHeight;
            }

            e.Graphics.DrawLine(Pens.Black, x, y, x + 800, y);
            // Vẽ tổng cộng
            y += rowHeight;
            e.Graphics.DrawString("Tổng tiền: " + txtTongTien.Text, new Font("Calibri", 16, FontStyle.Bold), Brushes.Black, new RectangleF(400, y, e.PageBounds.Width, 50), format);
            y += rowHeight;
            font = new Font("Calibri", 13);
            y += rowHeight;
            e.Graphics.DrawString("Địa chỉ: Km 104+200 Nguyễn Bỉnh Khiêm, Phường Đông Hải 2, Quận Hải An, TP Hải Phòng", font, Brushes.Black, new PointF(50, y));
            y += rowHeight;
            e.Graphics.DrawString("Liên hệ: 031.3614221 - supermu626@gmail.com", font, Brushes.Black, new PointF(50, y));
            // Vẽ cảm ơn
            y += rowHeight;
            e.Graphics.DrawString("Cảm ơn vì đã tin tưởng dịch vụ của chúng tôi!!!", new Font("Calibri", 10), Brushes.Black, new RectangleF(270, y, e.PageBounds.Width, 50), format);
            // Giải phóng bộ nhớ
            font.Dispose();
            format.Dispose();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            if(cboPhieuNhap.SelectedValue == null || cboPhieuNhap.Text == "-1")
            {
                MessageBox.Show("Chưa chọn phiếu nhập nào");
                return;
            }
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Mở cửa sổ xem trước
            printPreviewDialog.ShowDialog();
        }
    }
}
