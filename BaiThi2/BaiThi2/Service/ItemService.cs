using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiThi2.Models;
using SQLitePCL;
using BaiThi2.Adapter;

namespace BaiThi2.Service
{
    
        interface IItemService
        {
            List<Product> GetCart();

            bool AddNew(Product item);
            bool CheckItem(Product item);
        }
        class ItemService : IItemService
        {
            public bool AddNew(Product item)
            {
                try
                {
                    SQLiteConnection connection = SQLiteHelper.GetInstance().SQLiteConnection;
                    var sql_txt = "insert into User(Name,Password) value(?,?)";

                    var statement = connection.Prepare(sql_txt);
                    statement.Bind(1, item.Name);
                    statement.Bind(2, item.Pasword);
                    var rs = statement.Step();
                    return rs == SQLiteResult.OK;
                }
                catch (Exception e)
                {
                    return false;
                }
            }

        public bool CheckItem(Product item)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance().SQLiteConnection;
                var sql_txt = "select * from User where Name = ?,Password = ?";

                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, item.Name);
                statement.Bind(2, item.Pasword);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Product> GetCart()
            {
                List<Product> cart = new List<Product>();
                try
                {
                    SQLiteConnection connection = SQLiteHelper.GetInstance().SQLiteConnection;
                    var sql_txt = "select * from User";
                    var statement = connection.Prepare(sql_txt);
                    while (SQLiteResult.ROW == statement.Step())
                    {
                        Product item = new Product()
                        {                            
                            Name = statement[0] as string,
                            Pasword = statement[1] as string,                            
                        };
                        cart.Add(item);
                    }

                }
                catch (Exception e)
                {

                }
                return cart;
            }
        }
    }

