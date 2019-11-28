namespace AutoUpdater
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.COMStop = new System.Windows.Forms.Button();
            this.COMStart = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Bright = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ColumsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TableNameTextBox = new System.Windows.Forms.TextBox();
            this.ViewDB = new System.Windows.Forms.Button();
            this.PrintDB = new System.Windows.Forms.Button();
            this.TruncateDB = new System.Windows.Forms.Button();
            this.InsertTextBox = new System.Windows.Forms.TextBox();
            this.InsertDB = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.DeleteDB = new System.Windows.Forms.Button();
            this.CreateDB = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.GoSetting = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.GoSetting);
            this.panel1.Controls.Add(this.COMStop);
            this.panel1.Controls.Add(this.COMStart);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.Bright);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ColumsTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TableNameTextBox);
            this.panel1.Controls.Add(this.ViewDB);
            this.panel1.Controls.Add(this.PrintDB);
            this.panel1.Controls.Add(this.TruncateDB);
            this.panel1.Controls.Add(this.InsertTextBox);
            this.panel1.Controls.Add(this.InsertDB);
            this.panel1.Controls.Add(this.Restart);
            this.panel1.Controls.Add(this.DeleteDB);
            this.panel1.Controls.Add(this.CreateDB);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 600);
            // 
            // COMStop
            // 
            this.COMStop.Location = new System.Drawing.Point(498, 418);
            this.COMStop.Name = "COMStop";
            this.COMStop.Size = new System.Drawing.Size(297, 36);
            this.COMStop.TabIndex = 20;
            this.COMStop.Text = "Init Stop";
            this.COMStop.Click += new System.EventHandler(this.COMStop_Click);
            // 
            // COMStart
            // 
            this.COMStart.Location = new System.Drawing.Point(498, 372);
            this.COMStart.Name = "COMStart";
            this.COMStart.Size = new System.Drawing.Size(297, 40);
            this.COMStart.TabIndex = 19;
            this.COMStart.Text = "COM4 RS485 Read Holding Register 03 Start";
            this.COMStart.Click += new System.EventHandler(this.COMStart_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(498, 460);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(297, 40);
            this.button3.TabIndex = 18;
            // 
            // Bright
            // 
            this.Bright.Location = new System.Drawing.Point(499, 506);
            this.Bright.Maximum = 100;
            this.Bright.Minimum = 30;
            this.Bright.Name = "Bright";
            this.Bright.Size = new System.Drawing.Size(296, 45);
            this.Bright.TabIndex = 17;
            this.Bright.TickFrequency = 2;
            this.Bright.Value = 55;
            this.Bright.ValueChanged += new System.EventHandler(this.Bright_ValueChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(-16, -39);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(100, 45);
            this.trackBar1.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(502, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.Text = "데이터";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(501, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.Text = "컬럼명";
            // 
            // ColumsTextBox
            // 
            this.ColumsTextBox.Location = new System.Drawing.Point(574, 222);
            this.ColumsTextBox.Name = "ColumsTextBox";
            this.ColumsTextBox.Size = new System.Drawing.Size(221, 23);
            this.ColumsTextBox.TabIndex = 13;
            this.ColumsTextBox.Text = "Adress";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(501, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.Text = "테이블명";
            // 
            // TableNameTextBox
            // 
            this.TableNameTextBox.Location = new System.Drawing.Point(574, 101);
            this.TableNameTextBox.Name = "TableNameTextBox";
            this.TableNameTextBox.Size = new System.Drawing.Size(221, 23);
            this.TableNameTextBox.TabIndex = 11;
            this.TableNameTextBox.Text = "Settings";
            // 
            // ViewDB
            // 
            this.ViewDB.Location = new System.Drawing.Point(499, 130);
            this.ViewDB.Name = "ViewDB";
            this.ViewDB.Size = new System.Drawing.Size(296, 40);
            this.ViewDB.TabIndex = 10;
            this.ViewDB.Text = "테이블 컬럼구조 확인";
            this.ViewDB.Click += new System.EventHandler(this.ViewDB_Click);
            // 
            // PrintDB
            // 
            this.PrintDB.Location = new System.Drawing.Point(499, 326);
            this.PrintDB.Name = "PrintDB";
            this.PrintDB.Size = new System.Drawing.Size(296, 40);
            this.PrintDB.TabIndex = 9;
            this.PrintDB.Text = "테이블 내용출력";
            this.PrintDB.Click += new System.EventHandler(this.PrintDB_Click);
            // 
            // TruncateDB
            // 
            this.TruncateDB.Location = new System.Drawing.Point(499, 280);
            this.TruncateDB.Name = "TruncateDB";
            this.TruncateDB.Size = new System.Drawing.Size(296, 40);
            this.TruncateDB.TabIndex = 8;
            this.TruncateDB.Text = "테이블 비우기";
            this.TruncateDB.Click += new System.EventHandler(this.TruncateDB_Click);
            // 
            // InsertTextBox
            // 
            this.InsertTextBox.Location = new System.Drawing.Point(574, 251);
            this.InsertTextBox.Name = "InsertTextBox";
            this.InsertTextBox.Size = new System.Drawing.Size(221, 23);
            this.InsertTextBox.TabIndex = 7;
            this.InsertTextBox.Text = "Moderntec";
            // 
            // InsertDB
            // 
            this.InsertDB.Location = new System.Drawing.Point(499, 176);
            this.InsertDB.Name = "InsertDB";
            this.InsertDB.Size = new System.Drawing.Size(296, 40);
            this.InsertDB.TabIndex = 6;
            this.InsertDB.Text = "테이블 데이터 삽입";
            this.InsertDB.Click += new System.EventHandler(this.InsertDB_Click);
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(499, 9);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(296, 40);
            this.Restart.TabIndex = 5;
            this.Restart.Text = "프로그램";
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // DeleteDB
            // 
            this.DeleteDB.Location = new System.Drawing.Point(499, 55);
            this.DeleteDB.Name = "DeleteDB";
            this.DeleteDB.Size = new System.Drawing.Size(296, 40);
            this.DeleteDB.TabIndex = 4;
            this.DeleteDB.Text = "데이터베이스 삭제";
            this.DeleteDB.Click += new System.EventHandler(this.DeleteDB_Click);
            // 
            // CreateDB
            // 
            this.CreateDB.Location = new System.Drawing.Point(499, 554);
            this.CreateDB.Name = "CreateDB";
            this.CreateDB.Size = new System.Drawing.Size(142, 40);
            this.CreateDB.TabIndex = 3;
            this.CreateDB.Text = "데이터베이스 생성";
            this.CreateDB.Click += new System.EventHandler(this.CreateDB_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(392, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "종료";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(380, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "시작";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.AcceptsTab = true;
            this.textBox2.Location = new System.Drawing.Point(6, 55);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(487, 539);
            this.textBox2.TabIndex = 0;
            // 
            // GoSetting
            // 
            this.GoSetting.Location = new System.Drawing.Point(647, 554);
            this.GoSetting.Name = "GoSetting";
            this.GoSetting.Size = new System.Drawing.Size(148, 40);
            this.GoSetting.TabIndex = 24;
            this.GoSetting.Text = "설정";
            this.GoSetting.Click += new System.EventHandler(this.GoSetting_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(798, 600);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "자동 업데이트";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CreateDB;
        private System.Windows.Forms.Button DeleteDB;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button TruncateDB;
        private System.Windows.Forms.TextBox InsertTextBox;
        private System.Windows.Forms.Button InsertDB;
        private System.Windows.Forms.Button PrintDB;
        private System.Windows.Forms.Button ViewDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ColumsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TableNameTextBox;
        private System.Windows.Forms.TrackBar Bright;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button COMStart;
        private System.Windows.Forms.Button COMStop;
        private System.Windows.Forms.Button GoSetting;

    }
}

