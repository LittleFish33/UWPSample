using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace SQLiteSample
{
    class DBService
    {
        //单例模式
        private static DBService instance;
        private static object _lock = new object();
        private DBService()
        {
            //建立连接，如果Items表不存在，则新建表Items
            conn = new SQLiteConnection("MySQLite.db");
            string sql = @"CREATE TABLE IF NOT EXISTS
                                ITEMS(
                                      ID INTEGER PRIMARY KEY NOT NULL,
                                      TITLE VARCHAR(50),
                                      DETAIL VARCHAR(200)
                                      );";

            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
        }
        public static DBService GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new DBService();
                    }
                }
            }
            return instance;
        }

        private SQLiteConnection conn;

        //一些需要的SQL语句
        private String SQL_DELETE = "DELETE FROM ITEMS" + " WHERE ID = ?";
        private String SQL_UPDATE = "UPDATE ITEMS" + " SET TITLE = ? , DETAIL = ? WHERE ID = ?";
        private String SQL_INSERT = "INSERT INTO ITEMS (TITLE,DETAIL)" + " VALUES(?,?);";
        private String SQL_SELECT_ALL = "SELECT * FROM ITEMS";
        private String SQL_QUERY = "SELECT * FROM ITEMS WHERE TITLE LIKE (?) OR DETAIL LIKE (?);";
        private String SQL_GETID = "SELECT ID FROM ITEMS WHERE TITLE = (?) OR DETAIL = (?);";

        //初始化，获得本地数据库中的所有Item
        internal void Initialize(ObservableCollection<Item> allItems)
        {
            using (var statement = conn.Prepare(SQL_SELECT_ALL))
            {
                while (SQLiteResult.ROW == statement.Step())
                {
                    int id = int.Parse(statement[0].ToString());
                    string title = (string)statement[1];
                    string detail = (string)statement[2];
                    allItems.Add(new Item(id, title, detail));
                }
            }
        }

        //增
        internal int CreateItem(Item item)
        {
            using (var statement = conn.Prepare(SQL_INSERT))
            {
                statement.Bind(1, item.Title);
                statement.Bind(2, item.Detail);
                statement.Step();
            }
            using (var statement = conn.Prepare(SQL_GETID))
            {
                statement.Bind(1, item.Title);
                statement.Bind(2, item.Detail);
                if (SQLiteResult.ROW == statement.Step())
                {
                    return int.Parse(statement[0].ToString());
                }
            }
            return 0;
        }

        //更新
        internal void UpdateItem(Item item)
        {
            using (var statement = conn.Prepare(SQL_UPDATE))
            {
                statement.Bind(1, item.Title);
                statement.Bind(2, item.Detail);
                statement.Bind(3, item.Id);
                statement.Step();
            }
        }

        //查
        internal async void queryItem(string text)
        {
            StringBuilder strB = new StringBuilder();
            using (var statement = conn.Prepare(SQL_QUERY))
            {
                string key = "%" + text + "%";
                statement.Bind(1, key);
                statement.Bind(2, key);
                while (SQLiteResult.ROW == statement.Step())
                {
                    strB.Append("Title: ");
                    strB.Append(statement[1].ToString());
                    strB.Append(" Detail: ");
                    strB.Append(statement[2].ToString());
                    strB.Append("\n");
                }
            }
            MessageDialog searchDialog = new Windows.UI.Popups.MessageDialog(strB.ToString());
            await searchDialog.ShowAsync();
        }

        //删
        internal void DeleteItem(int id)
        {
            using (var statement = conn.Prepare(SQL_DELETE))
            {
                statement.Bind(1, id);
                statement.Step();
            }
        }



    }
}
