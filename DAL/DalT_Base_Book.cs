using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace book.DAL
{
    public class DalT_Base_Book
    {
        public List<book.Model.T_Base_Book> GetList()
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=14jb;pwd=14jb;database=14211160205_book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from t_base_book";
            cm.Connection = co;

            SqlDataReader dr = cm.ExecuteReader();
            List<book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.Code = Convert.ToString(dr["Code"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                book.PYear = Convert.ToDateTime(dr["PYear"]);
                book.Version = Convert.ToString(dr["Version"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.Pic = Convert.ToString(dr["Pic"]);

                lst.Add(book);
            }
            dr.Close();
            co.Close();
            return lst;
        }

        public bool delete(string ids)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=14jb;pwd=14jb;database=14211160205_book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "delete from t_base_book where id in (" +  ids  + ")";
            cm.Connection = co;

            int result = cm.ExecuteNonQuery();
            co.Close();
            if (result > 0)
                return true;

            return false;

        }

        public bool add(book.Model.T_Base_Book book)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=14jb;pwd=14jb;database=14211160205_book";
            co.Open();
            SqlCommand cm = new SqlCommand();
            cm.CommandText = @"insert into t_base_book (Code,Author,Price,PYear,Version,BookName,Pic) Values (@Code,@Author,@Price,@PYear,@Version,@BookName,@Pic)";
            cm.Connection = co;
            cm.Parameters.AddWithValue("@Code", book.Code);
            cm.Parameters.AddWithValue("@Author", book.Author);
            cm.Parameters.AddWithValue("@Price", book.Price);
            cm.Parameters.AddWithValue("@PYear", book.PYear);
            cm.Parameters.AddWithValue("@Version", book.Version);
            cm.Parameters.AddWithValue("@BookName", book.BookName);
            cm.Parameters.AddWithValue("@Pic", book.Pic);

            int result = cm.ExecuteNonQuery();
            co.Close();
            if (result > 0)
                return true;

            return false;
        }

        public book.Model.T_Base_Book getModelById(int id)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString ="server=10.132.239.215;uid=14jb;pwd=14jb;database=14211160205_book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "select * from t_base_book where id =@id";
            cm.Parameters.AddWithValue("@id", id);
            cm.Connection = co;

            SqlDataReader dr = cm.ExecuteReader();
            book.Model.T_Base_Book book = null;        
            while (dr.Read())
            {
                book= new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.Code = Convert.ToString(dr["Code"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                book.PYear = Convert.ToDateTime(dr["PYear"]);
                book.Version = Convert.ToString(dr["Version"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.Pic = Convert.ToString(dr["Pic"]);
            }
            co.Close();
            dr.Close();

            return book;
        }

        public bool Update(book.Model.T_Base_Book book)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=14jb;pwd=14jb;database=14211160205_book";
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.CommandText = "update t_base_book set Code=@Code,Author=@Author,Price=@Price,PYear=@PYear,Version=@Version,BookName=@BookName,Pic=@Pic where Id=@Id";
            cm.Parameters.AddWithValue("@Code", book.Code);
            cm.Parameters.AddWithValue("@Author", book.Author);
            cm.Parameters.AddWithValue("@Price", book.Price);
            cm.Parameters.AddWithValue("@PYear", book.PYear);
            cm.Parameters.AddWithValue("@Version", book.Version);
            cm.Parameters.AddWithValue("@BookName", book.BookName);
            cm.Parameters.AddWithValue("@Pic", book.Pic);
            cm.Parameters.AddWithValue("@Id", book.Id);
            cm.Connection = co;

            int result = cm.ExecuteNonQuery();
            co.Close();
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }

        public int GetRecord(string where)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = "server=10.132.239.215;uid=14jb;pwd=14jb;database=14211160205_book";
            co.Open();


            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select count(1) from t_base_book where " + where;

            int a = (int)cm.ExecuteScalar();
            // int result=cm.ExecuteNonQuery();
            //SqlDataReader dr= cm.ExecuteReader();
            co.Close();
            return a;
        }

        public List<book.Model.T_Base_Book> GetListByPageIndex(int CurrentPageIndex, int PageSize, string where)
        {
            SqlConnection co = new SqlConnection();
            co.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["sqlconnection"];
            co.Open();

            SqlCommand cm = new SqlCommand();
            cm.Connection = co;
            cm.CommandText = "select top " + PageSize + " * from t_base_book where id not in ( select top " + PageSize * (CurrentPageIndex - 1) + " id from T_Base_Book where " + where + ") and " + where;
            SqlDataReader dr = cm.ExecuteReader();
            List<book.Model.T_Base_Book> lst = new List<Model.T_Base_Book>();
            while (dr.Read())
            {
                #region 模型转换
                book.Model.T_Base_Book book = new Model.T_Base_Book();
                book.Id = Convert.ToInt32(dr["Id"]);
                book.Code = Convert.ToString(dr["Code"]);
                book.Author = Convert.ToString(dr["Author"]);
                book.Price = Convert.ToDecimal(dr["Price"]);
                book.PYear = Convert.ToDateTime(dr["PYear"]);
                book.Version = Convert.ToString(dr["Version"]);
                book.BookName = Convert.ToString(dr["BookName"]);
                book.Pic = Convert.ToString(dr["Pic"]);
                #endregion
                lst.Add(book);
            }
            co.Close();
            return lst;

        }
    }
}
