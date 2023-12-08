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
        }
        private void dgvNhap_Load(String query)
        {
            dgvNhap.DataSource = Data.GetData(query,
                new SqlParameter("@tu", dateTime_Tu.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@den", dateTime_Den.Value.ToString("yyyy-MM-dd")));
            dgvNhap.Columns[0].HeaderText = "Tên linh kiện";
            dgvNhap.Columns[1].HeaderText = "Số lượng";
            dgvNhap.Columns[2].HeaderText = "Tổng tiền";
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
                new SqlParameter("@den", dateTime_Den.Value.ToString("yyyy-MM-dd")));
            dgvXuat.Columns[0].HeaderText = "Tên linh kiện";
            dgvXuat.Columns[1].HeaderText = "Số lượng";
            dgvXuat.Columns[2].HeaderText = "Tổng tiền";
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
            txtTienXuat.Text = d.ToString();
            txtTienNhap.Text = c.ToString();
            txtTongTien.Text = (d - c).ToString();
        }
        private void fThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            dateTime_Tu.Value = new DateTime(dateTime_Tu.Value.Year, dateTime_Tu.Value.Month, 1);
            dateTime_Tu.MaxDate = dateTime_Den.Value;
            dateTime_Den.MinDate = dateTime_Tu.Value;
            dateTime_Den.MaxDate = DateTime.Now;
            txtNhapXuatSL_Load();
            txtTienNhapXuat_Load();
        }

        private void dateTime_Tu_ValueChanged(object sender, EventArgs e)
        {
            dateTime_Den.MinDate = dateTime_Tu.Value;
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
    }
}
