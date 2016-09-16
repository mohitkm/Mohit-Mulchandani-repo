                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnectivity
{
    public class DatabaseAccess
    {
        public static int modifyData(String query, List<SqlParameter> parameters)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='F:\College\7th Sem\Tournament Management project\Tournament Project\Frontend\App_Data\TournamentProjectDatabase.mdf';Integrated Security=True;User Instance=True";
            //conn.ConnectionString = @"workstation id=TournamentWebDatabase.mssql.somee.com;packet size=4096;user id=mohitdhrumil_SQLLogin_1;pwd=exe62ga2m7;data source=TournamentWebDatabase.mssql.somee.com;persist security info=False;initial catalog=TournamentWebDatabase";
            SqlCommand comm = new SqlCommand();
            comm.CommandText = query;
            comm.Parameters.AddRange(parameters.ToArray());
            comm.Connection = conn;

            conn.Open();
            int x = comm.ExecuteNonQuery();
            conn.Close();

            return x;
        }

        public static DataTable selectData(String query, List<SqlParameter> parameters)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename='F:\College\7th Sem\Tournament Management project\Tournament Project\Frontend\App_Data\TournamentProjectDatabase.mdf';Integrated Security=True;User Instance=True";
            //conn.ConnectionString = @"workstation id=TournamentWebDatabase.mssql.somee.com;packet size=4096;user id=mohitdhrumil_SQLLogin_1;pwd=exe62ga2m7;data source=TournamentWebDatabase.mssql.somee.com;persist security info=False;initial catalog=TournamentWebDatabase";
            SqlCommand comm = new SqlCommand();
            comm.CommandText = query;
            comm.Parameters.AddRange(parameters.ToArray());
            comm.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(comm);

            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}
