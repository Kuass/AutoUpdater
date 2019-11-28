using System;
using System.Diagnostics;
using System.Data;
using System.Data.SQLite;

using AutoUpdater;

namespace Database
{
    public class database
    {
        private SQLiteConnection sql_con;
        private SQLiteDataReader sql_reader;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter sql_adapter;
        public static DataSet DS = new DataSet();
        public static DataTable DT = new DataTable();

        protected static database mDatabase = null;

        public static database getDatabase()
        {
            if (mDatabase == null)
            {
                mDatabase = new database();
            }
            return mDatabase;
        }

        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=" + Main.getClass().dbpath + ";Version=3;New=false;Compress=True;");
        }

        public void UpdateDefaultTable(string Colums, string Content)
        {
            // 설정파일(기본파일)의 원하는 컬럼의 데이터를 수정하고 싶을때 선언
            string UpdateText = "UPDATE " + Main.DefaultDBTableName + " SET " + Colums + "='" + Content + "' WHERE id=" + Main.DefaultDBTableIDColums;
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = UpdateText;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        private string CreateTableText = "CREATE TABLE ";
        public void CreateTable(string TableName, string[] Colums, string[] ColumsType)
        {
            // 데이터베이스에 테이블을 추가하고 싶을때에 선언
            CreateTableText += TableName + " (";
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            if (Colums.Length != ColumsType.Length)
            {
                Main.getClass().Textbox("[013] Colums과 ColumsType의 관계가 잘못되었습니다.");
            }
            else
            {
                if (Colums.Length > 1)
                {
                    for (int i = 0; i < Colums.Length; i++)
                    {
                        if (i != 0)
                        {
                            CreateTableText += ", ";
                        }
                        CreateTableText += Colums[i] + " " + ColumsType[i];
                    }
                }
                else if (Colums.Length == 1)
                {
                    CreateTableText += Colums[0] + " " + ColumsType[0];
                }
                else
                {
                    Main.getClass().Textbox("[012] Colums 혹은 ColumsType의 관계가 잘못되었습니다. " + Colums.Length);
                    return;
                }
                CreateTableText += ")";
                sql_cmd.CommandText = CreateTableText;
                //sql_cmd.CommandText = "CREATE TABLE Setting (IP VARCHAR)";
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                Main.getClass().Textbox("데이터베이스 생성 성공 " + Main.getClass().dbpath + " :: " + CreateTableText);
            }
        }

        private string InsertDataText = "INSERT INTO ";
        public void InsertData(string Table, string[] Colums, string[] Content)
        {
            // 데이터베이스의 해당 테이블안의 원하는 컬럼에 데이터를 집어넣고싶을 때
            InsertDataText += Table + " (";
            if (Colums.Length != Content.Length)
            {
                Main.getClass().Textbox("[013] Colums과 Content의 관계가 잘못되었습니다.");
            }
            else
            {
                if (Colums.Length > 1)
                {
                    for (int i = 0; i < Colums.Length; i++)
                    {
                        if (i != 0)
                        {
                            InsertDataText += ", ";
                        }
                        InsertDataText += Colums[i];
                    }
                    InsertDataText += ") values (";

                    for (int i = 0; i < Content.Length; i++)
                    {
                        if (i != 0)
                        {
                            InsertDataText += ", ";
                        }
                        InsertDataText += "'" + Content[i] + "'";
                    }
                    InsertDataText += ")";
                }
                else if (Colums.Length == 1)
                {
                    InsertDataText += Colums[0] + ") values ('" + Content[0] + "')";
                }
                else
                {
                    Main.getClass().Textbox("[016] Colums 혹은 Content의 관계가 잘못되었습니다. " + Colums.Length);
                    return;
                }

                try
                {
                    for (int i = 0; i < Colums.Length; i++)
                    {
                        if (ColumsExists(Table, Colums[i]))
                        {
                            Main.getClass().Textbox("[018] 존재하지 않는 컬럼명입니다. " + Colums[i]);
                            return;
                        }
                    }
                    SetConnection();
                    sql_con.Open();
                    sql_cmd = sql_con.CreateCommand();
                    sql_cmd.CommandText = InsertDataText;
                    sql_cmd.ExecuteNonQuery();
                    sql_con.Close();
                    Main.getClass().Textbox("데이터 삽입 성공. " + InsertDataText);
                }
                catch (Exception ex)
                {
                    Main.getClass().Textbox("[017] 데이터 반영중 문제가 생겼습니다. " + InsertDataText + " :: " + ex);
                }
            }
        }

        public static string PrintDataDisplay;
        private static string Temp;
        public void PrintData(int PrintType, string Table, string[] Board)
        {
            // 테이블에 쌓여있는 데이터를 출력하고 싶을 때 (디버깅/테스트용)
            if (Board.Length == 1)
            {
                Temp = Board[0];
            }
            SetConnection();
            sql_con.Open();
            sql_cmd = new SQLiteCommand("select " + Temp + " from " + Table, sql_con);
            sql_reader = sql_cmd.ExecuteReader();
            if (PrintType == 1)
            {
                Main.getClass().Textbox("======= " + Temp + " === " + Table + " === IP =======");
                while (sql_reader.Read())
                {
                    Main.getClass().Textbox(sql_reader["Adress"] + " ");
                    //retext += "IP : " + sql_reader["IP"] + ", ";
                }
                Main.getClass().Textbox("================================");
            }
            else if (PrintType == 2)
            {

            }
            sql_con.Close();
        }

        public bool ColumsExists(string Table, string Colums)
        {
            // 해당 테이블안에 해당 컬럼이 존재하는지 확인 return : true=있음, false=없음
            GetTableData(Table);
            string DatabaseInfo = convertDataTableToString(database.GetTableDatas);
            bool ColumsExists = true;
            if (DatabaseInfo.Contains("name~" + Colums))
            {
                ColumsExists = false;/*
                if (DatabaseInfo.Contains("type~" + ColumsType))
                {
                }*/
            }

            return ColumsExists;
        }

        public static DataTable GetTableDatas = null;
        public void GetTableData(string Table)
        {
            // 해당 테이블의 정보를 가져올 때
            SetConnection();
            sql_con.Open();
            sql_cmd = new SQLiteCommand("PRAGMA table_info(" + Table + ");", sql_con);
            //sql_cmd = new SQLiteCommand("PRAGMA table_info(" + Table + ");", sql_con);
            try
            {
                sql_adapter = new SQLiteDataAdapter(sql_cmd);
                sql_adapter.Fill(DT);
                sql_con.Close();
            }
            catch (Exception ex)
            {
                Main.getClass().Textbox("[015] GetTableQuery에서 예외를 참조하였습니다. " + ex);
            }
            GetTableDatas = DT;
            sql_con.Close();
        }

        public void TruncateTable(string TableName)
        {
            // 해당 테이블의 데이터를 초기화시킬때
            try
            {
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = "DELETE FROM " + TableName;
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                Main.getClass().Textbox("테이블을 성공적으로 초기화시켰습니다.");
            }
            catch (Exception ex)
            {
                Main.getClass().Textbox("테이블 비우기 실패. " + ex);
            }
        }

        /*
        public static string ConvertDataTableToString(DataTable dataTable)
        {
            var output = new database();

            var columnsWidths = new int[dataTable.Columns.Count];

            // Get column widths
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    var length = row[i].ToString().Length;
                    if (columnsWidths[i] < length)
                        columnsWidths[i] = length;
                }
            }

            // Get Column Titles
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var length = dataTable.Columns[i].ColumnName.Length;
                if (columnsWidths[i] < length)
                    columnsWidths[i] = length;
            }

            // Write Column titles
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var text = dataTable.Columns[i].ColumnName;
                output.Append("|" + PadCenter(text, columnsWidths[i] + 2));
            }
            output.Append("|\n" + new string('=', output.Length) + "\n");

            // Write Rows
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    var text = row[i].ToString();
                    output.Append("|" + PadCenter(text, columnsWidths[i] + 2));
                }
                output.Append("|\n");
            }
            return output.ToString();
        }

        private static string PadCenter(string text, int maxLength)
        {
            int diff = maxLength - text.Length;
            return new string(' ', diff / 2) + text + new string(' ', (int)(diff / 2.0 + 0.5));

        }*/

        public static string convertDataTableToString(DataTable dataTable)
        {
            // 데이터테이블을 보기좋게 문자열로 변환
            string data = string.Empty;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    data += dataTable.Columns[j].ColumnName + "~" + row[j];
                    if (j == dataTable.Columns.Count - 1)
                    {
                        if (i != (dataTable.Rows.Count - 1))
                            data += "$";
                    }
                    else
                        data += "|";
                }
            }
            return data;
        }
    }
}
