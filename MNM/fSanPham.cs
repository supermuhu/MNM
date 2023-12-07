using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Filtering.Templates;

namespace MNM2
{
    public partial class fSanPham : UserControl
    {
        public fSanPham()
        {
            InitializeComponent();
        }
        String linkImage = @"";
        private void cboNhomLK_Load()
        {
            cboNhomLK.DataSource = null;
            cboNhomLK.ValueMember = "id_nhom";
            cboNhomLK.DisplayMember = "tennhom";
            cboNhomLK.DataSource = Data.GetData("select * from nhomsanpham");
        }
        private void cboLoaiLK_Load()
        {
            cboLoaiLK.DataSource = null;
            if (cboNhomLK.SelectedValue == null) return;
            cboLoaiLK.ValueMember = "id_loai";
            cboLoaiLK.DisplayMember = "tenloai";
            cboLoaiLK.DataSource = Data.GetData("select * from loaisanpham where id_nhom = @id", 
                new SqlParameter("@id", cboNhomLK.SelectedValue));
        }
        private void cboThuongHieu_Load()
        {
            cboThuongHieu.DataSource = null;
            if (cboNhomLK.SelectedValue == null) return;
            cboThuongHieu.ValueMember = "id_thuonghieu";
            cboThuongHieu.DisplayMember = "tenthuonghieu";
            cboThuongHieu.DataSource = Data.GetData("select * from thuonghieu where id_nhom = @id",
                new SqlParameter("@id", cboNhomLK.SelectedValue));
        }
        private void dgvSanPham_Load()
        {
            dgvSanPham.DataSource = null;
            if (cboLoaiLK.SelectedValue == null || cboThuongHieu.SelectedValue == null) return;
            dgvSanPham.DataSource = Data.GetData("select * from sanpham where id_loai = @id and id_thuonghieu = @th",
                new SqlParameter("@id", cboLoaiLK.SelectedValue),
                new SqlParameter("@th", cboThuongHieu.SelectedValue));
            dgvSanPham.Columns[0].HeaderText = "Mã linh kiện";
            dgvSanPham.Columns[1].HeaderText = "Mã thương hiệu";
            dgvSanPham.Columns[2].HeaderText = "Tên linh kiện";
            dgvSanPham.Columns[3].HeaderText = "Mã loại";
            dgvSanPham.Columns[4].HeaderText = "Giá";
            dgvSanPham.Columns[5].HeaderText = "Bảo hành";
            dgvSanPham.Columns[6].HeaderText = "Khuyến mại";
            dgvSanPham.Columns[7].HeaderText = "Hình";
            dgvSanPham.Columns[8].HeaderText = "Mô tả";
            dgvSanPham.Columns[9].HeaderText = "Ngày tạo";
            dgvSanPham.Columns[10].HeaderText = "Ngày cập nhật";
            dgvSanPham.Columns[11].HeaderText = "Số lượng";
            dgvSanPham.Columns[0].Width = 100;
            dgvSanPham.Columns[1].Width = 110;
            dgvSanPham.Columns[2].Width = 150;
            dgvSanPham.Columns[3].Width = 100;
            dgvSanPham.Columns[4].Width = 120;
            dgvSanPham.Columns[5].Width = 80;
            dgvSanPham.Columns[6].Width = 100;
            dgvSanPham.Columns[7].Width = 100;
            dgvSanPham.Columns[8].Width = 120;
            dgvSanPham.Columns[9].Width = 110;
            dgvSanPham.Columns[10].Width = 110;
            dgvSanPham.Columns[11].Width = 100;
        }
        private void fSanPham_Load(object sender, EventArgs e)
        {
            cboNhomLK_Load();
            txtMaLinhKien.Text = AutoNameLinkKien();
        }
        
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham.Rows.Count == 0 || dgvSanPham.SelectedCells[0].Value == null) return;
            int index = dgvSanPham.SelectedCells[0].RowIndex;
            //pictureLinhKien.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + @"\image\" + dgvSanPham.Rows[index].Cells[7].Value);
            //string imagePath = dgvSanPham.Rows[index].Cells[7].Value.ToString();
            linkImage = dgvSanPham.Rows[index].Cells[7].Value.ToString();
            pictureLinhKien.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + @"\image\" + linkImage);
            txtMaLinhKien.Text = dgvSanPham.Rows[index].Cells[0].Value.ToString();
            txtTenLinhKien.Text = dgvSanPham.Rows[index].Cells[2].Value.ToString();
            txtGia.Text = dgvSanPham.Rows[index].Cells[4].Value.ToString();
            cboThuongHieu.SelectedValue = Convert.ToInt32(dgvSanPham.Rows[index].Cells[1].Value.ToString());
            nmrBaoHanh.Value = Convert.ToDecimal(dgvSanPham.Rows[index].Cells[5].Value.ToString());
            nmrKhuyenMai.Value = Convert.ToDecimal(dgvSanPham.Rows[index].Cells[6].Value.ToString());
            richMoTa.Text = dgvSanPham.Rows[index].Cells[8].Value.ToString();
            txtNgayTao.Text = dgvSanPham.Rows[index].Cells[9].Value.ToString();
            txtCapNhat.Text = dgvSanPham.Rows[index].Cells[10].Value.ToString();
            nmrSoluong.Value = Convert.ToDecimal(dgvSanPham.Rows[index].Cells[11].Value.ToString());
        }
        private void emptyText()
        {
            txtMaLinhKien.Text = AutoNameLinkKien();
            pictureLinhKien.BackgroundImage = null;
            txtTenLinhKien.Text = "";
            txtGia.Text = "";
            nmrBaoHanh.Value = 0;
            nmrKhuyenMai.Value = 0;
            richMoTa.Text = "";
            txtNgayTao.Text = "";
            txtCapNhat.Text = "";
            nmrSoluong.Value = 0;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            emptyText();
            cboNhomLK_Load();
        }

        private void cboNhomLK_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLoaiLK_Load();
            cboThuongHieu_Load();
            emptyText();
        }

        private void cboLoaiLK_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSanPham_Load();
        }
        private String AutoNameLinkKien()
        {
            String[] a = DateTime.Now.ToString("dd MM yy HH mm ss ff").Split(' ');
            return a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6];
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(cboNhomLK.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhóm linh kiện");
                return;
            }
            if (cboLoaiLK.Items.Count == 0)
            {
                MessageBox.Show("Chưa có loại linh kiện");
                return;
            }
            if (String.IsNullOrEmpty(txtTenLinhKien.Text))
            {
                MessageBox.Show("Chưa có tên linh kiện");
                txtTenLinhKien.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Chưa có giá linh kiện");
                txtGia.Focus();
                return;
            }
            if(cboThuongHieu.Items.Count == 0)
            {
                MessageBox.Show("Chưa có thương hiệu");
                return;
            }
            if (pictureLinhKien.BackgroundImage == null)
            {
                btnChonHinh_Click(sender, e);
            }
            if (txtMaLinhKien.Text == Data.Scalar("select * from sanpham where id_sanpham = @id",
                new SqlParameter("@id", txtMaLinhKien.Text)))
            {
                MessageBox.Show("Trùng mã linh kiện");
                return;
            }
            String query = "insert into sanpham values (@sp, @th, @ten, @loai, @gia, @baohanh, @khuyenmai, " +
                "@hinh, @mota, @ngaytao, @ngaycapnhat, @sl)";
            SqlParameter[] args =
            {
                new SqlParameter("@sp", txtMaLinhKien.Text),
                new SqlParameter("@th", cboThuongHieu.SelectedValue),
                new SqlParameter("@ten", txtTenLinhKien.Text),
                new SqlParameter("@loai", cboLoaiLK.SelectedValue),
                new SqlParameter("@gia", txtGia.Text),
                new SqlParameter("@baohanh", nmrBaoHanh.Value),
                new SqlParameter("@khuyenmai", nmrKhuyenMai.Value),
                new SqlParameter("@hinh", linkImage),
                new SqlParameter("@mota", String.IsNullOrEmpty(richMoTa.Text) ? "Còn mới" : richMoTa.Text),
                new SqlParameter("@ngaytao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@sl", nmrSoluong.Value)
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvSanPham_Load();
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openImage.FileName;

                string targetPath = Directory.GetCurrentDirectory() + @"\image\";
                string fileName = Path.GetFileName(selectedImagePath);
                string destinationPath = Path.Combine(targetPath, fileName);

                if (!File.Exists(destinationPath))
                {
                    File.Copy(selectedImagePath, destinationPath);
                }
                linkImage = fileName;
                pictureLinhKien.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + @"\image\" + fileName);
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboNhomLK.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhóm linh kiện");
                return;
            }
            if (cboLoaiLK.Items.Count == 0)
            {
                MessageBox.Show("Chưa có loại linh kiện");
                return;
            }
            if (String.IsNullOrEmpty(txtTenLinhKien.Text))
            {
                MessageBox.Show("Chưa có tên linh kiện");
                txtTenLinhKien.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Chưa có giá linh kiện");
                txtGia.Focus();
                return;
            }
            if (cboThuongHieu.Items.Count == 0)
            {
                MessageBox.Show("Chưa có thương hiệu");
                return;
            }
            if (pictureLinhKien.BackgroundImage == null)
            {
                btnChonHinh_Click(sender, e);
            }
            String query = "update sanpham " +
                "set id_thuonghieu = @th," +
                "tensanpham = @ten," +
                "id_loai = @loai," +
                "gia = @gia," +
                "baohanh = @bh," +
                "khuyenmai = @km," +
                "hinh = @hinh," +
                "mota = @mota," +
                "ngaycapnhat = @capnhat," +
                "soluong = @sl " +
                "where id_sanpham = @sp";
            SqlParameter[] args =
            {
                new SqlParameter("@th", cboThuongHieu.SelectedValue),
                new SqlParameter("@ten", txtTenLinhKien.Text),
                new SqlParameter("@loai", cboLoaiLK.SelectedValue),
                new SqlParameter("@gia", txtGia.Text),
                new SqlParameter("@bh", nmrBaoHanh.Value),
                new SqlParameter("@km", nmrKhuyenMai.Value),
                new SqlParameter("@hinh", linkImage),
                new SqlParameter("@mota", String.IsNullOrEmpty(richMoTa.Text) ? "Còn mới" : richMoTa.Text),
                new SqlParameter("@capnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                new SqlParameter("@sl", nmrSoluong.Value),
                new SqlParameter("@sp", txtMaLinhKien.Text)
            };
            if (Data.Excute(query, args))
            {
                emptyText();
                dgvSanPham_Load();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn chắc chắn muốn xoá sản linh kiện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.No)
            {
                return;
            }
            if (String.IsNullOrEmpty(txtTenLinhKien.Text) || pictureLinhKien.BackgroundImage == null || String.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Chưa chọn linh kiện để xoá");
                return;
            }
            if (Data.Excute("delete from chitietphieunhap where id_sanpham = @sp ", new SqlParameter("@sp", txtMaLinhKien.Text))
                && Data.Excute("delete from chitietphieuxuat where id_sanpham = @sp ", new SqlParameter("@sp", txtMaLinhKien.Text))
                && Data.Excute("delete from sanpham where id_sanpham = @sp ", new SqlParameter("@sp", txtMaLinhKien.Text)))
            {
                emptyText();
                dgvSanPham_Load();
            }
        }

        private void cboThuongHieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvSanPham_Load();
        }

    }
}
