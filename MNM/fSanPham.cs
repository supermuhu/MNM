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

namespace MNM2
{
    public partial class fSanPham : UserControl
    {
        public fSanPham()
        {
            InitializeComponent();
        }

        private void fSanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = Data.GetData("select * from sanpham");
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham.SelectedCells[0].Value == null) return;
            int index = dgvSanPham.SelectedCells[0].RowIndex;
            //MessageBox.Show(Directory.GetCurrentDirectory() + @"\image\" + dgvSanPham.Rows[index].Cells[7].Value);
            //return;
            pictureLinhKien.BackgroundImage = Image.FromFile(Directory.GetCurrentDirectory() + @"\image\" + dgvSanPham.Rows[index].Cells[7].Value);
            //pictureLinhKien.BackgroundImage = 
        }
    }
}
