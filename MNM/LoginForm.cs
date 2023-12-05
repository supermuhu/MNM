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
using BCrypt.Net;

namespace MNM2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
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

        private string Username;
        private string Password;
       
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {

            using (SqlConnection Conn = new SqlConnection(Data.GetStringConnection()))
            {
                Conn.Open();
                Username = txtUsername.Text;
                Password = txtPassword.Text;
                string hashedPassword = PasswordHasher.HashPassword(Password);
                
                string query = "SELECT * FROM taikhoan WHERE tk = @Username";
                using (SqlCommand cmd = new SqlCommand(query, Conn))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHashedPassword = reader["pass"].ToString();
                            bool verifyPassword = PasswordHasher.VerifyPassword(Password, storedHashedPassword);

                            if (verifyPassword)
                            {
                                Form1 f = new Form1(Username);
                                this.Hide();
                                f.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                                txtUsername.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản không tồn tại");
                            txtUsername.Focus();
                        }
                    
                       
                    }
                    
                }

            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
    }
}
