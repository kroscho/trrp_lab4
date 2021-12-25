using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace Server
{
    [Serializable]
    public class takenotes
    {
        public int id, model_id, mark_id, price, cust_id, manag_id, manag_salary;
        public string model_name, mark_name, cust_name, manag_name;

        public takenotes(IDataRecord sqlReader)
        {
            id = int.Parse(sqlReader[0].ToString());
            model_id = int.Parse(sqlReader[1].ToString());
            model_name = sqlReader[2].ToString();
            mark_id = int.Parse(sqlReader[3].ToString());
            mark_name = sqlReader[4].ToString();
            price = int.Parse(sqlReader[5].ToString());
            cust_id = int.Parse(sqlReader[6].ToString());
            cust_name = sqlReader[7].ToString();
            manag_id = int.Parse(sqlReader[8].ToString());
            manag_name = sqlReader[9].ToString();
            manag_salary = int.Parse(sqlReader[10].ToString());
        }

        public takenotes()
        {

        }

        //public takenotes(IDataRecord sqlReader)
        //{
        //    id = int.Parse(sqlReader["id"].ToString());
        //    model_id = int.Parse(sqlReader["model_id"].ToString());
        //    model_name = sqlReader["model_name"].ToString();
        //    mark_id = int.Parse(sqlReader["mark_id"].ToString());
        //    mark_name = sqlReader["mark_name"].ToString();
        //    price = int.Parse(sqlReader["price"].ToString());
        //    cust_id = int.Parse(sqlReader["cust_id"].ToString());
        //    cust_name = sqlReader["cust_name"].ToString();
        //    manag_id = int.Parse(sqlReader["manag_id"].ToString());
        //    manag_name = sqlReader["manag_name"].ToString();
        //    manag_salary = int.Parse(sqlReader["manag_salary"].ToString());
        //}

        public void WriteToNormalizedDb()
        {
            using (var conn = new MySqlConnection(MyDB.ConnString))
            {
                //add customer
                conn.Open();
                var strSql = "select count(*) from customers where id = @id";
                var sqlCommand = new MySqlCommand(strSql, conn);
                sqlCommand.Parameters.AddWithValue("@id", cust_id);
                if ((long)sqlCommand.ExecuteScalar() == 0)
                {
                    strSql = "insert into customers values(@id, @name)";
                    sqlCommand = new MySqlCommand(strSql, conn);
                    sqlCommand.Parameters.AddWithValue("@id", cust_id);
                    sqlCommand.Parameters.AddWithValue("@name", cust_name);
                    sqlCommand.ExecuteNonQuery();
                }

                //add manager
                strSql = "select count(*) from managers where id = @id";
                sqlCommand = new MySqlCommand(strSql, conn);
                sqlCommand.Parameters.AddWithValue("@id", manag_id);
                if ((long)sqlCommand.ExecuteScalar() == 0)
                {
                    strSql = "insert into managers values(@id, @name, @salary)";
                    sqlCommand = new MySqlCommand(strSql, conn);
                    sqlCommand.Parameters.AddWithValue("@id", manag_id);
                    sqlCommand.Parameters.AddWithValue("@name", manag_name);
                    sqlCommand.Parameters.AddWithValue("@salary", manag_salary);
                    sqlCommand.ExecuteNonQuery();
                }

                //add mark
                strSql = "select count(*) from marks where id = @id";
                sqlCommand = new MySqlCommand(strSql, conn);
                sqlCommand.Parameters.AddWithValue("@id", mark_id);
                if ((long)sqlCommand.ExecuteScalar() == 0)
                {
                    strSql = "insert into marks values(@id, @name)";
                    sqlCommand = new MySqlCommand(strSql, conn);
                    sqlCommand.Parameters.AddWithValue("@id", mark_id);
                    sqlCommand.Parameters.AddWithValue("@name", mark_name);
                    sqlCommand.ExecuteNonQuery();
                }

                //add model
                strSql = "select count(*) from models where id = @id";
                sqlCommand = new MySqlCommand(strSql, conn);
                sqlCommand.Parameters.AddWithValue("@id", model_id);
                if ((long)sqlCommand.ExecuteScalar() == 0)
                {
                    strSql = "insert into models values(@id, @name, @mark, @price)";
                    sqlCommand = new MySqlCommand(strSql, conn);
                    sqlCommand.Parameters.AddWithValue("@id", model_id);
                    sqlCommand.Parameters.AddWithValue("@name", model_name);
                    sqlCommand.Parameters.AddWithValue("@mark", mark_id);
                    sqlCommand.Parameters.AddWithValue("@price", price);
                    sqlCommand.ExecuteNonQuery();
                }

                //add sale
                strSql = "select count(*) from sales where id = @id";
                sqlCommand = new MySqlCommand(strSql, conn);
                sqlCommand.Parameters.AddWithValue("@id", manag_id);
                if ((long)sqlCommand.ExecuteScalar() == 0)
                {
                    strSql = "insert into sales values(@id, @dish, @customer, @manager)";
                    sqlCommand = new MySqlCommand(strSql, conn);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@dish", model_id);
                    sqlCommand.Parameters.AddWithValue("@customer", cust_id);
                    sqlCommand.Parameters.AddWithValue("@manager", manag_id);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

    }
}
