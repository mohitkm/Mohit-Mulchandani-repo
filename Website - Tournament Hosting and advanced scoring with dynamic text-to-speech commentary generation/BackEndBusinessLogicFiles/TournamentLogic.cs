                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DatabaseConnectivity;

namespace BackendLogic
{
    public class TournamentLogic
    {
        public static int insert(Tournament T)
        {
            String query = @"INSERT INTO Tournament VALUES(@Title,@Details,@Sponsors,@Banner,@StartDate,@EndDate,@ManagerID,@ScoringType,@TournamentType,@TotalTeams,@TotalOvers)";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@Title", T.Title));
            par.Add(new SqlParameter("@Details", T.Details));
            par.Add(new SqlParameter("@Banner", T.Banner));
            par.Add(new SqlParameter("@Sponsors", T.Sponsors));
            par.Add(new SqlParameter("@StartDate", T.StartDate));
            par.Add(new SqlParameter("@EndDate", T.EndDate));
            par.Add(new SqlParameter("@ManagerID", T.ManagerID));
            par.Add(new SqlParameter("@ScoringType", T.ScoringType));
            par.Add(new SqlParameter("@TournamentType", T.TournamentType));
            par.Add(new SqlParameter("@TotalTeams", T.TotalTeams));
            par.Add(new SqlParameter("@TotalOvers", T.TotalOvers));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int update(Tournament T)
        {
            String query = @"UPDATE Tournament SET Title=@Title,Details=@Details,Banner=@Banner,Sponsor=@Sponsors,StartDate=@StartDate,EndDate=@EndDate,ManagerID=@ManagerID,ScoringType=@ScoringType,TournamentType=@TournamentType,TotalTeams=@TotalTeams,TotalOvers=@TotalOvers WHERE TournamentID=@TournamentID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TournamentID", T.TournamentID));
            par.Add(new SqlParameter("@Title", T.Title));
            par.Add(new SqlParameter("@Details", T.Details));
            par.Add(new SqlParameter("@Banner", T.Banner));
            par.Add(new SqlParameter("@Sponsors", T.Sponsors));
            par.Add(new SqlParameter("@StartDate", T.StartDate));
            par.Add(new SqlParameter("@EndDate", T.EndDate));
            par.Add(new SqlParameter("@ManagerID", T.ManagerID));
            par.Add(new SqlParameter("@ScoringType", T.ScoringType));
            par.Add(new SqlParameter("@TournamentType", T.TournamentType));
            par.Add(new SqlParameter("@TotalTeams", T.TotalTeams));
            par.Add(new SqlParameter("@TotalOvers", T.TotalOvers));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int delete(int TournamentID)
        {
            String query = @"DELETE FROM Tournament WHERE TournamentID=@TournamentID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TournamentID", TournamentID));

            return DatabaseAccess.modifyData(query, par);

        }

        public static DataTable select()
        {
            String query = @"SELECT T.*, U.Name AS ManagerName FROM Tournament T
                                INNER JOIN UserDetails U
                                ON T.ManagerID = U.UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            return DatabaseAccess.selectData(query, par);

        }

        public static Tournament selectByID(int TournamentID)
        {
            String query = @"SELECT * FROM Tournament WHERE TournamentID=@TournamentID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TournamentID", TournamentID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Tournament TM = new Tournament();
                TM.TournamentID = Convert.ToInt32(dt.Rows[0]["TournamentID"]);
                TM.Title = (dt.Rows[0]["Title"]).ToString();
                TM.Details = (dt.Rows[0]["Details"]).ToString();
                TM.Banner = (dt.Rows[0]["Banner"]).ToString();
                TM.Sponsors = (dt.Rows[0]["Sponsor"]).ToString();
                TM.StartDate = Convert.ToDateTime(dt.Rows[0]["StartDate"]);
                TM.EndDate = Convert.ToDateTime(dt.Rows[0]["EndDate"]);
                TM.ManagerID = Convert.ToInt32(dt.Rows[0]["ManagerID"]);
                TM.ScoringType = Convert.ToInt32(dt.Rows[0]["ScoringType"]);
                TM.TournamentType = Convert.ToInt32(dt.Rows[0]["TournamentType"]);
                TM.TotalTeams = Convert.ToInt32(dt.Rows[0]["TotalTeams"]);
                TM.TotalOvers = Convert.ToInt32(dt.Rows[0]["TotalOvers"]);
                return TM;

            }
            else
            {
                return new Tournament();
            }
        }

        public static DataTable getTournaments(int ID)
        {
            String query = @"SELECT * FROM Tournament WHERE ManagerID=@UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", ID)); ;

            return DatabaseAccess.selectData(query, par);

        }

        public static int isManager(int ID)
        {
            String query = @"SELECT * FROM Tournament WHERE ManagerID=@UserDetailID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", ID));

            DataTable dt = DatabaseAccess.selectData(query, par);
            return dt.Rows.Count;
        }
    }
}
