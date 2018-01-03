using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimosTime
{
    class SQL
    {
        private static string db = "Data Source=DESKTOP-ADCFQV1;Initial Catalog=NPrimos;Integrated Security=True";
        SqlConnection conn = new SqlConnection(db);
        public void InsertTable(int a)
        {            
            try
            {                
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = String.Format("insert into primos values({0})", a),
                    CommandType = System.Data.CommandType.Text,
                    Connection = conn
                };
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Numero {0} adicionado à tabela!",a);
            }
            catch (SqlException s)
            {
                throw new Exception(String.Format("Erro SQL Nº{0}\n{1}", s.Number, s.Message));
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Erro Geral\n{0}", e.Message));
            }
            finally
            {                
                conn.Close();
            }
        }
        public Queue<int> SelectPrimos()
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = conn,
                CommandType = System.Data.CommandType.Text,
                CommandText = "select * from primos"
            };
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Queue<int> queue = new Queue<int>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    queue.Enqueue(reader.GetInt32(0));
                }
            }
            conn.Close();
            return queue;
        }
    }
}
