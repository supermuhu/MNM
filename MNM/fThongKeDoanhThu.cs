using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Globalization;
using OfficeOpenXml;
using System.IO;
using DevExpress.Utils.ScrollAnnotations;

namespace MNM2
{
    public partial class fThongKeDoanhThu : UserControl
    {
        public fThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dateTime_Tu.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTime_Den.Value = DateTime.Now.Date;
            String query = "select tensanpham, soluongsp, thanhtien, ngaynhap from chitietphieunhap " +
                "join phieunhap on chitietphieunhap.id_phieunhap = phieunhap.id_phieunhap " +
                "join sanpham on sanpham.id_sanpham = chitietphieunhap.id_sanpham " +
                "where ngaynhap >= @tu and ngaynhap <= @den";
            dgvNhap_Load(query);
            query = "select tensanpham,soluongsp,thanhtien,ngaydathang from chitietphieuxuat " +
                "join phieuxuat on chitietphieuxuat.id_phieuxuat = phieuxuat.id_phieuxuat " +
                "join sanpham on sanpham.id_sanpham = chitietphieuxuat.id_sanpham " +
                "where ngaydathang >= @tu and ngaydathang <= @den";
            dgvXuat_Load(query);
            txtNhapXuatSL_Load();
            txtTienNhapXuat_Load();
        }
        private void dgvNhap_Load(String query)
        {
            dgvNhap.DataSource = Data.GetData(query,
                new SqlParameter("@tu", dateTime_Tu.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@den", dateTime_Den.Value.ToString("yyyy-MM-dd") + " 23:59:59.999"));
            dgvNhap.Columns[0].HeaderText = "Tên linh kiện";
            dgvNhap.Columns[1].HeaderText = "Số lượng";
            dgvNhap.Columns[2].HeaderText = "Thành tiền";
            dgvNhap.Columns[3].HeaderText = "Ngày nhập";
            dgvNhap.Columns[0].Width = 124;
            dgvNhap.Columns[1].Width = 75;
            dgvNhap.Columns[2].Width = 105;
            dgvNhap.Columns[3].Width = 105;
        }
        private void dgvXuat_Load(String query)
        {
            dgvXuat.DataSource = Data.GetData(query,
                new SqlParameter("@tu", dateTime_Tu.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@den", dateTime_Den.Value.ToString("yyyy-MM-dd") + " 23:59:59.999"));
            dgvXuat.Columns[0].HeaderText = "Tên linh kiện";
            dgvXuat.Columns[1].HeaderText = "Số lượng";
            dgvXuat.Columns[2].HeaderText = "Thành tiền";
            dgvXuat.Columns[3].HeaderText = "Ngày xuất";
            dgvXuat.Columns[0].Width = 124;
            dgvXuat.Columns[1].Width = 75;
            dgvXuat.Columns[2].Width = 105;
            dgvXuat.Columns[3].Width = 105;
        }
        
        private void txtNhapXuatSL_Load()
        {
            int c = 0;
            int d = 0;
            for (int i = 0; i < dgvNhap.RowCount; i++)
            {
                c += Convert.ToInt32(dgvNhap.Rows[i].Cells[1].Value.ToString());

            }
            for (int j = 0; j < dgvXuat.RowCount; j++)
            {
                d += Convert.ToInt32(dgvXuat.Rows[j].Cells[1].Value.ToString());

            }
            txtNhapSL.Text = c.ToString();
            txtXuatSL.Text = d.ToString();
        }
        private void txtTienNhapXuat_Load()
        {
            decimal c = 0;
            decimal d = 0;
            for (int i = 0; i < dgvNhap.RowCount; i++)
            {
                c += Convert.ToDecimal(dgvNhap.Rows[i].Cells[2].Value.ToString());

            }
            for (int j = 0; j < dgvXuat.RowCount; j++)
            {
                d += Convert.ToDecimal(dgvXuat.Rows[j].Cells[2].Value.ToString());

            }
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            culture.NumberFormat.NumberGroupSeparator = ".";
            txtTienXuat.Text = d.ToString("N", culture) + " VNĐ";
            txtTienNhap.Text = c.ToString("N", culture) + " VNĐ";
            txtTongTien.Text = (d - c).ToString("N", culture) + " VNĐ";
        }
        private void fThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            dateTime_Tu.Value = new DateTime(dateTime_Tu.Value.Year, dateTime_Tu.Value.Month, 1);
            dateTime_Tu.MaxDate = dateTime_Den.Value;
            dateTime_Den.MinDate = dateTime_Tu.Value;
            dateTime_Den.MaxDate = DateTime.Now;
            String query = "select tensanpham, soluongsp, thanhtien, ngaynhap from chitietphieunhap " +
                "join phieunhap on chitietphieunhap.id_phieunhap = phieunhap.id_phieunhap " +
                "join sanpham on sanpham.id_sanpham = chitietphieunhap.id_sanpham " +
                "where ngaynhap >= @tu and ngaynhap <= @den";
            dgvNhap_Load(query);
            query = "select tensanpham,soluongsp,thanhtien,ngaydathang from chitietphieuxuat " +
                "join phieuxuat on chitietphieuxuat.id_phieuxuat = phieuxuat.id_phieuxuat " +
                "join sanpham on sanpham.id_sanpham = chitietphieuxuat.id_sanpham " +
                "where ngaydathang >= @tu and ngaydathang <= @den";
            dgvXuat_Load(query);
            txtNhapXuatSL_Load();
            txtTienNhapXuat_Load();
        }

        private void dateTime_Tu_ValueChanged(object sender, EventArgs e)
        {
            dateTime_Den.MinDate = dateTime_Tu.Value;
            String query = "select tensanpham, soluongsp, thanhtien, ngaynhap from chitietphieunhap " +
                "join phieunhap on chitietphieunhap.id_phieunhap = phieunhap.id_phieunhap " +
                "join sanpham on sanpham.id_sanpham = chitietphieunhap.id_sanpham " +
                "where ngaynhap >= @tu and ngaynhap <= @den";
            dgvNhap_Load(query);
            query = "select tensanpham,soluongsp,thanhtien,ngaydathang from chitietphieuxuat " +
                "join phieuxuat on chitietphieuxuat.id_phieuxuat = phieuxuat.id_phieuxuat " +
                "join sanpham on sanpham.id_sanpham = chitietphieuxuat.id_sanpham " +
                "where ngaydathang >= @tu and ngaydathang <= @den";
            dgvXuat_Load(query);
            txtNhapXuatSL_Load();
            txtTienNhapXuat_Load();
        }

        private void dateTime_Den_ValueChanged(object sender, EventArgs e)
        {
            String query = "select tensanpham, soluongsp, tongtien, ngaynhap from chitietphieunhap " +
                "join phieunhap on chitietphieunhap.id_phieunhap = phieunhap.id_phieunhap " +
                "join sanpham on sanpham.id_sanpham = chitietphieunhap.id_sanpham " +
                "where ngaynhap >= @tu and ngaynhap <= @den";
            dgvNhap_Load(query);
            query = "select tensanpham,soluongsp,thanhtien,ngaydathang from chitietphieuxuat " +
                "join phieuxuat on chitietphieuxuat.id_phieuxuat = phieuxuat.id_phieuxuat " +
                "join sanpham on sanpham.id_sanpham = chitietphieuxuat.id_sanpham " +
                "where ngaydathang >= @tu and ngaydathang <= @den";
            dgvXuat_Load(query);
            txtNhapXuatSL_Load();
            txtTienNhapXuat_Load();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveExcel.Filter = "Tệp Excel|*.xlsx";
            saveExcel.Title = "Save a File";
            saveExcel.FileName = "Thống kê doanh thu_" + dateTime_Tu.Value.ToString("yyyy-MM-dd") + "_" + dateTime_Den.Value.ToString("yyyy-MM-dd");
            if (saveExcel.ShowDialog() == DialogResult.OK)
            {

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    worksheet.Cells["A1"].Value = "Từ";
                    worksheet.Cells["A2"].Value = "Đến";
                    worksheet.Cells["B1"].Value = dateTime_Tu.Value;
                    worksheet.Cells["B1"].Style.Numberformat.Format = "MM/dd/yyyy";
                    worksheet.Cells["B2"].Value = dateTime_Den.Value;
                    worksheet.Cells["B2"].Style.Numberformat.Format = "MM/dd/yyyy";
                    worksheet.Cells["H1"].Value = "Tổng tiền: " + txtTongTien.Text;
                    worksheet.Columns[4].Style.Numberformat.Format = "MM/dd/yyyy HH:mm:ss";
                    worksheet.Columns[9].Style.Numberformat.Format = "MM/dd/yyyy HH:mm:ss";
                    //String[] arr = txtTongTien.Text.Substring(0, txtTongTien.Text.Length - 7).Split('.');
                    //String tongtien = "";
                    //foreach(String s in arr)
                    //{
                    //    tongtien += s;
                    //}
                    //worksheet.Cells["I1"].Value = Convert.ToDouble(tongtien);
                    worksheet.Cells["A4"].Value = "Thống kê hàng nhập";
                    worksheet.Cells["F4"].Value = "Thống kê hàng xuất";

                    worksheet.Cells["A5"].Value = "Tên linh kiện";
                    worksheet.Cells["B5"].Value = "Số lượng";
                    worksheet.Cells["C5"].Value = "Thành tiền";
                    worksheet.Cells["D5"].Value = "Ngày nhập";

                    worksheet.Cells["F5"].Value = "Tên linh kiện";
                    worksheet.Cells["G5"].Value = "Số lượng";
                    worksheet.Cells["H5"].Value = "Thành tiền";
                    worksheet.Cells["I5"].Value = "Ngày xuất";

                    int index = 6;
                    int nhap = 0, xuat = 0;
                    while(nhap < dgvNhap.Rows.Count || xuat < dgvXuat.Rows.Count)
                    {
                        if(nhap < dgvNhap.Rows.Count)
                        {
                            for (int j = 0; j < dgvNhap.Columns.Count; j++)
                            {
                                worksheet.Cells[index, j + 1].Value = dgvNhap.Rows[nhap].Cells[j].Value;
                            }
                            nhap++;
                        }
                        if(xuat < dgvXuat.Rows.Count)
                        {
                            for (int j = 0; j < dgvNhap.Columns.Count; j++)
                            {
                                worksheet.Cells[index, j + 6].Value = dgvXuat.Rows[xuat].Cells[j].Value;
                            }
                            xuat++;
                        }
                        index++;
                    }
                    index++;
                    worksheet.Cells[index, 1].Value = "Tổng số lượng sản phẩm";
                    worksheet.Cells[index, 4].Value = txtNhapSL.Text;
                    worksheet.Cells[index, 6].Value = "Tổng số lượng sản phẩm";
                    worksheet.Cells[index, 9].Value = txtXuatSL.Text;
                    index++;
                    worksheet.Cells[index, 1].Value = "Tổng giá trị hàng nhập";
                    worksheet.Cells[index, 4].Value = txtTienNhap.Text;
                    worksheet.Cells[index, 6].Value = "Tổng giá trị hàng xuất";
                    worksheet.Cells[index, 9].Value = txtTienXuat.Text;
                    worksheet.Cells.AutoFitColumns();
                    var newFileInfo = new FileInfo(saveExcel.FileName);
                    try
                    {
                        package.SaveAs(newFileInfo);
                    }
                    catch
                    {
                        MessageBox.Show("Không lưu được");
                    }
                }
            }

        }
    }
}
