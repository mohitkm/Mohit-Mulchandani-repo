                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseConnectivity;
using System.Data;
using System.Data.SqlClient;

namespace BackendLogic
{
    public class FixtureLogic
    {
        public static int insert(Fixture D)
        {
            String query = @"INSERT INTO Fixture VALUES(@TeamID1,@TeamID2,@Details,@ScDate,@ScVenue,@Result,@ScorerID,@Status,@TossResult,@FirstBat,@Umpire,@Team1PlayingXI,@Team2PlayingXI)";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamID1", D.TeamID1));
            par.Add(new SqlParameter("@TeamID2", D.TeamID2));
            par.Add(new SqlParameter("@Details", D.Details));
            par.Add(new SqlParameter("@ScDate", D.ScDate));
            par.Add(new SqlParameter("@ScVenue", D.ScVenue));
            par.Add(new SqlParameter("@Result", D.Result));
            par.Add(new SqlParameter("@ScorerID", D.ScorerID));
            par.Add(new SqlParameter("@Status", D.Status));
            par.Add(new SqlParameter("@TossResult", D.TossResult));
            par.Add(new SqlParameter("@FirstBat", D.FirstBat));
            par.Add(new SqlParameter("@Umpire", D.Umpire));
            par.Add(new SqlParameter("@Team1PlayingXI", D.Team1PlayingXI));
            par.Add(new SqlParameter("@Team2PlayingXI", D.Team2PlayingXI));


            return DatabaseAccess.modifyData(query, par);

        }

