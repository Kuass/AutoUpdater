using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ats.Forms;

namespace AutoUpdater
{
    public partial class Setting : Form
    {
        protected static Setting sSetting = null;
        protected string[ ] TreeView = { "설정", "디버그" };
        protected string[,] TreeViewContent = { { "타입", "언어", "서버IP", "클라이언트IP" }, 
                                           { "RFID", "ID", "", "" } };
        private static int n;

        public Setting()
        {
            InitializeComponent();
        }

        public static Setting getSetting()
        {
            if (sSetting == null)
            {
                sSetting = new Setting();
            }
            return sSetting;
        }

        protected List<TreeNode> tTreeViewForList = new List<TreeNode>();

        private void Setting_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            for (int n = 0; n < TreeView.Length; n++)
            {
                TreeNode TreeTemp = new TreeNode(TreeView[n]);
                tTreeViewForList.Add(TreeTemp);
                for (int i = 0; i < TreeViewContent.GetLength(1); i++)
                {
                    if (String.IsNullOrEmpty(TreeViewContent[n, i]))
                    {
                        continue;
                    }
                    tTreeViewForList[n].Nodes.Add(TreeViewContent[n,i]);
                }
            }

            for (int n = 0; n < tTreeViewForList.Count; n++)
            {
                treeView1.Nodes.Add(tTreeViewForList[n]);
            }

            treeView1.ExpandAll();
        }

        private void GoHome_Click(object sender, EventArgs e)
        {
            Program.theMainForm.Show();
            Program.theSettingForm.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeContent.Controls.Clear();
            this.TreeLabel.Text = e.Node.Text;
            n = 0;
            if (TreeView.Contains(e.Node.Text))
            {
                Label ThisisType = AddLabel("대분류입니다.", 0);
                TreeContent.Controls.Add(ThisisType);
                return;
            }
            if (e.Node.Text == "타입")
            {
                CheckBox ThisisType = AddCheckBox("타입이야");
                TreeContent.Controls.Add(ThisisType);

                CheckBox ThisisType2 = AddCheckBox("타입일까???");
                TreeContent.Controls.Add(ThisisType2);

                TextBox ThisisType3 = AddTextBox("타입서술");
                TreeContent.Controls.Add(AddGlobalLabel);
                TreeContent.Controls.Add(ThisisType3);

                string[] thisisarray = { "하렉스인포텍", "당신은..누구신가요?", "방갑당!" };
                ComboBox ThisisType4 = AddComboBox("타입선택", thisisarray);
                TreeContent.Controls.Add(AddGlobalLabel);
                TreeContent.Controls.Add(ThisisType4);
            }
            else
            {
                Label ThisisType = AddLabel("설정을 불러올 수 없습니다.", 1);
                TreeContent.Controls.Add(ThisisType);
            }
        }

        private CheckBox AddCheckBox(string content)
        {
            CheckBox checkbox = new CheckBox();
            checkbox.Location = new Point(10, 10 + (n * 35));
            checkbox.Size = new Size(300, 35);
            checkbox.Font = new Font("Arial", 15, FontStyle.Bold);
            checkbox.Text = content;
            n++;
            return checkbox;
        }

        private static Label AddGlobalLabel;
        private TextBox AddTextBox(string info)
        {
            Label label = new Label();
            label.Location = new Point(10, 10 + (n * 35));
            label.Size = new Size(130, 28);
            label.Font = new Font("Arial", 15, FontStyle.Bold);
            label.Text = info;
            AddGlobalLabel = label;
            TextBox textbox = new TextBox();
            textbox.Location = new Point(140, 10 + (n * 35));
            textbox.Size = new Size(400, 28);
            textbox.Font = new Font("Arial", 14, FontStyle.Bold);
            n++;
            return textbox;
        }

        private ComboBox AddComboBox(string info, string[] content)
        {
            Label label = new Label();
            label.Location = new Point(10, 10 + (n * 35));
            label.Size = new Size(130, 28);
            label.Font = new Font("Arial", 15, FontStyle.Bold);
            label.Text = info;
            AddGlobalLabel = label;
            ComboBox combobox = new ComboBox();
            combobox.Location = new Point(140, 10 + (n * 35));
            combobox.Size = new Size(400, 28);
            combobox.Font = new Font("Arial", 14, FontStyle.Bold);
            combobox.Items.Clear();
            for (int i = 0; i < content.Length; i++)
            {
                combobox.Items.Add(content[i]);
            }
            combobox.SelectedIndex = 0;
            n++;
            return combobox;
        }

        private Label AddLabel(string content, int rating)
        {
            Label label = new Label();
            label.Location = new Point(10, 10 + (n * 35));
            label.Size = new Size(500, 28);
            label.Font = new Font("Arial", 15, FontStyle.Bold);
            label.Text = content;
            if (rating == 1)
            {
                label.ForeColor = Color.Red;
            }
            n++;
            return label;
        }
    }
}