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
    public class TeamLogic
    {
        public static int insert(Team T)
            {
            String query = @"INSERT INTO Team VALUES(@TeamName,@Details,@Banner,@Logo,@TournamentID,@ManagerID,@IsActive,@Points,@CurrentRound)";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamName", T.TeamName));
            par.Add(new SqlParameter("@Details", T.Details));
            par.Add(new SqlParameter("@Banner", T.Banner));
            par.Add(new SqlParameter("@Logo", T.Logo));
            par.Add(new SqlParameter("@TournamentID", T.TournamentID));
            par.Add(new SqlParameter("@ManagerID", T.ManagerID));
            par.Add(new SqlParameter("@IsActive", T.IsActive));
            par.Add(new SqlParameter("@Points", T.Points));
            par.Add(new SqlParameter("@CurrentRound", T.CurrentRound));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int update(Team T)
        {
            String query = @"UPDATE Team SET TeamName=@TeamName,Details=@Details,Banner=@Banner,Logo=@Logo,TournamentID=@TournamentID,ManagerID=@ManagerID,isActive=@IsActive,Points=@Points,CurrentRound=@CurrentRound WHERE TeamID=@TeamID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamID",T.TeamID));
            par.Add(new SqlParameter("@TeamName", T.TeamName));
            par.Add(new SqlParameter("@Details", T.Details));
            par.Add(new SqlParameter("@Banner", T.Banner));
            par.Add(new SqlParameter("@Logo", T.Logo));
            par.Add(new SqlParameter("@TournamentID", T.TournamentID));
            par.Add(new SqlParameter("@ManagerID", T.ManagerID));
            par.Add(new SqlParameter("@IsActive", T.IsActive));
            par.Add(new SqlParameter("@Points", T.Points));
            par.Add(new SqlParameter("@CurrentRound", T.CurrentRound));


            return DatabaseAccess.modifyData(query, par);

        }

        public static int delete(int TeamID)
        {
            String query = @"DELETE FROM Team WHERE TeamID=@TeamID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamID",TeamID));

            return DatabaseAccess.modifyData(query, par);

        }

        public static DataTable select()
        {
            String query = @"SELECT * FROM Team";
            List<SqlParameter> par = new List<SqlParameter>();

            return DatabaseAccess.selectData(query, par);

        }

        public static Team selectByID(int TeamID)
        {
            String query = @"SELECT * FROM Team WHERE TeamID=@TeamID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamID", TeamID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 1)
            {
               Team TM= new Team();
                TM.TeamID = Convert.ToInt32(dt.Rows[0]["TeamID"]);
                TM.TeamName =(dt.Rows[0]["TeamName"]).ToString();
                TM.Details =(dt.Rows[0]["Details"]).ToString();
                TM.Banner = (dt.Rows[0]["Banner"]).ToString();
                TM.Logo =(dt.Rows[0]["Logo"]).ToString();
                TM.TournamentID = Convert.ToInt32(dt.Rows[0]["TournamentID"]);
                TM.ManagerID = Convert.ToInt32(dt.Rows[0]["ManagerID"]);
                TM.IsActive = Convert.ToBoolean(dt.Rows[0]["isActive"]);
                TM.Points = Convert.ToInt32(dt.Rows[0]["Points"]);
                TM.CurrentRound = Convert.ToInt32(dt.Rows[0]["CurrentRound"]);
               
                return TM;

            }
            else
            {
                return new Team();
            }
        }
        public static DataTable selectByTournamentID(int TournamentID)
        {
            String query = @"SELECT * FROM Team WHERE TournamentID=@TournamentID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TournamentID", TournamentID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            return dt;
        }
        public static DataTable getTeams(int ID)
        {
            String query = @"SELECT * FROM Team WHERE ManagerID=@UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", ID)); ;

            return DatabaseAccess.selectData(query, par);

        }

        public static int isOwner(int ID)
        {
            String query = @"SELECT * FROM Team WHERE ManagerID=@UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", ID));

            DataTable dt = DatabaseAccess.selectData(query, par);
            return dt.Rows.Count;
        }
    }
}
