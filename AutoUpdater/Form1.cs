using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Ats;
using Ats.Comm;
using Database;
using ProtocolModbus;

namespace AutoUpdater
{
    public partial class Main : Form
    {
        protected Stopwatch sw = new Stopwatch();

        //private string ClientName = "test.txt"; // 테스트 대상 클라이언트명
        private string ClientNamePlus = "\\test.txt";
        private string AutoUpdateVersion = "1.0.0"; // 현재 클라이언트 버전 설정
        public static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        public string dbpath = path + "\\Data.db";

        public const string DefaultDBTableName = "Settings";
        public const string DefaultDBTableIDColums = "0";
        public static string[] DefaultDBTableColums = new string[] { "id", "Adress", "manager" };
        public static string[] DefaultDBTableColumsType = new string[] { "int", "varchar", "varchar" };
        public static string[] DefaultDBTableColumsForContent = new string[] { DefaultDBTableIDColums, "127.0.0.1", "Moderntec" };

        delegate void SetTextCallback(string text);

        protected static Main mClass = null;

        public Main()
        {
            InitializeComponent();
            //database.getDatabase().
        }

        public static Main getClass()
        {
            return mClass;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sw.Start();
            mClass = this;
            Ats.MainBoard.SetBacklightBrightness(40);
            Bright.Value = 40;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Textbox("프로그램이 실행되었습니다. " + path);

            Textbox("Extension IO 보드를 초기화중입니다...");
            try
            {
                Ats.IOControl.Open();
                Textbox("Extension IO 보드 초기화완료");
            }
            catch (Exception ex)
            {
                Textbox("[008] IOControl 초기화중 문제가 발생하였습니다. " + ex);
            }
            Textbox("데이터베이스 확인중...");
            if (File.Exists(dbpath))
            {
                Textbox("데이터베이스가 존재합니다.");
            }
            else
            {
                Textbox("데이터베이스가 존재하지 않습니다.");
                Textbox("데이터베이스 생성중...");
                try
                {
                    database.getDatabase().CreateTable(DefaultDBTableName, DefaultDBTableColums, DefaultDBTableColumsType);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                    Textbox("[011] 데이터베이스 테이블 생성 실패. " + error);
                }
            }

            Textbox("데이터베이스 유효성 확인중...");

            bool Toggle = true;
            for (int i = 0; i < DefaultDBTableColums.Length; i++)
            {
                if (database.getDatabase().ColumsExists(DefaultDBTableName, DefaultDBTableColums[i]))
                {
                    Toggle = false;
                }
            }

            if (Toggle)
            {
                Textbox("데이터베이스 유효성 검사에 실패하였습니다.");
                Textbox("AutoUpdater 프로그램을 진행할 수 없습니다. 데이터베이스 재구축이 필요합니다..");
                return;
            }
            sw.Stop();
            Textbox("데이터베이스가 유효합니다. (" + sw.ElapsedMilliseconds.ToString() + "ms) (" + sw.ElapsedTicks.ToString() + "ticks)" + dbpath);

            Update();
        }

        public new void Update()
        {
            Textbox("새로운 업데이트를 확인 중입니다..");
            try
            {
                Textbox("업데이트 파일을 내려받고있습니다...");
                // 다운로드 부분

                if (!System.IO.File.Exists(path + ClientNamePlus + ".wait"))
                {
                    try
                    {
                        FileStream stream = System.IO.File.Create(path + ClientNamePlus + ".wait");
                        stream.Close();
                        Textbox("파일 생성 완료" + path + ClientNamePlus + ".wait");
                    }
                    catch (Exception ex)
                    {
                        Textbox("[001] 문제가 발생하였습니다. " + ex);
                    }
                }
                else 
                {
                    Textbox("[006] 이미 업데이트 파일이 존재합니다. 업데이트를 진행합니다.");
                }

                Completed();
            }
            catch(Exception ex)
            {
                Textbox("[002] 문제가 발생하였습니다. " + ex);
            }
        }

