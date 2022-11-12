
namespace AttendanceAccounting
{
    partial class Workers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mode_box = new System.Windows.Forms.ComboBox();
            this.positions_box = new System.Windows.Forms.ComboBox();
            this.pass_box = new System.Windows.Forms.TextBox();
            this.login_box = new System.Windows.Forms.TextBox();
            this.firstname_box = new System.Windows.Forms.TextBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.print_btn = new System.Windows.Forms.Button();
            this.chng_btn = new System.Windows.Forms.Button();
            this.del_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.middlename_box = new System.Windows.Forms.TextBox();
            this.lastname_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_id_position = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mode_box
            // 
            this.mode_box.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.mode_box.FormattingEnabled = true;
            this.mode_box.Items.AddRange(new object[] {
            "Администратор",
            "Пользователь"});
            this.mode_box.Location = new System.Drawing.Point(312, 507);
            this.mode_box.Margin = new System.Windows.Forms.Padding(4);
            this.mode_box.Name = "mode_box";
            this.mode_box.Size = new System.Drawing.Size(217, 31);
            this.mode_box.TabIndex = 15;
            // 
            // positions_box
            // 
            this.positions_box.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.positions_box.FormattingEnabled = true;
            this.positions_box.Location = new System.Drawing.Point(312, 449);
            this.positions_box.Margin = new System.Windows.Forms.Padding(4);
            this.positions_box.Name = "positions_box";
            this.positions_box.Size = new System.Drawing.Size(217, 31);
            this.positions_box.TabIndex = 14;
            this.positions_box.SelectedIndexChanged += new System.EventHandler(this.positions_box_SelectedIndexChanged);
            // 
            // pass_box
            // 
            this.pass_box.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.pass_box.Location = new System.Drawing.Point(552, 508);
            this.pass_box.Margin = new System.Windows.Forms.Padding(4);
            this.pass_box.MaxLength = 25;
            this.pass_box.Name = "pass_box";
            this.pass_box.Size = new System.Drawing.Size(132, 30);
            this.pass_box.TabIndex = 13;
            // 
            // login_box
            // 
            this.login_box.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.login_box.Location = new System.Drawing.Point(552, 450);
            this.login_box.Margin = new System.Windows.Forms.Padding(4);
            this.login_box.MaxLength = 25;
            this.login_box.Name = "login_box";
            this.login_box.Size = new System.Drawing.Size(132, 30);
            this.login_box.TabIndex = 12;
            // 
            // firstname_box
            // 
            this.firstname_box.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.firstname_box.Location = new System.Drawing.Point(13, 448);
            this.firstname_box.Margin = new System.Windows.Forms.Padding(4);
            this.firstname_box.MaxLength = 60;
            this.firstname_box.Name = "firstname_box";
            this.firstname_box.Size = new System.Drawing.Size(276, 30);
            this.firstname_box.TabIndex = 11;
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.Color.Red;
            this.add_btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.add_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_btn.ForeColor = System.Drawing.Color.White;
            this.add_btn.Location = new System.Drawing.Point(745, 440);
            this.add_btn.Margin = new System.Windows.Forms.Padding(4);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(132, 40);
            this.add_btn.TabIndex = 16;
            this.add_btn.Text = "Добавить";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // print_btn
            // 
            this.print_btn.BackColor = System.Drawing.Color.Red;
            this.print_btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.print_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.print_btn.ForeColor = System.Drawing.Color.White;
            this.print_btn.Location = new System.Drawing.Point(552, 561);
            this.print_btn.Margin = new System.Windows.Forms.Padding(4);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(132, 40);
            this.print_btn.TabIndex = 19;
            this.print_btn.Text = "Печать";
            this.print_btn.UseVisualStyleBackColor = false;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // chng_btn
            // 
            this.chng_btn.BackColor = System.Drawing.Color.Red;
            this.chng_btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.chng_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chng_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chng_btn.ForeColor = System.Drawing.Color.White;
            this.chng_btn.Location = new System.Drawing.Point(746, 561);
            this.chng_btn.Margin = new System.Windows.Forms.Padding(4);
            this.chng_btn.Name = "chng_btn";
            this.chng_btn.Size = new System.Drawing.Size(131, 40);
            this.chng_btn.TabIndex = 17;
            this.chng_btn.Text = "Изменить";
            this.chng_btn.UseVisualStyleBackColor = false;
            this.chng_btn.Click += new System.EventHandler(this.chng_btn_Click);
            // 
            // del_btn
            // 
            this.del_btn.BackColor = System.Drawing.Color.Red;
            this.del_btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.del_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.del_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.del_btn.ForeColor = System.Drawing.Color.White;
            this.del_btn.Location = new System.Drawing.Point(746, 498);
            this.del_btn.Margin = new System.Windows.Forms.Padding(4);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(131, 40);
            this.del_btn.TabIndex = 18;
            this.del_btn.Text = "Удалить";
            this.del_btn.UseVisualStyleBackColor = false;
            this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(866, 397);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // middlename_box
            // 
            this.middlename_box.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.middlename_box.Location = new System.Drawing.Point(13, 506);
            this.middlename_box.Margin = new System.Windows.Forms.Padding(4);
            this.middlename_box.MaxLength = 60;
            this.middlename_box.Name = "middlename_box";
            this.middlename_box.Size = new System.Drawing.Size(276, 30);
            this.middlename_box.TabIndex = 21;
            // 
            // lastname_box
            // 
            this.lastname_box.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.lastname_box.Location = new System.Drawing.Point(13, 561);
            this.lastname_box.Margin = new System.Windows.Forms.Padding(4);
            this.lastname_box.MaxLength = 60;
            this.lastname_box.Name = "lastname_box";
            this.lastname_box.Size = new System.Drawing.Size(276, 30);
            this.lastname_box.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(15, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Фамилия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(15, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Имя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(15, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Отчество:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(548, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Логин:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(548, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Пароль:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(308, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "Должность:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(308, 483);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Статус:";
            // 
            // label_id_position
            // 
            this.label_id_position.AutoSize = true;
            this.label_id_position.Location = new System.Drawing.Point(453, 425);
            this.label_id_position.Name = "label_id_position";
            this.label_id_position.Size = new System.Drawing.Size(76, 17);
            this.label_id_position.TabIndex = 30;
            this.label_id_position.Text = "id_position";
            this.label_id_position.Visible = false;
            // 
            // Workers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(893, 624);
            this.Controls.Add(this.label_id_position);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastname_box);
            this.Controls.Add(this.middlename_box);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mode_box);
            this.Controls.Add(this.positions_box);
            this.Controls.Add(this.pass_box);
            this.Controls.Add(this.login_box);
            this.Controls.Add(this.firstname_box);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.chng_btn);
            this.Controls.Add(this.del_btn);
            this.MaximizeBox = false;
            this.Name = "Workers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Работники";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Workers_FormClosing);
            this.Load += new System.EventHandler(this.Workers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mode_box;
        private System.Windows.Forms.ComboBox positions_box;
        private System.Windows.Forms.TextBox pass_box;
        private System.Windows.Forms.TextBox login_box;
        private System.Windows.Forms.TextBox firstname_box;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button chng_btn;
        private System.Windows.Forms.Button del_btn;
        private System.Windows.Forms.TextBox middlename_box;
        private System.Windows.Forms.TextBox lastname_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_id_position;
    }
}