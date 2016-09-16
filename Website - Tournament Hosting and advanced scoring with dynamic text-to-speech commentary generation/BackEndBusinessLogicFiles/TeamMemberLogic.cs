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
    public class TeamMemberLogic
    {
        public static int insert(TeamMember D)
        {
            String query = @"INSERT INTO TeamMember VALUES(@UserDetailID,@TeamID,@IsActive,@Details,@Matches,@Runs,@BattingAverage,@Hundred,@Fifty,@TopScore,@Wickets,@FiveWickets,@BestBowling,@Catches)";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@UserDetailID", D.UserDetailID));
            par.Add(new SqlParameter("@TeamID", D.TeamID));
            par.Add(new SqlParameter("@IsActive", D.IsActive));
            par.Add(new SqlParameter("@Details", D.Details));
            par.Add(new SqlParameter("@Matches", D.Matches));
            par.Add(new SqlParameter("@Runs", D.Runs));
            par.Add(new SqlParameter("@BattingAverage", D.BattingAverage));
            par.Add(new SqlParameter("@Hundred", D.Hundred));
            par.Add(new SqlParameter("@Fifty", D.Fifty));
            par.Add(new SqlParameter("@TopScore", D.TopScore));
            par.Add(new SqlParameter("@Wickets", D.Wickets));
            par.Add(new SqlParameter("@FiveWickets", D.FiveWickets));
            par.Add(new SqlParameter("@BestBowling", D.BestBowling));
            par.Add(new SqlParameter("@Catches", D.Catches));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int update(TeamMember D)
        {
            String query = @"UPDATE TeamMember SET UserDetailID=@UserDetailID,TeamID=@TeamID,IsActive=@IsActive,Details=@Details,Matches=@Matches,Runs=@Runs,BattingAverage=@BattingAverage,Hundred=@Hundred,Fifty=@Fifty,TopScore=@TopScore,Wickets=@Wickets,FiveWickets=@FiveWickets,BestBowling=@BestBowling,Catches=@Catches WHERE TeamMemberID=@TeamMemberID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamMemberID", D.TeamMemberID));
            par.Add(new SqlParameter("@UserDetailID", D.UserDetailID));
            par.Add(new SqlParameter("@TeamID", D.TeamID));
            par.Add(new SqlParameter("@IsActive", D.IsActive));
            par.Add(new SqlParameter("@Details", D.Details));
            par.Add(new SqlParameter("@Matches", D.Matches));
            par.Add(new SqlParameter("@Runs", D.Runs));
            par.Add(new SqlParameter("@BattingAverage", D.BattingAverage));
            par.Add(new SqlParameter("@Hundred", D.Hundred));
            par.Add(new SqlParameter("@Fifty", D.Fifty));
            par.Add(new SqlParameter("@TopScore", D.TopScore));
            par.Add(new SqlParameter("@Wickets", D.Wickets));
            par.Add(new SqlParameter("@FiveWickets", D.FiveWickets));
            par.Add(new SqlParameter("@BestBowling", D.BestBowling));
            par.Add(new SqlParameter("@Catches", D.Catches));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int delete(int TeamMemberID)
        {
            String query = @"DELETE FROM TeamMember WHERE TeamMemberID=@TeamMemberID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamMemberID", TeamMemberID));

            return DatabaseAccess.modifyData(query, par);

        }

        public static DataTable select()
        {
            String query = @"SELECT * FROM TeamMember";
            List<SqlParameter> par = new List<SqlParameter>();

            return DatabaseAccess.selectData(query, par);

        }

        public static TeamMember selectByID(int TeamMemberID)
        {
            String query = @"SELECT * FROM TeamMember WHERE TeamMemberID=@TeamMemberID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamMemberID", TeamMemberID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 1)
            {
                TeamMember CM = new TeamMember();
                CM.TeamMemberID = Convert.ToInt32(dt.Rows[0]["TeamMemberID"]);
                CM.UserDetailID = Convert.ToInt32(dt.Rows[0]["UserDetailID"]);
                CM.TeamID = Convert.ToInt32(dt.Rows[0]["TeamID"]);
                CM.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                CM.Details =(dt.Rows[0]["Details"]).ToString();
                CM.Matches = Convert.ToInt32(dt.Rows[0]["Matches"]);
                CM.Hundred = Convert.ToInt32(dt.Rows[0]["Hundred"]);
                CM.Runs = Convert.ToInt32(dt.Rows[0]["Runs"]);
                CM.BattingAverage = Convert.ToInt32(dt.Rows[0]["BattingAverage"]);
                CM.Fifty = Convert.ToInt32(dt.Rows[0]["Fifty"]);
                CM.FiveWickets = Convert.ToInt32(dt.Rows[0]["FiveWickets"]);
                CM.BestBowling = Convert.ToInt32(dt.Rows[0]["BestBowling"]);
                CM.Wickets = Convert.ToInt32(dt.Rows[0]["Wickets"]);
                CM.Catches = Convert.ToInt32(dt.Rows[0]["Catches"]);
                CM.TopScore = Convert.ToInt32(dt.Rows[0]["TopScore"]);
              
                return CM;

            }
            else
            {
                return new TeamMember();
            }
        }

        public static DataTable getPlayerDetails(int ID)
        {
            String query = @"SELECT * FROM UserDetails WHERE UserDetailID IN(SELECT UserDetailID FROM TeamMember WHERE TeamID=@TeamID)";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamID", ID));

            return DatabaseAccess.selectData(query, par);

        }

        public static DataTable getPlayersByTeam(int TeamID)
        {
            String query = @"SELECT T.UserDetailID,T.TeamID,U.Name FROM 
                            TeamMember T
                            inner join UserDetails U on T.UserDetailID = U.UserDetailID                                 
                             WHERE TeamID=@TeamID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamID", TeamID));

            return DatabaseAccess.selectData(query, par);
        }
    }
}
