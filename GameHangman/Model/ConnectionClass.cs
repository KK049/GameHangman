using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameHangman.Model
{
    class ConnectionClass
    {
        private static ConnectionClass instance = new ConnectionClass();
        String db_Name = "GamePortal.db";
        SQLiteConnection conn;

        public static ConnectionClass Instnce
        {
            get
            {

                return instance;
            }
        }
        public void createTble()
        {
            String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(path, db_Name));
            conn.CreateTable<UserClass>();

        }

        public int Userinsrt(UserClass register)
        {
            int result = conn.Insert(register);
            return result;
        }


        public List<UserClass> getUsersList()
        {

            List<UserClass> data = conn.Table<UserClass>().OrderByDescending(C => C.id).ToList();

            return data;
        }

        public int del(UserClass Register)
        {

            int result = conn.Delete(Register);
            return result;
        }
    }
}