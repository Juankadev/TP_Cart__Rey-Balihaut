﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }
        public DataAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            command = new SqlCommand();
        }
        public void SetQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }
        public void ExecuteReader()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExecuteNonQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddParameter(string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }
        public void Close()
        {
            if (reader != null)
                reader.Close();
            connection.Close();
        }
    }
}
