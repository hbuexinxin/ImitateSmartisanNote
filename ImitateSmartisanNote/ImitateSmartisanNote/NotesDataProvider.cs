using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ImitateSmartisanNote
{
    public class NotesDataProvider
    {
        //public void ConnectDataDB()
        //{
        //    string connectString = @"Data Source=notesData.db;Pooling=true;FailIfMissing=false";
        //    SQLiteConnection conn = new SQLiteConnection(connectString);
        //    conn.Open();

        //    SQLiteCommand cmd = conn.CreateCommand();
        //    cmd.CommandText = "select * from NotesTable"; //order 表

        //}

        //public void DisconnectDataDB()
        //{
        //}

        //private bool _bConnected = false;

        //private void ConnectSQLiteDB()
        //{

        //}

        public IEnumerable<NoteItemModel> LoadData()
        {
            var noteItems = new List<NoteItemModel>();

            string connectString = @"Data Source=notesData.db;Pooling=true;FailIfMissing=false";
            SQLiteConnection conn = new SQLiteConnection(connectString);
            conn.Open();
            
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from NotesTable"; //order 表
            cmd.CommandType = System.Data.CommandType.Text;

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    noteItems.Add(new NoteItemModel(reader["Date"].ToString(), reader["Note"].ToString()));
                }
            }

            return noteItems;
        }
    }
}