        public static int update(Fixture D)
        {
            String query = @"UPDATE Fixture SET TeamID1=@TeamID1,TeamID2=@TeamID2,Details=@Details,ScDate=@ScDate,ScVenue=@ScVenue,Result=@Result,ScorerID=@ScorerID,Status=@Status,TossResult=@TossResult,FirstBat=@FirstBat,Umpire=@Umpire WHERE FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@FixtureID", D.FixtureID));
            par.Add(new SqlParameter("@TeamID1", D.TeamID1));
            par.Add(new SqlParameter("@TeamID2", D.TeamID2));
            par.Add(new SqlParameter("@Details", D.Details));
            par.Add(new SqlParameter("@ScDate", D.ScDate));
            par.Add(new SqlParameter("@ScVenue", D.ScVenue));
            par.Add(new SqlParameter("@Result", D.Result));
            par.Add(new SqlParameter("@ScorerID", D.ScorerID));
            par.Add(new SqlParameter("@Status", D.Status));
            par.Add(new SqlParameter("@TossResult", D.TossResult));
            par.Add(new SqlParameter("@FirstBat", D.FirstBat));
            par.Add(new SqlParameter("@Umpire", D.Umpire));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int delete(int FixtureID)
        {
            String query = @"DELETE FROM Fixture WHERE FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@FixtureID", FixtureID));

            return DatabaseAccess.modifyData(query, par);

        }

        public static DataTable select()
        {
            String query = @"SELECT * FROM Fixture";
            List<SqlParameter> par = new List<SqlParameter>();

            return DatabaseAccess.selectData(query, par);

        }

        public static Fixture selectByID(int FixtureID)
        {
            String query = @"SELECT * FROM Fixture WHERE FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@FixtureID", FixtureID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Fixture CM = new Fixture();
                CM.FixtureID = Convert.ToInt32(dt.Rows[0]["FixtureID"]);
                CM.TeamID1 = Convert.ToInt32(dt.Rows[0]["TeamID1"]);
                CM.TeamID2 = Convert.ToInt32(dt.Rows[0]["TeamID2"]);
                CM.Details = dt.Rows[0]["Details"].ToString();
                CM.ScDate = Convert.ToDateTime(dt.Rows[0]["ScDate"]);
                CM.ScVenue = dt.Rows[0]["ScVenue"].ToString();
                CM.Result = Convert.ToInt32(dt.Rows[0]["Result"]);
                CM.ScorerID = Convert.ToInt32(dt.Rows[0]["ScorerID"]);
                CM.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
                CM.TossResult = Convert.ToInt32(dt.Rows[0]["TossResult"]);
                CM.FirstBat = Convert.ToInt32(dt.Rows[0]["FirstBat"]);
                CM.Umpire = dt.Rows[0]["Umpire"].ToString();
                CM.Team1PlayingXI = dt.Rows[0]["Team1PlayingXI"].ToString();
                CM.Team2PlayingXI = dt.Rows[0]["Team2PlayingXI"].ToString();

                return CM;

            }
            else
            {
                return new Fixture();
            }
        }

        public static DataTable selectByScorerID(int ScorerID)
        {
            String query = @"SELECT F.*, T1.TeamName AS 'TeamName1', T2.TeamName AS 'TeamName2'
                                FROM Fixture F
                                    inner join Team T1 ON T1.TeamID = F.TeamID1 
                                    inner join Team T2 ON T2.TeamID = F.TeamID2 
                                WHERE ScorerID=@ScorerID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@ScorerID", ScorerID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 0)
            {
                return new DataTable();
            }

            else
            {
                return dt;
            }
        }

        public static DataTable selectByScorerID(int ScorerID,int status)
        {
            String query = @"SELECT F.*, T1.TeamName AS 'TeamName1', T2.TeamName AS 'TeamName2'
                                FROM Fixture F
                                    inner join Team T1 ON T1.TeamID = F.TeamID1 
                                    inner join Team T2 ON T2.TeamID = F.TeamID2 
                                WHERE ScorerID=@ScorerID AND Status=@Status";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@ScorerID", ScorerID));
            par.Add(new SqlParameter("@Status", status));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 0)
            {
                return new DataTable();
            }

            else
            {
                return dt;
            }
        }

        public static int startScoring(int FixtureID, int FirstBat, int TossResult,string Team1PlayingXI, string Team2PlayingXI)
        {
            String query = @"UPDATE Fixture SET Status=@Status,FirstBat=@FirstBat, TossResult=@TossResult,Team1PlayingXI=@Team1PlayingXI, Team2PlayingXI=@Team2PlayingXI WHERE FixtureID=@FixtureID";

            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@Status", 3));
            par.Add(new SqlParameter("@FirstBat", FirstBat));
            par.Add(new SqlParameter("@TossResult", TossResult));
            par.Add(new SqlParameter("@FixtureID", FixtureID));
            par.Add(new SqlParameter("@Team1PlayingXI", Team1PlayingXI));
            par.Add(new SqlParameter("@Team2PlayingXI", Team2PlayingXI));


            return DatabaseAccess.modifyData(query, par);
        }

        public static DataTable selectByTournamentID(int TournamentID)
        {
            String query = @"SELECT F.*, T1.TeamName AS 'TeamName1', T2.TeamName AS 'TeamName2'
                            FROM Fixture AS F 
                            INNER JOIN Team AS T1 ON T1.TeamID = F.TeamID1
                            INNER JOIN Team AS T2 ON T2.TeamID = F.TeamID2
                            WHERE (F.TeamID1 IN  (SELECT DISTINCT TeamID FROM Team WHERE (TournamentID = @TournamentID)))";

            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TournamentID", TournamentID));

            DataTable ft = DatabaseAccess.selectData(query, par);

            return ft;
        }
        public static DataTable selectByFixtureID(int FixtureID)
        {
            String query = @"SELECT F.*, T1.TeamName AS 'TeamName1', T2.TeamName AS 'TeamName2', T3.ScoringType, T3.TotalOvers
                                FROM Fixture F
                                    inner join Team T1 ON T1.TeamID = F.TeamID1 
                                    inner join Team T2 ON T2.TeamID = F.TeamID2
                                    inner join Tournament T3 ON  T3.TournamentID = T1.TournamentID
                                WHERE FixtureID = @FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@FixtureID", FixtureID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            else
            {
                return dt;
            }
        }
        public static DataTable selectByTeamID(int TeamID1, int TeamID2)
        {
            String query = @"SELECT F.*, T1.TeamName AS 'TeamName1', T2.TeamName AS 'TeamName2' FROM FIXTURE F 
                            inner join Team T1 on T1.TeamID= F.TeamID1 
                            inner join Team T2 on T2.TeamID= F.TeamID2 
                            WHERE TeamID1=@TeamID1 OR TeamID2=@TeamID2";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@TeamID1", TeamID1));

            par.Add(new SqlParameter("@TeamID2", TeamID2));
            DataTable ft = DatabaseAccess.selectData(query, par);
            return ft;

        }
        public static DataTable selectByStatus(int Status)
        {
            String query = @"SELECT F.*, T1.TeamName AS 'TeamName1', T2.TeamName AS 'TeamName2' FROM FIXTURE F 
                            inner join Team T1 on T1.TeamID= F.TeamID1 
                            inner join Team T2 on T2.TeamID= F.TeamID2 
                            WHERE Status=@Status";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@Status", Status));

            DataTable dt = DatabaseAccess.selectData(query, par);
            return dt;
        }

        public static Fixture selectBySStatus(int Status)
        {
            String query = @"SELECT * FROM Fixture WHERE Status=@Status";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@Status", Status));

            DataTable dt = DatabaseAccess.selectData(query, par);

            Fixture CM = new Fixture();
            CM.FixtureID = Convert.ToInt32(dt.Rows[0]["FixtureID"]);
            CM.TeamID1 = Convert.ToInt32(dt.Rows[0]["TeamID1"]);
            CM.TeamID2 = Convert.ToInt32(dt.Rows[0]["TeamID2"]);
            CM.Details = dt.Rows[0]["Details"].ToString();
            CM.ScDate = Convert.ToDateTime(dt.Rows[0]["ScDate"]);
            CM.ScVenue = dt.Rows[0]["ScVenue"].ToString();
            CM.Result = Convert.ToInt32(dt.Rows[0]["Result"]);
            CM.ScorerID = Convert.ToInt32(dt.Rows[0]["ScorerID"]);
            // CM.Status = Convert.ToInt32(dt.Rows[0]["Status"]);
            CM.TossResult = Convert.ToInt32(dt.Rows[0]["TossResult"]);
            CM.FirstBat = Convert.ToInt32(dt.Rows[0]["FirstBat"]);
            CM.Umpire = dt.Rows[0]["Umpire"].ToString();
            CM.Team1PlayingXI = dt.Rows[0]["Team1PlayingXI"].ToString();
            CM.Team2PlayingXI = dt.Rows[0]["Team2PlayingXI"].ToString();
            //     CM.TournamentID = Convert.ToInt32(dt.Rows[0]["TournamentID"]);
            return CM;


        }

        public static DataTable getPlayersByTeam(int FixtureID)
        {
            String query = @"SELECT T.Team1PlayingXI, T.Team2PlayingXI FROM 
                            Fixture T
                             WHERE FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@FixtureID", FixtureID));

            return DatabaseAccess.selectData(query, par);
        }

    }
}
