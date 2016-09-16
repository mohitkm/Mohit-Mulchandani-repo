                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseConnectivity;

namespace BackendLogic
{
    public class UserDetailLogic
    {
        public static int insert(UserDetail D)
        {
            String query = @"INSERT INTO UserDetails VALUES(@Name,@Email,@Mobile,@Address,@Password,@IsActive,@Photo,@UserType)";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@Name", D.Name));
            par.Add(new SqlParameter("@Email", D.Email));
            par.Add(new SqlParameter("@Mobile", D.Mobile));
            par.Add(new SqlParameter("@Address", D.Address));
            par.Add(new SqlParameter("@Password", D.Password));
            par.Add(new SqlParameter("@IsActive", D.IsActive));
            par.Add(new SqlParameter("@Photo", D.Photo));
            par.Add(new SqlParameter("@UserType", D.UserType));
            
            return DatabaseAccess.modifyData(query, par);

        }

        public static int validate(String id, String pass)
        {
            String query = @"SELECT * FROM UserDetails WHERE Email=@Email";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@Email", id));

            DataTable dt = DatabaseAccess.selectData(query, par);
            if (dt.Rows.Count == 1)
            {
                String password = dt.Rows[0]["Password"].ToString();
                if (pass == password)
                    return Convert.ToInt32(dt.Rows[0]["UserDetailID"]);
                else
                    return 0;
            }
            else
                return 0;
        }

        public static int updatePassword(UserDetail D)
        {
            String query = @"UPDATE UserDetails SET Password=@Password WHERE UserDetailID=@UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", D.UserDetailID));
            par.Add(new SqlParameter("@Password",D.Password));

            return DatabaseAccess.modifyData(query, par);
        }
        public static int update(UserDetail D)
        {
            String query = @"UPDATE UserDetails SET Name=@Name,Email=@Email,Mobile=@Mobile,Address=@Address,Password=@Password,IsActive=@IsActive,Photo=@Photo,UserType=@UserType WHERE UserDetailID=@UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", D.UserDetailID));
            par.Add(new SqlParameter("@Name", D.Name));
            par.Add(new SqlParameter("@Email", D.Email));
            par.Add(new SqlParameter("@Mobile", D.Mobile));
            par.Add(new SqlParameter("@Address", D.Address));
            par.Add(new SqlParameter("@Password", D.Password));
            par.Add(new SqlParameter("@IsActive", D.IsActive));
            par.Add(new SqlParameter("@Photo", D.Photo));
            par.Add(new SqlParameter("@UserType", D.UserType));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int delete(int UserDetailID)
        {
            String query = @"DELETE FROM UserDetails WHERE UserDetailID=@UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", UserDetailID));

            return DatabaseAccess.modifyData(query, par);

        }

        public static DataTable select()
        {
            String query = @"SELECT * FROM UserDetails";
            List<SqlParameter> par = new List<SqlParameter>();

            return DatabaseAccess.selectData(query, par);

        }

        public static UserDetail selectByID(int UserDetailID)
        {
            String query = @"SELECT * FROM UserDetails WHERE UserDetailID=@UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", UserDetailID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 1)
            {
                UserDetail CM = new UserDetail();
                CM.UserDetailID = Convert.ToInt32(dt.Rows[0]["UserDetailID"]);
                CM.Name = dt.Rows[0]["Name"].ToString();
                CM.Email = dt.Rows[0]["Email"].ToString();
                CM.Mobile = dt.Rows[0]["Mobile"].ToString();
                CM.Address = dt.Rows[0]["Address"].ToString();
                CM.Password = dt.Rows[0]["Password"].ToString();
                CM.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                CM.Photo = dt.Rows[0]["Photo"].ToString();
                CM.UserType = dt.Rows[0]["UserType"].ToString();
                
                return CM;

            }
            else
            {
                return new UserDetail();
            }
        }
        public static int getID(String email)
        {
            String query = "SELECT * FROM UserDetails where Email like '%'+@Email+'%' ";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@Email", email));
            
            DataTable dt = DatabaseAccess.selectData(query, par);
            if (dt.Rows.Count == 1)
            {
                int ID = Convert.ToInt32(dt.Rows[0]["UserDetailID"]);
                return ID;
            }
            else
            {
                return 100;
            }
        }
        
    }
}
