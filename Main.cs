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
    public partial class Main : Form
    {
        public string mode;
        public string id;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        // Кнопка "Выход".
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Кнопка "Войти в другой профиль".
        private void relog_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Кнопка "Пользователи".
        private void workers_btn_Click(object sender, EventArgs e)
        {
            Workers Win = new Workers(mode);
            Win.Owner = this;
            Win.mode = mode;
            Win.Show();
            this.Hide();
        }

        // Регистрация сотрудников.
        private void vrem_btn_Click(object sender, EventArgs e)
        {
            Registration_List_workers Win = new Registration_List_workers(mode, id);
            Win.Owner = this;
            Win.Show();
            this.Hide();
        }

        // Регистрация посетителей.
        private void button1_Click(object sender, EventArgs e)
        {
            Registration_List_peopels Win = new Registration_List_peopels(mode);
            Win.Owner = this;
            Win.Show();
            this.Hide();
        }
    }
}
