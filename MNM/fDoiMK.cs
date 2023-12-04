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
using System.Xml;
using System.Xml.Linq;
using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MNM2
{
    public partial class fDoiMK : UserControl
    {
        string Username;
        public fDoiMK()
        {
            InitializeComponent();
        }
        public fDoiMK(string User)
        {
            InitializeComponent();
            Username = User;
        }


        private string ntk;
        private string nmk;


        public class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }

            public static bool VerifyPassword(string password, string hashedPassword)
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(Data.GetStringConnection()))
            {
                Conn.Open();

                string query = "SELECT * FROM taikhoan WHERE tk = @Username";

                using (SqlCommand cmd = new SqlCommand(query, Conn))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHashedPassword = reader["pass"].ToString();
                            bool verifyPassword = PasswordHasher.VerifyPassword(txtOldPass.Text, storedHashedPassword);
                            if (txtNewPass1.Text == txtNewPass2.Text)
                            {
                                if (verifyPassword)
                                {
                                    string newHashedPassword = PasswordHasher.HashPassword(txtNewPass1.Text);
                                    if (Data.Excute("UPDATE taikhoan SET pass = @NewMK Where tk = @Username",
                                    new SqlParameter("@NewMK", newHashedPassword),
                                    new SqlParameter("@Username", Username)))
                                    {
                                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                                        txtNewPass1.Clear();
                                        txtNewPass2.Clear();
                                        txtOldPass.Clear();
                                        txtOldPass.Focus();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Đổi mật khẩu thất bại!", "Thông báo");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Nhập sai mật khẩu cũ!Mời nhập lại", "Thông báo");
                                    txtNewPass1.Clear();
                                    txtNewPass2.Clear();
                                    txtOldPass.Clear();
                                    txtOldPass.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Hai mật khẩu không trùng khớp!Mời nhập lại", "Thông báo");
                                txtNewPass1.Clear();
                                txtNewPass2.Clear();
                                txtOldPass.Focus();
                            }
                        }


                    }

                }

            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ntk = txtNewUser.Text;
            nmk = txtNewPassUser1.Text;
            if(nmk == txtNewPassUser2.Text)
            {
                string hashedPassword = PasswordHasher.HashPassword(nmk);

                if (Data.Excute("INSERT INTO taikhoan VALUES(@NewTK,@NewMK,@ngaytao,@ngaycapnhat)", 
                    new SqlParameter("@NewTK", ntk),
                    new SqlParameter("@NewMK", hashedPassword),
                    new SqlParameter("@ngaytao", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                    new SqlParameter("@ngaycapnhat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))))
                {

                    MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo");
                    txtNewUser.Clear();
                    txtNewPassUser2.Clear();
                    txtNewPassUser1.Clear();
                    dgvTaiKhoan_Load();
                }
            }
        }

        private void dgvTaiKhoan_Load()
        {
            dgvTaiKhoan.DataSource = Data.GetData("select tk,ngaytao,ngaycapnhat from taikhoan");
            dgvTaiKhoan.Columns[0].HeaderText = "Tài khoản";
            dgvTaiKhoan.Columns[1].HeaderText = "Ngày tạo";
            dgvTaiKhoan.Columns[2].HeaderText = "Ngày cập nhật";
            dgvTaiKhoan.Columns[1].Width = 130;
            dgvTaiKhoan.Columns[2].Width = 130;

        }
        private void fDoiMK_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan_Load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index;
            DialogResult a = MessageBox.Show("Bạn chắc chắn muốn xoá tài khoản", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.No)
            {
                return;
            }
            if (dgvTaiKhoan.Rows.Count == 0 || dgvTaiKhoan.SelectedCells[0].Value == null)
            {
                MessageBox.Show("Chưa chọn tài khoản để xoá");
                return;
            }
            else
            {
                index = dgvTaiKhoan.SelectedCells[0].RowIndex;
            }
                if (Data.Excute("delete from taikhoan where tk = @ExistTk", new SqlParameter("@ExistTk", dgvTaiKhoan.Rows[index].Cells[0].Value.ToString())))
                {
                dgvTaiKhoan_Load();
                }
            
        }

     
    }
}
