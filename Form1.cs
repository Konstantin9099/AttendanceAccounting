using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AttendanceAccounting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Кнопка "Выход".
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Кнопка "Вход".
        private void log_btn_Click(object sender, EventArgs e)
        {
            if (log_box.Text != "" && pass_box.Text != "")
            {
                string mod = "";
                string id = "";
                string query = "select id_login, mode from login where login ='" + log_box.Text + "' and password = '" + pass_box.Text + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                cmDB.CommandTimeout = 60;
                try
                {
                    conn.Open();
                    MySqlDataReader rd = cmDB.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            id = rd.GetString(0);
                            mod = rd.GetString(1);
                        }
                    }
                    conn.Close();
                    log_box.Clear();
                    pass_box.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка авторизации. Попробуйте еще раз.");
                    MessageBox.Show(ex.Message);
                }
                if (id != "")
                {
                    if (mod == "Администратор")
                    {
                        Main Win = new Main();
                        Win.Owner = this;
                        Win.mode = "Администратор";
                        Win.id = id;
                        Win.Show();
                        log_box.Text = "";
                        pass_box.Text = "";
                        this.Hide();
                    }
                    else if (mod == "Пользователь")
                    {
                        Main Win = new Main();
                        Win.Owner = this;
                        Win.mode = "Пользователь";
                        Win.id = id;
                        Win.Show();
                        log_box.Text = "";
                        pass_box.Text = "";
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Введенные данные не верны!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