        private void Completed(/*object sender, AsyncCompletedEventArgs e*/)
        {
            string browse = path + ClientNamePlus;
            Textbox("유효성을 검사중입니다..." + browse);
            if (System.IO.File.Exists(browse) && System.IO.File.Exists(browse + ".wait"))
            {
                Textbox("업데이트를 적용중입니다...");
                try
                {
                    File.Delete(browse);
                    File.Move(browse + ".wait", browse);
                    //System.Diagnostics.Process.Start(path + ClientNamePlus);
                    //Textbox("파일실행");
                    Textbox("업데이트 완료.");
                    Textbox("명령 대기중..");
                    return;
                }
                catch (IOException ex)
                {
                    Textbox("[003] 적용실패. " + ex.Message);
                }
            }
            else
            {
                // 유효성 검사 실패시
                Textbox("[007] 적용실패. 업데이트 대상 파일이 존재하지 않습니다.");

                Textbox("기존파일을 생성합니다...");
                try
                {
                     FileStream stream = System.IO.File.Create(browse);
                     stream.Close();
                }    
                catch (Exception ex)
                {
                    Textbox("[004] 문제가 발생하였습니다. " + ex);
                }
            }
            Textbox("[005] 업데이트 실패... 3초후 재시도합니다.");
            System.Threading.Thread.Sleep(3000);
            Update();
        }

        private void CheckUpdate()
        {
            Textbox("업데이트 서버에 접속 시도중...");

            Textbox("최신버전이 발견되었습니다. (현재버전 : " + AutoUpdateVersion + ", 최신버전 : ???)");
            Update();
        }

        public void Textbox(string content)
        {
            textBox2.Text += content + Environment.NewLine;
            textBox2.SelectionStart = textBox2.Text.Length; //맨 마지막 선택...
            textBox2.ScrollToCaret();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateDB_Click(object sender, EventArgs e)
        {
            Textbox("데이터베이스 테이블 생성중... // 디버깅용 입니다.");
            string[] Colums = new string[] { "AAA", "BBB", "CCC" };
            string[] ColumsType = new string[] { "varchar", "int", "varchar" };
            if (File.Exists(dbpath))
            {
                Textbox("테이블이 이미 존재함");
            }
            else
            {
                try
                {
                    database.getDatabase().CreateTable(DefaultDBTableName, Colums, ColumsType);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;

                    Textbox("[010] 데이터베이스 테이블 생성 실패. " + error);
                }
            }
        }

        private void DeleteDB_Click(object sender, EventArgs e)
        {
            string browse = path + "\\Data.db";
            if (System.IO.File.Exists(browse))
            {
                try
                {/*
                    FileStream stream = System.IO.
                    stream.Close();*/
                    File.Delete(browse);
                    Textbox("데이터베이스 삭제완료.");
                    return;
                }
                catch (IOException ex)
                {
                    Textbox("데이터베이스 삭제실패. " + ex.Message);
                }
            }
            else
            {
                Textbox("데이터베이스가 존재하지 않습니다.");
            }

        }

        private void Restart_Click(object sender, EventArgs e)
        {
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = path + @"\AutoUpdater.exe";
            Process p = Process.Start(pInfo);
        }

        private void InsertDB_Click(object sender, EventArgs e)
        {
            string[] Colums = new string[] { ColumsTextBox.Text };
            string[] Content = new string[] { InsertTextBox.Text };
            try
            {
                database.getDatabase().InsertData(TableNameTextBox.Text, Colums, Content);
            }
            catch (Exception ex)
            {
                Textbox("[009] 데이터 삽입 과중에 문제가 발생하였습니다. " + ex.Message);
            }
        }

        private void PrintDB_Click(object sender, EventArgs e)
        {
            try
            {
                string[] Board = new string[] { "*" };
                database.getDatabase().PrintData(1, TableNameTextBox.Text, Board);
            }
            catch (Exception ex)
            {
                Textbox("[008] 데이터 출력 과중에 문제가 발생하였습니다. " + ex.Message);
            }
        }

        static void KillProcessByName(string exefile)
        {
            //OpenNETCF;
        }

        private void TruncateDB_Click(object sender, EventArgs e)
        {
            database.getDatabase().TruncateTable(TableNameTextBox.Text);
        }

        private void ViewDB_Click(object sender, EventArgs e)
        {
            string DatabaseInfo = null;
            database.getDatabase().GetTableData(TableNameTextBox.Text);
            DatabaseInfo = database.convertDataTableToString(database.GetTableDatas);
            Textbox(DatabaseInfo);
        }

        private void Bright_ValueChanged(object sender, EventArgs e)
        {
            Ats.MainBoard.SetBacklightBrightness(Bright.Value);
        }

        private void COMStart_Click(object sender, EventArgs e)
        {
            Modbus.getModbus().InitDevice();
        }

        private void COMStop_Click(object sender, EventArgs e)
        {
            Modbus.getModbus().UnInitDevice();
        }

        private void GoSetting_Click(object sender, EventArgs e)
        {
            Program.theSettingForm.Show();
            Program.theMainForm.Hide();
        }
    }
}