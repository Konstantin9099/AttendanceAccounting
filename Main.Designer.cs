
namespace AttendanceAccounting
{
    partial class Main
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
            this.vrem_btn = new System.Windows.Forms.Button();
            this.workers_btn = new System.Windows.Forms.Button();
            this.relog = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vrem_btn
            // 
            this.vrem_btn.BackColor = System.Drawing.Color.Red;
            this.vrem_btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.vrem_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vrem_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vrem_btn.ForeColor = System.Drawing.Color.White;
            this.vrem_btn.Location = new System.Drawing.Point(81, 26);
            this.vrem_btn.Margin = new System.Windows.Forms.Padding(4);
            this.vrem_btn.Name = "vrem_btn";
            this.vrem_btn.Size = new System.Drawing.Size(400, 60);
            this.vrem_btn.TabIndex = 5;
            this.vrem_btn.Text = "Регистрация работников";
            this.vrem_btn.UseVisualStyleBackColor = false;
            this.vrem_btn.Click += new System.EventHandler(this.vrem_btn_Click);
            // 
            // workers_btn
            // 
            this.workers_btn.BackColor = System.Drawing.Color.Red;
            this.workers_btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.workers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workers_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.workers_btn.ForeColor = System.Drawing.Color.White;
            this.workers_btn.Location = new System.Drawing.Point(81, 186);
            this.workers_btn.Margin = new System.Windows.Forms.Padding(4);
            this.workers_btn.Name = "workers_btn";
            this.workers_btn.Size = new System.Drawing.Size(400, 60);
            this.workers_btn.TabIndex = 6;
            this.workers_btn.Text = "Пользователи";
            this.workers_btn.UseVisualStyleBackColor = false;
            this.workers_btn.Click += new System.EventHandler(this.workers_btn_Click);
            // 
            // relog
            // 
            this.relog.BackColor = System.Drawing.Color.Red;
            this.relog.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.relog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.relog.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.relog.ForeColor = System.Drawing.Color.White;
            this.relog.Location = new System.Drawing.Point(81, 266);
            this.relog.Margin = new System.Windows.Forms.Padding(4);
            this.relog.Name = "relog";
            this.relog.Size = new System.Drawing.Size(400, 60);
            this.relog.TabIndex = 7;
            this.relog.Text = "Войти в другой профиль";
            this.relog.UseVisualStyleBackColor = false;
            this.relog.Click += new System.EventHandler(this.relog_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.Red;
            this.exit_btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_btn.ForeColor = System.Drawing.Color.White;
            this.exit_btn.Location = new System.Drawing.Point(81, 346);
            this.exit_btn.Margin = new System.Windows.Forms.Padding(4);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(400, 60);
            this.exit_btn.TabIndex = 8;
            this.exit_btn.Text = "Выход";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(81, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(400, 60);
            this.button1.TabIndex = 9;
            this.button1.Text = "Регистрация посетителей";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(563, 422);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vrem_btn);
            this.Controls.Add(this.workers_btn);
            this.Controls.Add(this.relog);
            this.Controls.Add(this.exit_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учета посещаемости на предприятии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button vrem_btn;
        private System.Windows.Forms.Button workers_btn;
        private System.Windows.Forms.Button relog;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button button1;
    }
}