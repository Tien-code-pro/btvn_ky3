using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Windows.Storage;
using System.IO;

namespace BaiThi2.Adapter
{
    class SQLiteHelper
    {
        private readonly string dbName = "User.db";

        private static SQLiteHelper instance;

        private SQLiteHelper()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            SQLiteConnection = new SQLiteConnection(path);

            var sql_txt = @"create table if not exists User(Id integer identity(1,1) primary key,Name varchar(255),Password varchar(255))";
            var statement = SQLiteConnection.Prepare(sql_txt);
            statement.Step();
        }

        public SQLiteConnection SQLiteConnection { get; set; }

        public static SQLiteHelper GetInstance()
        {
            if (instance == null)
                instance = new SQLiteHelper();
            return instance;
        }
    }
}
