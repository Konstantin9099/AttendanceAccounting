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
using Word = Microsoft.Office.Interop.Word;

namespace AttendanceAccounting
{
    public partial class Registration_List_peopels : Form
    {
        public string Mode;
        public string mode;

        public Registration_List_peopels(string mode)
        {
            InitializeComponent();
            label6.Visible = false;
            status_pip_cmb.KeyPress += (sender, e) => e.Handled = true;
            dateTimePicker1.Value = DateTime.Now;

            if (mode == "Администратор")
            {
                add_pip_in_btn.Enabled = true;
                add_pip_out_btn.Enabled = true;
                when_in_pip_mtb.Enabled = true;
                when_out_pip_mtb.Enabled = true;
                line_search_textBox1.Enabled = true;
                search_btn.Enabled = true;
                del_pip_btn.Enabled = true;
                update_time_pip_btn.Enabled = true;
                print_pip_btn.Enabled = true;
                firstname_pip_box.Enabled = true;
                middlename_pip_box.Enabled = true;
                lastname_pip_box.Enabled = true;
                status_pip_cmb.Enabled = true;
                string query = "select id_peoples as 'Код посетителя', firstname_p as 'Фамилия', middlename_p as 'Имя', lastname_p 'Отчество',  name_status as 'Статус',  when_in as 'Время прихода', when_out as 'Время ухода' from list INNER JOIN peoples ON list.peoples_id=peoples.id_peoples INNER JOIN status ON peoples.status_id=status.id_status;";
                GetInfo(query);
                Mode = mode;
            }
            else if (mode == "Пользователь")
            {
                add_pip_in_btn.Enabled = false;
                del_pip_btn.Enabled = false;
                when_in_pip_mtb.Enabled = false;
                when_out_pip_mtb.Enabled = false;
                line_search_textBox1.Enabled = false;
                search_btn.Enabled = false;
                del_pip_btn.Enabled = false;
                update_time_pip_btn.Enabled = false;
                print_pip_btn.Enabled = false;
                firstname_pip_box.Enabled = false;
                middlename_pip_box.Enabled = false;
                lastname_pip_box.Enabled = false;
                status_pip_cmb.Enabled = false;
                string query = "select id_peoples as 'Код посетителя', firstname_p as 'Фамилия', middlename_p as 'Имя', lastname_p 'Отчество',  name_status as 'Статус',  when_in as 'Время прихода', when_out as 'Время ухода' from list INNER JOIN peoples ON list.peoples_id=peoples.id_peoples INNER JOIN status ON peoples.status_id=status.id_status;";
                GetInfo(query);
                Mode = mode;
            }
        }

