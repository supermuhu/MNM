using DevExpress.Data.Filtering;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.Utils.Animation;
using DevExpress.Xpo.DB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MNM2
{
    public partial class fXuatKho : UserControl
    {
        public fXuatKho()
        {
            InitializeComponent();
        }
        private void Loaad()
        {
            string querry = "select ngaydathang, chitietphieuxuat.id_sanpham, tensanpham, soluongsp from phieuxuat inner join chitietphieuxuat on phieuxuat.id_phieuxuat = chitietphieuxuat.id_phieuxuat inner join phuongthucthanhtoan on phieuxuat.id_thanhtoan = phuongthucthanhtoan.id_thanhtoan inner join sanpham on chitietphieuxuat.id_sanpham = sanpham.id_sanpham inner join khachhang on khachhang.id_khachhang = phieuxuat.id_khachhang";
            dgvPhieuXuat.DataSource = Data.GetData(querry);
        }
        private void fXuatKho_Load(object sender, EventArgs e)
        {
            string querry = "select ngaydathang, chitietphieuxuat.id_sanpham, tensanpham, soluongsp from phieuxuat inner join chitietphieuxuat on phieuxuat.id_phieuxuat = chitietphieuxuat.id_phieuxuat inner join phuongthucthanhtoan on phieuxuat.id_thanhtoan = phuongthucthanhtoan.id_thanhtoan inner join sanpham on chitietphieuxuat.id_sanpham = sanpham.id_sanpham inner join khachhang on khachhang.id_khachhang = phieuxuat.id_khachhang";
            dgvPhieuXuat.DataSource = Data.GetData(querry);
            querry = "select sum(tongtien) from phieuxuat";
            txtTongTien.Text = Data.Scalar(querry);
            querry = "select * from phieuxuat";
            cboPhieuXuat.DataSource = null;
            cboPhieuXuat.DisplayMember = "id_phieuxuat";
            cboPhieuXuat.ValueMember = "id_phieuxuat";
            DataTable dt = Data.GetData(querry);
            dt.Rows.Add("-1");
            cboPhieuXuat.DataSource = dt;
            cboPhieuXuat.SelectedIndex = cboPhieuXuat.Items.Count - 1;
            querry = "select * from khachhang";
            cboKhachHang.DataSource = null;
            cboKhachHang.DisplayMember = "ten";
            cboKhachHang.ValueMember = "id_khachhang";
            cboKhachHang.DataSource = Data.GetData(querry);
            querry = "select * from phuongthucthanhtoan";
            cbox_Xuatkho_Thanhtoan.DataSource = null;
            cbox_Xuatkho_Thanhtoan.DisplayMember = "tenthanhtoan";
            cbox_Xuatkho_Thanhtoan.ValueMember = "id_thanhtoan";
            cbox_Xuatkho_Thanhtoan.DataSource = Data.GetData(querry);
            querry = "select * from sanpham";
            cboMaLK.DataSource = null;
            cboMaLK.DisplayMember = "id_sanpham";
            cboMaLK.ValueMember = "id_sanpham";
            cboMaLK.DataSource = Data.GetData(querry);
            querry = "select tensanpham from sanpham where id_sanpham = @Value1";
            SqlParameter p = new SqlParameter("@Value1", cboMaLK.SelectedValue.ToString());
            txtTenLinhKien.Text = Data.Scalar(querry, p);
            querry = "select ngaydathang from phieuxuat where id_phieuxuat = @Value1";
            SqlParameter p1 = new SqlParameter("@Value1", cboPhieuXuat.SelectedValue);
            txtNgayXuat.Text = Data.Scalar(querry, p1);
        }

        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuXuat.Rows.Count == .0) return;
            foreach (Control control in groupBox2.Controls)
            {
                control.Enabled = false;
            }
            btnXuatKho.Enabled = false;
            if (dgvPhieuXuat.SelectedCells[0].Value == null) return;
            int rowindex = dgvPhieuXuat.SelectedCells[0].RowIndex;
            //cboKhachHang.DataSource = null;
            //cboKhachHang.DataSource = Data.GetData("select id_khachhang from phieuxuat where id_phieuxuat = @id",
            //    new SqlParameter("@id", cboPhieuXuat.SelectedValue));
            //cbox_Xuatkho_Thanhtoan.DataSource = null;
            //cbox_Xuatkho_Thanhtoan.DataSource = Data.GetData("select id_thanhtoan from phieuxuat where id_phieuxuat = @id",
            //    new SqlParameter("@id", cboPhieuXuat.SelectedValue));
            txtNgayXuat.Text = dgvPhieuXuat.Rows[rowindex].Cells[0].Value.ToString();
            cboMaLK.SelectedValue = dgvPhieuXuat.Rows[rowindex].Cells[1].Value.ToString();
            txtTenLinhKien.Text = dgvPhieuXuat.Rows[rowindex].Cells[2].Value.ToString();
            nmrSoLuong.Value = Convert.ToDecimal(dgvPhieuXuat.Rows[rowindex].Cells[3].Value.ToString());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox2.Controls)
            {
                control.Enabled = true;
            }
            cboPhieuXuat.SelectedIndex = cboPhieuXuat.Items.Count-1;
            //if (cboKhachHang.SelectedValue != null) cboKhachHang.SelectedIndex = 0;
            cboKhachHang.DataSource = null;
            cboKhachHang.DisplayMember = "ten";
            cboKhachHang.ValueMember = "id_khachhang";
            cboKhachHang.DataSource = Data.GetData("select * from khachhang");
            //txtNgayXuat.Clear();
            cbox_Xuatkho_Thanhtoan.DataSource = null;
            cbox_Xuatkho_Thanhtoan.DisplayMember = "tenthanhtoan";
            cbox_Xuatkho_Thanhtoan.ValueMember = "id_thanhtoan";
            cbox_Xuatkho_Thanhtoan.DataSource = Data.GetData("select * from phuongthucthanhtoan");
            if (cboMaLK.SelectedValue != null) cboMaLK.SelectedIndex = 0;
            txtNgayXuat.Clear();
            //txtTongTien.Clear();
            nmrSoLuong.Value = 1;

            btnXuatKho.Enabled = true;
        }
        private bool checkslhang(string masp, int slg)
        {
            string querry = "select soluong from sanpham where id_sanpham = @Value1";
            int sl = 0;
            using (SqlConnection conn = new SqlConnection(Data.GetStringConnection()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(querry, conn))
                {
                    cmd.Parameters.AddWithValue("@Value1", masp);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            sl = reader.GetInt32(0);
                        }
                    }
                }
            }
            if (sl - slg >= 0)
            {
                return true;
            }
            return false;
        }
        private bool checkmasp(string maphieu, string masp)
        {
            String s = Data.Scalar("select * from chitietphieuxuat where id_phieuxuat = @phieu and id_sanpham = @sp",
                new SqlParameter("@phieu", maphieu),
                new SqlParameter("@sp", masp));
            return (s == null) ? true : false;
        }
        private void btnXuatKho_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.Text.Equals(string.Empty) || cbox_Xuatkho_Thanhtoan.Text.Equals(string.Empty) || cboMaLK.SelectedIndex == -1)
            {
                if (cboKhachHang.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Chưa chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cbox_Xuatkho_Thanhtoan.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Chưa chọn phương thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboMaLK.SelectedIndex == -1)
                {
                    MessageBox.Show("Chưa chọn linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (cboPhieuXuat.Text.Equals("-1"))
                {
                    if (checkslhang(cboMaLK.SelectedValue.ToString(), int.Parse(nmrSoLuong.Value.ToString())))
                    {
                        String querry = "insert into phieuxuat(id_khachhang, ngaydathang, id_thanhtoan, tongtien, ghichu) values(@Value1, @Value2, @Value3, @Value4, @Value5)";
                        SqlParameter[] p = {
                            new SqlParameter("@Value1", cboKhachHang.SelectedValue),
                            new SqlParameter("@Value2", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                            new SqlParameter("@Value3", cbox_Xuatkho_Thanhtoan.SelectedValue),
                            new SqlParameter("@Value4", "0"),
                            new SqlParameter("@Value5", "")
                        };
                        bool ex = Data.Excute(querry, p);
                        querry = "select id_phieuxuat from phieuxuat";
                        cboPhieuXuat.DataSource = null;
                        cboPhieuXuat.DisplayMember = "id_phieuxuat";
                        cboPhieuXuat.ValueMember = "id_phieuxuat";
                        DataTable dt = Data.GetData(querry);
                        dt.Rows.Add("-1");
                        cboPhieuXuat.DataSource = dt;
                        cboPhieuXuat.SelectedIndex = cboPhieuXuat.Items.Count - 2;
                        querry = "select gia from sanpham where id_sanpham = @Value1";
                        decimal tien = 0;
                        using (SqlConnection conn = new SqlConnection(Data.GetStringConnection()))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(querry, conn))
                            {
                                cmd.Parameters.AddWithValue("@Value1", cboMaLK.SelectedValue);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();
                                        tien = reader.GetDecimal(0);
                                    }
                                }
                            }
                        }
                        tien = tien * nmrSoLuong.Value;
                        querry = "insert into chitietphieuxuat values(@Value1, @Value2, @Value3, @Value4)";
                        SqlParameter[] p1 =
                        {
                            new SqlParameter("@Value1", cboPhieuXuat.SelectedValue),
                            new SqlParameter("@Value2", cboMaLK.SelectedValue),
                            new SqlParameter("@Value3", nmrSoLuong.Value),
                            new SqlParameter("@Value4", tien)
                        };
                        ex = Data.Excute(querry, p1);
                        querry = "select ngaydathang, chitietphieuxuat.id_sanpham, tensanpham, soluongsp from phieuxuat inner join chitietphieuxuat on phieuxuat.id_phieuxuat = chitietphieuxuat.id_phieuxuat inner join phuongthucthanhtoan on phieuxuat.id_thanhtoan = phuongthucthanhtoan.id_thanhtoan inner join sanpham on chitietphieuxuat.id_sanpham = sanpham.id_sanpham inner join khachhang on khachhang.id_khachhang = phieuxuat.id_khachhang where phieuxuat.id_phieuxuat = @Value1";
                        SqlParameter p2 = new SqlParameter("@Value1", cboPhieuXuat.SelectedValue);
                        dgvPhieuXuat.DataSource = Data.GetData(querry, p2);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không đủ số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (checkmasp(cboPhieuXuat.SelectedValue.ToString(), cboMaLK.SelectedValue.ToString()))
                    {
                        if (checkslhang(cboMaLK.SelectedValue.ToString(), int.Parse(nmrSoLuong.Value.ToString())))
                        {
                            String querry = "select gia from sanpham where id_sanpham = @Value1";
                            decimal tien = 0;
                            using (SqlConnection conn = new SqlConnection(Data.GetStringConnection()))
                            {
                                conn.Open();
                                using (SqlCommand cmd = new SqlCommand(querry, conn))
                                {
                                    cmd.Parameters.AddWithValue("@Value1", cboMaLK.SelectedValue);
                                    using (SqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            reader.Read();
                                            tien = reader.GetDecimal(0);
                                        }
                                    }
                                }
                            }
                            tien = tien * nmrSoLuong.Value;
                            querry = "insert into chitietphieuxuat values(@Value1, @Value2, @Value3, @Value4)";
                            SqlParameter[] p = {
                                new SqlParameter("@Value1", cboPhieuXuat.SelectedValue),
                                new SqlParameter("@Value2", cboMaLK.SelectedValue),
                                new SqlParameter("@Value3", nmrSoLuong.Value),
                                new SqlParameter("@Value4", tien)
                            };
                            bool ex = Data.Excute(querry, p);
                            querry = "select ngaydathang, chitietphieuxuat.id_sanpham, tensanpham, soluongsp from phieuxuat inner join chitietphieuxuat on phieuxuat.id_phieuxuat = chitietphieuxuat.id_phieuxuat inner join phuongthucthanhtoan on phieuxuat.id_thanhtoan = phuongthucthanhtoan.id_thanhtoan inner join sanpham on chitietphieuxuat.id_sanpham = sanpham.id_sanpham inner join khachhang on khachhang.id_khachhang = phieuxuat.id_khachhang where phieuxuat.id_phieuxuat = @Value1";
                            SqlParameter p2 = new SqlParameter("@Value1", cboPhieuXuat.SelectedValue);
                            dgvPhieuXuat.DataSource = Data.GetData(querry, p2);
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm không đủ số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm đã trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }        
        private void cboPhieuXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhieuXuat.SelectedValue != null)
            {
                //UpdateDataBasedOnComboBoxSelection();
                if (cboPhieuXuat.Text.Equals("-1"))
                {
                    cboKhachHang.DataSource = null;
                    cboKhachHang.DisplayMember = "ten";
                    cboKhachHang.ValueMember = "id_khachhang";
                    cboKhachHang.DataSource = Data.GetData("select * from khachhang");
                    //txtNgayXuat.Clear();
                    cbox_Xuatkho_Thanhtoan.DataSource = null;
                    cbox_Xuatkho_Thanhtoan.DisplayMember = "tenthanhtoan";
                    cbox_Xuatkho_Thanhtoan.ValueMember = "id_thanhtoan";
                    cbox_Xuatkho_Thanhtoan.DataSource = Data.GetData("select * from phuongthucthanhtoan");
                }
                else
                {
                    cboKhachHang.DataSource = null;
                    cboKhachHang.DisplayMember = "ten";
                    cboKhachHang.ValueMember = "id_khachhang";
                    cboKhachHang.DataSource = Data.GetData("select khachhang.id_khachhang, ten from khachhang join phieuxuat on khachhang.id_khachhang = phieuxuat.id_khachhang where id_phieuxuat = @id",
                        new SqlParameter("@id", cboPhieuXuat.SelectedValue));
                    cbox_Xuatkho_Thanhtoan.DataSource = null;
                    cbox_Xuatkho_Thanhtoan.DisplayMember = "tenthanhtoan";
                    cbox_Xuatkho_Thanhtoan.ValueMember = "id_thanhtoan";
                    cbox_Xuatkho_Thanhtoan.DataSource = Data.GetData("select phuongthucthanhtoan.id_thanhtoan, tenthanhtoan from phuongthucthanhtoan join phieuxuat on phuongthucthanhtoan.id_thanhtoan = phieuxuat.id_thanhtoan where id_phieuxuat = @id",
                        new SqlParameter("@id", cboPhieuXuat.SelectedValue));
                }
                var culture = new CultureInfo("en-US");
                culture.NumberFormat.NumberDecimalSeparator = ",";
                culture.NumberFormat.NumberGroupSeparator = ".";
                String s = Data.Scalar("select tongtien from phieuxuat where id_phieuxuat = @id",
                    new SqlParameter("@id", cboPhieuXuat.SelectedValue));
                double money = 0;
                if (s != null) money = Convert.ToDouble(s);
                txtTongTien.Text = money.ToString("N", culture) + " VNĐ";
                string querry = "select ngaydathang, chitietphieuxuat.id_sanpham, tensanpham, soluongsp from phieuxuat inner join chitietphieuxuat on phieuxuat.id_phieuxuat = chitietphieuxuat.id_phieuxuat inner join phuongthucthanhtoan on phieuxuat.id_thanhtoan = phuongthucthanhtoan.id_thanhtoan inner join sanpham on chitietphieuxuat.id_sanpham = sanpham.id_sanpham inner join khachhang on khachhang.id_khachhang = phieuxuat.id_khachhang where phieuxuat.id_phieuxuat = @Value1";
                using (SqlConnection conn = new SqlConnection(Data.GetStringConnection()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(querry, conn))
                    {
                        cmd.Parameters.AddWithValue("@Value1", cboPhieuXuat.SelectedValue);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvPhieuXuat.DataSource = dt;
                    }
                }

            }
            else
            {
                return;
            }
        }
        //private void UpdateDataBasedOnComboBoxSelection()
        //{
        //    string querry = "select ngaydathang from phieuxuat where id_phieuxuat = @Value1";
        //    using (SqlConnection conn = new SqlConnection(Data.GetStringConnection()))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(querry, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Value1", cboPhieuXuat.SelectedValue.ToString());
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    reader.Read();
        //                    DateTime value = reader.GetDateTime(0);
        //                    txtNgayXuat.Text = value.ToString();
        //                }
        //                else
        //                {
        //                    txtNgayXuat.Text = string.Empty;
        //                }
        //            }
        //        }
        //    }
        //}

        private void cboMaLK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaLK.SelectedIndex != -1)
            {
                string querry = "select tensanpham from sanpham where id_sanpham = @Value1";
                SqlParameter p = new SqlParameter("@Value1", cboMaLK.SelectedValue.ToString());
                txtTenLinhKien.Text = Data.Scalar(querry, p);
            }
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null) return;
            txtKhachHang.Text = cboKhachHang.SelectedValue.ToString();
        }
    }
}
