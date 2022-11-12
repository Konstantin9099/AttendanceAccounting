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
    public partial class Registration_List_workers : Form
    {
        public string ID_w;
        public string Mode;
        public string id;
        public string mode;

        public Registration_List_workers(string mode, string id)
        {
            InitializeComponent();
            label1.Visible = false;
            dateTimePicker1.Value = DateTime.Now;
            fio_work_comboBox.KeyPress += (sender, e) => e.Handled = true;
            if (mode == "Администратор")
            {
                add_work_in_btn.Enabled = true;
                add_work_out_btn.Enabled = true;
                when_in_work_mtb.Enabled = true;
                when_out_work_mtb.Enabled = true;
                del_work_btn.Enabled = true;
                update_time_work_btn.Enabled = true;
                search_btn.Enabled = true;
                fio_work_comboBox.Enabled = true;
                line_search_textBox1.Enabled = true;
                // Время прихода и ухода.
                string query = "select workers.id_list 'Код работника', firstname_wo 'Фамилия', middlename_w 'Имя', lastname_w 'Отчество', name_position as 'Должность', when_in 'Время прихода', when_out 'Время ухода' from workers, list, positions where list.work_id=workers.id_work and workers.position_id=positions.id_position;";
                GetInfo(query);   
                Mode = mode;
            }
            else if (mode == "Пользователь")
            {
                add_work_in_btn.Enabled = false;
                add_work_out_btn.Enabled = false;
                when_in_work_mtb.Enabled = false;
                when_out_work_mtb.Enabled = false;
                del_work_btn.Enabled = false;
                update_time_work_btn.Enabled = false;
                search_btn.Enabled = false;
                fio_work_comboBox.Enabled = false;
                line_search_textBox1.Enabled = false;
                string query = "select workers.id_list 'Код работника', firstname_wo 'Фамилия', middlename_w 'Имя', lastname_w 'Отчество', name_position as 'Должность', when_in 'Время прихода', when_out 'Время ухода' from workers, list, positions where list.work_id=workers.id_work and workers.position_id=positions.id_position and id_work= " + id + ";";
                GetInfo(query);
                ID_w = id;
                Mode = mode;
            }
        }

        private void Registration_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        public void GetInfo(string query)
        {           
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].Width = 100;
                this.dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[2].Width = 100;
                this.dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[3].Width = 100;
                this.dataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[4].Width = 150;
                this.dataGridView1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[5].Width = 150;
                this.dataGridView1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[6].Width = 150;
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

        // Запись когда пришел.
        private void add_work_in_btn_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поле ввода.
            if (fio_work_comboBox.Text.Equals(""))
            {
                MessageBox.Show(
                    "Выберете работника.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (!when_in_work_mtb.MaskFull)
            {
                MessageBox.Show(
                    "Введите время прихода.",
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
                string time = when_in_work_mtb.Text;
                string date_time = date + " " + time;
                string query = "insert into list (work_id, when_in) values ('" + label1.Text + "', '" + date_time + "'); ";
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
                when_in_work_mtb.Clear();
            }
        }

        // Запись когда ушел.
        private void add_work_out_btn_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поле ввода.
            if (fio_work_comboBox.Text.Equals(""))
            {
                MessageBox.Show(
                    "Выберете работника.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (!when_out_work_mtb.MaskFull)
            {
                MessageBox.Show(
                    "Введите время ухода.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                DialogResult res = MessageBox.Show("Работник уходит?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string date = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                string time_out = when_out_work_mtb.Text;
                string date_time_out = date + " " + time_out;
                string query = "insert into list (work_id, when_out) values ('" + label1.Text + "', '" + date_time_out + "'); ";
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
                when_out_work_mtb.Clear();
            }
        }

        // Кнопка "Обновить".
        private void update_time_work_btn_Click(object sender, EventArgs e)
        {
            if (Mode == "Администратор")
            {
                string query = "select workers.id_list 'Код работника', firstname_wo 'Фамилия', middlename_w 'Имя', lastname_w 'Отчество', name_position as 'Должность', when_in 'Время прихода', when_out 'Время ухода' from workers, list, positions where list.work_id=workers.id_work and workers.position_id=positions.id_position;";
                GetInfo(query);
            }
            else if (Mode == "Пользователь")
            {
                string query = "select workers.id_list 'Код работника', firstname_wo 'Фамилия', middlename_w 'Имя', lastname_w 'Отчество', name_position as 'Должность', when_in 'Время прихода', when_out 'Время ухода' from workers, list, positions where list.work_id=workers.id_work and workers.position_id=positions.id_position and id_work= " + id + ";";
                GetInfo(query);
            }
        }

        // Кнопка "Сохранить документ".
        private void print_work_btn_Click(object sender, EventArgs e)
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

        // Вывод выпадающего списка в поле "ФИО работника". 
        private void Registration_List_workers_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select id_work, concat (firstname_wo, ' ', middlename_w, ' ', lastname_w) as 'ФИО работника' from workers order by firstname_wo;";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    fio_work_comboBox.Items.Add(reader.GetString("ФИО работника"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Определяем id работника.
        private void fio_work_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_work = fio_work_comboBox.Text;
            try
            {
                string ID_work = "select id_work from workers where firstname_wo =(SUBSTRING_INDEX('" + id_work + "', ' ', 1));";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(ID_work, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(ID_work, conn);
                label1.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Кнопка "Поиск" в списке регистрации времени прихода и ухода работников.
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
                string query = " select workers.id_list 'Код работника', firstname_wo as 'Фамилия', middlename_w as 'Имя', lastname_w as 'Отчество', name_position as 'Должность', when_in as 'Время прихода', when_out as 'Время ухода' from list INNER JOIN workers ON list.work_id=workers.id_work INNER JOIN positions ON workers.position_id=positions.id_position where workers.firstname_wo like '%" + line_search_textBox1.Text + "%' or workers.middlename_w like '%" + line_search_textBox1.Text + "%' or workers.lastname_w like '%" + line_search_textBox1.Text + "%' or positions.name_position like '%" + line_search_textBox1.Text + "%' or list.when_in like '%" + line_search_textBox1.Text + "%' or list.when_out like '%" + line_search_textBox1.Text + "%';";
                GetInfo(query);
            }
            line_search_textBox1.Clear();
        }

        // Кнопка "Удалить запись".
        private void del_work_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null)
            {
                MessageBox.Show("Не выбрана строка!");
                return;
            }
            DialogResult res = MessageBox.Show($"Вы уверены, что хотите удалить выделенную запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int n = Int32.Parse(label1.Text);
                string day_in = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                string del_in = "delete from list where  work_id = '" + n + "' and when_in= '" + day_in + "';";
                Action(del_in);
                string day_out = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                string del_out = "delete from list where  work_id = '" + n + "' and when_out= '" + day_out + "';";
                Action(del_out);
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Удаление невозможно.");
            }
        }

        // Вывод ФИО работников из таблицы в comboBox.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fio_work_comboBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.fio_work_comboBox.ForeColor = System.Drawing.Color.Blue;
        }
    }
}