        private void Registration_List_peopels_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        public void GetInfo(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter ada = new MySqlDataAdapter(query, conn);
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                ada.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].Width = 100;
                this.dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].Width = 100;
                this.dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].Width = 110;
                this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].Width = 160;
                this.dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[5].Width = 130;
                this.dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[6].Width = 130;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ClearSelection();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла непредвиденная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                firstname_pip_box.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.firstname_pip_box.ForeColor = System.Drawing.Color.Blue;
                middlename_pip_box.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.middlename_pip_box.ForeColor = System.Drawing.Color.Blue;
                lastname_pip_box.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.lastname_pip_box.ForeColor = System.Drawing.Color.Blue;
                status_pip_cmb.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                this.status_pip_cmb.ForeColor = System.Drawing.Color.Blue;
            }
        }

        // Запись когда пришел.
        private void add_pip_in_btn_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поле ввода.
            if (firstname_pip_box.Text.Equals("") || middlename_pip_box.Text.Equals("") || lastname_pip_box.Text.Equals(""))
            {
                MessageBox.Show(
                    "Введите ФИО посетителя.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (status_pip_cmb.Text == "")
            {
                MessageBox.Show(
                    "Выберете статус.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (!when_in_pip_mtb.MaskFull)
            {
                MessageBox.Show(
                    "Введите время.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                DialogResult res = MessageBox.Show("Добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string date = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                    string time = when_in_pip_mtb.Text;
                    string date_time = date + " " + time;
                    string query = "insert into peoples (firstname_p, middlename_p, lastname_p, status_id) values ('" + firstname_pip_box.Text + "', '" + middlename_pip_box.Text + "', '" + lastname_pip_box.Text + "', '" + label6.Text + "'); insert into list values(null, (select max(id_peoples) from peoples), null, '" + date_time + "', null); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        Action(query);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Поля ввода не могут быть пустыми!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            when_in_pip_mtb.Clear();
        }

        // Запись когда ушел.
        private void add_pip_out_btn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string date_out = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                string time_out = when_out_pip_mtb.Text;
                string date_time_out = date_out + " " + time_out;
                int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string query = "insert into list (peoples_id, when_out) values ('" + n + "', '" + date_time_out + "'); ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    Action(query);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Поля ввода не могут быть пустыми!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            when_in_pip_mtb.Clear();

        }

        // Кнопка "Обновить".
        private void update_time_pip_btn_Click(object sender, EventArgs e)
        {
            if (Mode == "Администратор")
            {
                string query = "select id_peoples as 'Код посетителя', firstname_p as 'Фамилия', middlename_p as 'Имя', lastname_p 'Отчество',  name_status as 'Статус',  when_in as 'Время прихода', when_out as 'Время ухода' from list INNER JOIN peoples ON list.peoples_id=peoples.id_peoples INNER JOIN status ON peoples.status_id=status.id_status;";
                GetInfo(query);
            }
            else if (Mode == "Пользователь")
            {
                string query = "select id_peoples as 'Код посетителя', firstname_p as 'Фамилия', middlename_p as 'Имя', lastname_p 'Отчество',  name_status as 'Статус',  when_in as 'Время прихода', when_out as 'Время ухода' from list INNER JOIN peoples ON list.peoples_id=peoples.id_peoples INNER JOIN status ON peoples.status_id=status.id_status;";
                GetInfo(query);
            }
        }

        // Кнопка "Сохранить документ".
        private void print_pip_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Word._Application app = new Word.Application();
                app.Visible = true;
                var doc = app.Documents.Add();
                var title = doc.Content.Paragraphs.Add();
                title.Range.Text = "Время прихода и ухода сотрудников";
                title.Range.Font.Name = "Arial Narrow";
                title.Range.Font.Size = 14;
                //title.Range.Font.Color = Word.WdColor.wdColorBlue;
                object objMissing = System.Reflection.Missing.Value;
                Word.Table table = doc.Tables.Add(doc.Bookmarks.get_Item("\\endofdoc").Range, dataGridView1.RowCount, dataGridView1.ColumnCount, ref objMissing, ref objMissing);
                table.Range.Paragraphs.SpaceAfter = 8;
                table.Range.Font.Name = "Arial Narrow";
                table.Range.Font.Size = 12;
                // Заполнение ячеек таблицы.
                for (int i = 1; i < dataGridView1.RowCount; i++)
                    for (int j = 1; j <= dataGridView1.ColumnCount; j++)
                    {
                        var cell = dataGridView1.Rows[i - 1].Cells[j - 1];
                        table.Cell(i, j).Range.Text = cell.Value.ToString();
                    }
                table.Borders.Enable = 1;
                table.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка!");
                MessageBox.Show(ex.Message);
            }
        }

        // Вывод выпадающего списка в поле "Статус посетителя". 
        private void Registration_List_peopels_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select name_status from status;";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    status_pip_cmb.Items.Add(reader.GetString("name_status"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void status_pip_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id_type = "SELECT id_status FROM status where name_status='" + status_pip_cmb.Text + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(id_type, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(id_type, conn);
                label6.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Кнопка "Поиск".
        private void search_btn_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (line_search_textBox1.Text == null || line_search_textBox1.Text == "")
                MessageBox.Show(
                    "Вы не ввели запрос в строке поиска!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                string query = "select id_peoples as 'Код посетителя', firstname_p as 'Фамилия', middlename_p as 'Имя', lastname_p 'Отчество',  name_status as 'Статус',  when_in as 'Время прихода', when_out as 'Время ухода' from list INNER JOIN peoples ON list.peoples_id=peoples.id_peoples INNER JOIN status ON peoples.status_id=status.id_status where peoples.firstname_p like '%" + line_search_textBox1.Text + "%' or peoples.middlename_p like '%" + line_search_textBox1.Text + "%' or peoples.lastname_p like '%" + line_search_textBox1.Text + "%' or status.name_status like '%" + line_search_textBox1.Text + "%' or list.when_in like '%" + line_search_textBox1.Text + "%' or list.when_out like '%" + line_search_textBox1.Text + "%';";             
                GetInfo(query);
            }
            line_search_textBox1.Clear();
        }

        // Кнопка "Удалить".
        private void del_pip_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null)
            {
                MessageBox.Show("Не выбрана строка!");
                return;
            }
            DialogResult res = MessageBox.Show($"Вы уверены, что хотите удалить выделенную запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string n = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string day_in = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string del_in = "delete from list where peoples_id = '" + n + "' and when_in= '" + day_in + "';";
                Action(del_in);
                string day_out = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                string del_out = "delete from list where peoples_id = '" + n + "' and when_out= '" + day_out + "';";
                Action(del_out);
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Удаление невозможно.");
            }
        }
    }
}
