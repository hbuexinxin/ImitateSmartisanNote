using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;

namespace ImitateSmartisanNote
{
    public class NotesDataProvider
    {
        public void Init()
        {
            try
            {
                //判断表是否存在，不存在则创建
                string tableName = "NotesTable";
                string connectString = @"Data Source=notesData.db;Pooling=true;FailIfMissing=false";
                using (SQLiteConnection conn = new SQLiteConnection(connectString))
                {
                    conn.Open();

                    SQLiteCommand cmd = conn.CreateCommand();

                    cmd.CommandText = string.Format(@"select count(*)  from sqlite_master where type = 'table' and name = '{0}'", tableName);
                    cmd.CommandType = System.Data.CommandType.Text;

                    var nTableCount = (Int64)cmd.ExecuteScalar();
                    if (nTableCount <= 0)
                    {
                        //读取已经存储的空数据库sql语句文件。创建新表
                        var createTablesSQL = System.IO.File.ReadAllText(string.Format(@"backSQL\{0}.sql", tableName));
                        if (!string.IsNullOrWhiteSpace(createTablesSQL))
                        {
                            //创建新表
                            cmd.CommandText = createTablesSQL;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.ExecuteScalar();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public IEnumerable<NoteItemModel> LoadData()
        {
            var noteItems = new List<NoteItemModel>();

            string connectString = @"Data Source=notesData.db;Pooling=true;FailIfMissing=false";
            SQLiteConnection conn = new SQLiteConnection(connectString);
            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from NotesTable"; //表
            cmd.CommandType = System.Data.CommandType.Text;
            
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    noteItems.Add(new NoteItemModel(reader["Date"].ToString(), reader["Time"].ToString(), reader["Note"].ToString()));
                }
            }

            return noteItems;
        }
    }
}
