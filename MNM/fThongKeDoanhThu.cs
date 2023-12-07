using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
           
        }

        private void cbxthang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private  void dgvhangnhap_load()
        {
            dgvhangnhap.DataSource = Data.GetData("select (chitietphieunhap.id_phieunhap) AS maphieunhap,tensanpham,tongtien,ngaynhap from chitietphieunhap inner join phieunhap on chitietphieunhap.id_phieunhap=phieunhap.id_phieunhap inner join sanpham on sanpham.id_sanpham = chitietphieunhap.id_sanpham");
            dgvhangnhap.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvhangnhap.Columns[1].HeaderText = "Tên tên sản phẩm";
            dgvhangnhap.Columns[2].HeaderText = "Tổng tiền";
            dgvhangnhap.Columns[3].HeaderText = "Ngày nhập";
        }
        private void fThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            dgvhangnhap_load();
        }

        private void dgvhangnhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
