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
    public partial class Workers : Form
    {
        public string mode;
        public Workers(string mode)
        {
            InitializeComponent();
            positions_box.KeyPress += (sender, e) => e.Handled = true;
            mode_box.KeyPress += (sender, e) => e.Handled = true;
            string query = "select workers.id_work as '№ п/п', workers.firstname_wo as 'Фамилия', workers.middlename_w as 'Имя', workers.lastname_w as 'Отчество', positions.name_position as 'Должность', login.login as 'Логин', login.password as 'Пароль', login.mode as 'Статус' from login join workers on login.id_login=workers.login_id join positions on workers.position_id=positions.id_position order by id_login; ";
            GetInfo(query);
            if (mode == "Администратор")
            {
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.ReadOnly = false;
                firstname_box.Enabled = true;
                middlename_box.Enabled = true;
                lastname_box.Enabled = true;
                login_box.Enabled = true;
                pass_box.Enabled = true;
                positions_box.Enabled = true;
                mode_box.Enabled = true;
                add_btn.Enabled = true;
                del_btn.Enabled = true;
                chng_btn.Enabled = true;
            }
            else if (mode == "Пользователь")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.ReadOnly = true;
                firstname_box.Enabled = false;
                middlename_box.Enabled = false;
                lastname_box.Enabled = false;
                login_box.Enabled = false;
                pass_box.Enabled = false;
                positions_box.Enabled = false;
                mode_box.Enabled = false;
                add_btn.Enabled = false;
                del_btn.Enabled = false;
                chng_btn.Enabled = false;
            }
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

        private void Workers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        // Вывод выпадающего списка с должностями.
        private void Workers_Load(object sender, EventArgs e)
        {
            // Список - Должности.
            try
            {
                string query = "SELECT * FROM  positions order by name_position;";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    positions_box.Items.Add(reader.GetString("name_position"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Вывод данных в текстовые поля.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                firstname_box.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.firstname_box.ForeColor = System.Drawing.Color.Blue;
                middlename_box.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.middlename_box.ForeColor = System.Drawing.Color.Blue;
                lastname_box.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.lastname_box.ForeColor = System.Drawing.Color.Blue;
                positions_box.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                this.positions_box.ForeColor = System.Drawing.Color.Blue;
                login_box.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                this.login_box.ForeColor = System.Drawing.Color.Blue;
                pass_box.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                this.pass_box.ForeColor = System.Drawing.Color.Blue;
                mode_box.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                this.mode_box.ForeColor = System.Drawing.Color.Blue;
            }
        }

        // Кнопка "Добавить".
        private void add_btn_Click(object sender, EventArgs e)
        {
            string query = "insert into login values((select max(login_id) + 1 from workers), '" + login_box.Text + "', '" + pass_box.Text + "', '" + mode_box.Text + "');insert into workers values((select max(id_login) from login), '" + firstname_box.Text + "', '" + middlename_box.Text + "', '" + lastname_box.Text + "', '" + label_id_position.Text + "', (select max(id_login) from login), (select max(id_login) from login));";
            Action(query);
            query = "select workers.id_work as '№ п/п', workers.firstname_wo as 'Фамилия', workers.middlename_w as 'Имя', workers.lastname_w as 'Отчество', positions.name_position as 'Должность', login.login as 'Логин', login.password as 'Пароль', login.mode as 'Статус' from login join workers on login.id_login=workers.login_id join positions on workers.position_id=positions.id_position order by id_login;";
            GetInfo(query);
            if (mode == "Администратор")
            {
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.ReadOnly = false;
            }
            else if (mode == "Пользователь")
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.ReadOnly = true;
            }
        }

        // Получем id должности из выпадающего списка positions_box.
        private void positions_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string positions_id = "SELECT id_position FROM positions where name_position='" + positions_box.Text + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(positions_id, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(positions_id, conn);
                label_id_position.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Кнопка "Удалить".
        private void del_btn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены что хотите удалить пользователя?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow != null)
                {

                    int id_l = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string query = "delete from list where id_list = (select id_list from workers where id_work = " + id_l + "); delete from workers where id_work = " + id_l + "; delete from login where login = '" + dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString() + "' and password = '" + dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString() + "';";
                    Action(query);
                    query = "select workers.id_work as '№ п/п', workers.firstname_wo as 'Фамилия', workers.middlename_w as 'Имя', workers.lastname_w as 'Отчество', positions.name_position as 'Должность', login.login as 'Логин', login.password as 'Пароль', login.mode as 'Статус' from login join workers on login.id_login=workers.login_id join positions on workers.position_id=positions.id_position order by id_login;";
                    GetInfo(query);
                    if (mode == "Администратор")
                    {
                        dataGridView1.Columns[5].Visible = true;
                        dataGridView1.Columns[6].Visible = true;
                        dataGridView1.ReadOnly = false;
                    }
                    else if (mode == "Пользователь")
                    {
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.ReadOnly = true;
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали данные для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            firstname_box.Clear();
            middlename_box.Clear();
            lastname_box.Clear();
            login_box.Clear();
            pass_box.Clear();
            positions_box.SelectedIndex = 0;
            mode_box.SelectedIndex = 0;
        }

        // Кнопка "Изменить".
        private void chng_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id_w = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                string query = "update workers set firstname_wo = '" + firstname_box.Text + "', middlename_w = '" + middlename_box.Text + "', lastname_w = '" + lastname_box.Text + "', position_id = '" + label_id_position.Text + "' where id_work = " + id_w + "; update login set login = '" + login_box.Text + "', password = '" + pass_box.Text + "', mode = '" + mode_box.Text + "' where id_login = (select login_id from workers where id_work = " + id_w + "); ";
                Action(query);
                query = "select workers.id_work as '№ п/п', workers.firstname_wo as 'Фамилия', workers.middlename_w as 'Имя', workers.lastname_w as 'Отчество', positions.name_position as 'Должность', login.login as 'Логин', login.password as 'Пароль', login.mode as 'Статус' from login join workers on login.id_login=workers.login_id join positions on workers.position_id=positions.id_position order by id_login;";
                GetInfo(query);
                if (mode == "Администратор")
                {
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.ReadOnly = false;
                }
                else if (mode == "Пользователь")
                {
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.ReadOnly = true;
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали данные для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Печать".
        private void print_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Word._Application app = new Word.Application();
                app.Visible = true;
                var doc = app.Documents.Add();
                var title = doc.Content.Paragraphs.Add();
                title.Range.Text = "Список пользователей";
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
    }
}
