namespace AutoUpdater
{
    partial class Setting
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
            this.TreeContent = new System.Windows.Forms.Panel();
            this.TreeLabel = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.GoHome = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TreeContent);
            this.panel1.Controls.Add(this.TreeLabel);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.GoHome);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 600);
            // 
            // TreeContent
            // 
            this.TreeContent.Location = new System.Drawing.Point(214, 88);
            this.TreeContent.Name = "TreeContent";
            this.TreeContent.Size = new System.Drawing.Size(560, 509);
            // 
            // TreeLabel
            // 
            this.TreeLabel.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.TreeLabel.Location = new System.Drawing.Point(214, 48);
            this.TreeLabel.Name = "TreeLabel";
            this.TreeLabel.Size = new System.Drawing.Size(560, 37);
            this.TreeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.treeView1.Location = new System.Drawing.Point(3, 43);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(189, 554);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // GoHome
            // 
            this.GoHome.Location = new System.Drawing.Point(694, 3);
            this.GoHome.Name = "GoHome";
            this.GoHome.Size = new System.Drawing.Size(101, 34);
            this.GoHome.TabIndex = 0;
            this.GoHome.Text = "홈";
            this.GoHome.Click += new System.EventHandler(this.GoHome_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(798, 600);
            this.Controls.Add(this.panel1);
            this.Name = "Setting";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GoHome;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label TreeLabel;
        private System.Windows.Forms.Panel TreeContent;
    }
}