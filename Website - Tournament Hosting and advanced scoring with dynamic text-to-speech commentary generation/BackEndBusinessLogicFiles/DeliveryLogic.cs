                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseConnectivity;
using System.Data.SqlClient;
using System.Data;

namespace BackendLogic
{
    public class DeliveryLogic
    {
        public static int insert(Delivery D)
        {
            String query = @"INSERT INTO Delivery VALUES(@DelNumber,@BowlerID,@DeliveryLength,@DeliveryPosition,@OnStrikePlayerID,@OffStrikePlayerID,@DeliveryType,@StrikeType,@StrikeDirection,@StrikeElevation,@Runs,@ExtraType,@DismissalType,@DismissedPlayerID,@ExtraRuns,@Commentary,@FixtureID)";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@DelNumber", D.DelNumber));
            par.Add(new SqlParameter("@BowlerID", D.BowlerID));
            par.Add(new SqlParameter("@DeliveryLength", D.DeliveryLength));
            par.Add(new SqlParameter("@DeliveryPosition", D.DeliveryPosition));
            par.Add(new SqlParameter("@OnStrikePlayerID", D.OnStrikePlayerID));
            par.Add(new SqlParameter("@OffStrikePlayerID", D.OffStrikePlayerID));
            par.Add(new SqlParameter("@DeliveryType", D.DeliveryType));
            par.Add(new SqlParameter("@StrikeType", D.StrikeType));
            par.Add(new SqlParameter("@StrikeDirection", D.StrikeDirection));
            par.Add(new SqlParameter("@StrikeElevation", D.StrikeElevation));
            par.Add(new SqlParameter("@Runs", D.Runs));
            par.Add(new SqlParameter("@ExtraType", D.ExtraType));
            par.Add(new SqlParameter("@DismissalType", D.DismissalType));
            par.Add(new SqlParameter("@DismissedPlayerID", D.DismissedPlayerID));
            par.Add(new SqlParameter("@ExtraRuns", D.ExtraRuns));
            par.Add(new SqlParameter("@Commentary", D.Commentary));
            par.Add(new SqlParameter("@FixtureID", D.FixtureID));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int update(Delivery D)
        {
            String query = @"UPDATE Delivery SET DelNumber=@DelNumber,BowlerID=@BowlerID,DeliveryLength=@DeliveryLength,DeliveryPosition=@DeliveryPosition,OnStrikePlayerID=@OnStrikePlayerID,OffStrikePlayerID=@OffStrikePlayerID,DeliveryType=@DeliveryType,StrikeType=@StrikeType,StrikeDirection=@StrikeDirection,StrikeElevation=@StrikeElevation,Runs=@Runs,ExtraType=@ExtraType,DismissalType=@DismissalType,DismissedPlayerID=@DismissedPlayerID,ExtraRuns=@ExtraRuns,Commentary=@Commentary, FixtureID=@FixtureID WHERE DeliveryID=@DeliveryID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@DeliveryID", D.DeliveryID));
            par.Add(new SqlParameter("@DelNumber", D.DelNumber));
            par.Add(new SqlParameter("@BowlerID", D.BowlerID));
            par.Add(new SqlParameter("@DeliveryLength", D.DeliveryLength));
            par.Add(new SqlParameter("@DeliveryPosition", D.DeliveryPosition));
            par.Add(new SqlParameter("@OnStrikePlayerID", D.OnStrikePlayerID));
            par.Add(new SqlParameter("@OffStrikePlayerID", D.OffStrikePlayerID));
            par.Add(new SqlParameter("@DeliveryType", D.DeliveryType));
            par.Add(new SqlParameter("@StrikeType", D.StrikeType));
            par.Add(new SqlParameter("@StrikeDirection", D.StrikeDirection));
            par.Add(new SqlParameter("@StrikeElevation", D.StrikeElevation));
            par.Add(new SqlParameter("@Runs", D.Runs));
            par.Add(new SqlParameter("@ExtraType", D.ExtraType));
            par.Add(new SqlParameter("@DismissalType", D.DismissalType));
            par.Add(new SqlParameter("@DismissedPlayerID", D.DismissedPlayerID));
            par.Add(new SqlParameter("@ExtraRuns", D.ExtraRuns));
            par.Add(new SqlParameter("@Commentary", D.Commentary));
            par.Add(new SqlParameter("@FixtureID", D.FixtureID));

            return DatabaseAccess.modifyData(query, par);

        }

        public static int delete(int DeliveryID)
        {
            String query = @"DELETE FROM Delivery WHERE DeliveryID=@DeliveryID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@DeliveryID", DeliveryID));

            return DatabaseAccess.modifyData(query, par);

        }

        public static DataTable select()
        {
            String query = @"SELECT * FROM Delivery";
            List<SqlParameter> par = new List<SqlParameter>();

            return DatabaseAccess.selectData(query, par);

        }

        public static Delivery selectByID(int DeliveryID)
        {
            String query = @"SELECT * FROM Delivery WHERE DeliveryID=@DeliveryID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@DeliveryID", DeliveryID));

            DataTable dt = DatabaseAccess.selectData(query, par);

            if (dt.Rows.Count == 1)
            {
                Delivery CM = new Delivery();
                CM.DeliveryID = Convert.ToInt32(dt.Rows[0]["DeliveryID"]);
                CM.DelNumber = Convert.ToInt32(dt.Rows[0]["DelNumber"]);
                CM.BowlerID = Convert.ToInt32(dt.Rows[0]["BowlerID"]);
                CM.DeliveryLength = dt.Rows[0]["DeliveryLength"].ToString();
                CM.DeliveryPosition = dt.Rows[0]["DeliveryPosition"].ToString();
                CM.DeliveryType = dt.Rows[0]["DeliveryType"].ToString();
                CM.OnStrikePlayerID = Convert.ToInt32(dt.Rows[0]["OnStrikePlayerID"]);
                CM.OffStrikePlayerID = Convert.ToInt32(dt.Rows[0]["OffStrikePlayerID"]);
                CM.StrikeType = dt.Rows[0]["StrikeType"].ToString();
                CM.StrikeElevation = dt.Rows[0]["StrikeElevation"].ToString();
                CM.StrikeDirection = dt.Rows[0]["StrikeDirection"].ToString();
                CM.Runs = Convert.ToInt32(dt.Rows[0]["Runs"]);
                CM.ExtraType = Convert.ToInt32(dt.Rows[0]["ExtraType"]);
                CM.DismissalType = Convert.ToInt32(dt.Rows[0]["DismissalType"]);
                CM.DismissedPlayerID = Convert.ToInt32(dt.Rows[0]["DismissedPlayerID"]);
                CM.ExtraRuns = Convert.ToInt32(dt.Rows[0]["ExtraRuns"]);
                CM.Commentary = (dt.Rows[0]["Commmentary"]).ToString();
                CM.FixtureID = Convert.ToInt32(dt.Rows[0]["FixtureID"]);

                return CM;

            }
            else
            {
                return new Delivery();
            }
        }
        public static Delivery selectByFixtureID(int FixtureID)
        {
            String query = @"SELECT * FROM Delivery WHERE FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@FixtureID", FixtureID));

            DataTable dt = DatabaseAccess.selectData(query, par);


            Delivery CM = new Delivery();
            CM.DeliveryID = Convert.ToInt32(dt.Rows[0]["DeliveryID"]);
            CM.DelNumber = Convert.ToInt32(dt.Rows[0]["DelNumber"]);
            CM.BowlerID = Convert.ToInt32(dt.Rows[0]["BowlerID"]);
            CM.DeliveryLength = (dt.Rows[0]["DeliveryLength"]).ToString();
            CM.DeliveryPosition = (dt.Rows[0]["DeliveryPosition"]).ToString();
            CM.DeliveryType = (dt.Rows[0]["DeliveryType"]).ToString();
            CM.OnStrikePlayerID = Convert.ToInt32(dt.Rows[0]["OnStrikePlayerID"]);
            CM.OffStrikePlayerID = Convert.ToInt32(dt.Rows[0]["OffStrikePlayerID"]);
            CM.StrikeType = (dt.Rows[0]["StrikeType"]).ToString();
            CM.StrikeElevation = (dt.Rows[0]["StrikeElevation"]).ToString();
            CM.StrikeDirection = (dt.Rows[0]["StrikeDirection"]).ToString();
            CM.Runs = Convert.ToInt32(dt.Rows[0]["Runs"]);
            CM.ExtraType = Convert.ToInt32(dt.Rows[0]["ExtraType"]);
            CM.DismissalType = Convert.ToInt32(dt.Rows[0]["DismissalType"]);
            CM.DismissedPlayerID = Convert.ToInt32(dt.Rows[0]["DismissedPlayerID"]);
            CM.ExtraRuns = Convert.ToInt32(dt.Rows[0]["ExtraRuns"]);
            CM.Commentary = (dt.Rows[0]["Commmentary"]).ToString();

            return CM;


        }

        public static int getmaxdelivery(int FixtureID)
        {

            String query = @"SELECT MAX(DelNumber) AS MaxDel FROM Delivery WHERE FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(new SqlParameter("@FixtureID", FixtureID));

            DataTable dt = DatabaseAccess.selectData(query, par);
            return Convert.ToInt32(dt.Rows[0]["MaxDel"]);


        }

        public static int getfirstruns(int MaxDelNumber, int FixtureID)
        {
            String query = @"SELECT (SUM(Runs)+ SUM(ExtraRuns)) AS TotalRuns FROM Delivery WHERE DelNumber<=@MaxDelNumber AND FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@MaxDelNumber", MaxDelNumber));
            par.Add(new SqlParameter("@FixtureID", FixtureID));


            DataTable dt = DatabaseAccess.selectData(query, par);
            return Convert.ToInt32(dt.Rows[0]["TotalRuns"]);


        }

        public static int getsecondruns(int MaxDelNumber, int FixtureID)
        {
            String query = @"SELECT (SUM(Runs)+ SUM(ExtraRuns)) AS TotalRuns FROM Delivery WHERE DelNumber>@MaxDelNumber AND FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@MaxDelNumber", MaxDelNumber));
            par.Add(new SqlParameter("@FixtureID", FixtureID));


            DataTable dt = DatabaseAccess.selectData(query, par);
            return Convert.ToInt32(dt.Rows[0]["TotalRuns"]);

        }


        public static int getfirstovers(int MaxDelNumber, int FixtureID)
        {
            String query = @"SELECT MAX(DelNumber) AS TotalBalls FROM Delivery WHERE DelNumber<=@MaxDelNumber AND FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@MaxDelNumber", MaxDelNumber));
            par.Add(new SqlParameter("@FixtureID", FixtureID));


            DataTable dt = DatabaseAccess.selectData(query, par);
            return Convert.ToInt32(dt.Rows[0]["TotalBalls"]);


        }

        public static int getsecondovers(int MaxDelNumber, int FixtureID)
        {
            String query = @"SELECT MAX(DelNumber) AS TotalBalls FROM Delivery WHERE DelNumber>@MaxDelNumber AND FixtureID=@FixtureID";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@MaxDelNumber", MaxDelNumber));
            par.Add(new SqlParameter("@FixtureID", FixtureID));


            DataTable dt = DatabaseAccess.selectData(query, par);
            return Convert.ToInt32(dt.Rows[0]["TotalBalls"]);

        }
        public static int getfirstwickets(int MaxDelNumber, int FixtureID)
        {
            String query = @"SELECT COUNT(DismissalType) AS Expr1 FROM Delivery WHERE (DismissalType > 0) AND (DelNumber <= @MaxDelNumber) AND (FixtureID = @FixtureID)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@MaxDelNumber", MaxDelNumber));
            par.Add(new SqlParameter("@FixtureID", FixtureID));


            DataTable dt = DatabaseAccess.selectData(query, par);
            return Convert.ToInt32(dt.Rows[0]["Expr1"]);

        }
        public static int getsecondwickets(int MaxDelNumber, int FixtureID)
        {
            String query = @"SELECT COUNT(DismissalType) AS Expr1 FROM Delivery WHERE (DismissalType > 0) AND (DelNumber > @MaxDelNumber) AND (FixtureID = @FixtureID)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@MaxDelNumber", MaxDelNumber));
            par.Add(new SqlParameter("@FixtureID", FixtureID));


            DataTable dt = DatabaseAccess.selectData(query, par);
            return Convert.ToInt32(dt.Rows[0]["Expr1"]);

        }

        public static DataTable getCommentary(int FixtureID)
        {
            String query = @"SELECT TOP 1 DeliveryID,DelNumber,Commentary FROM Delivery WHERE FixtureID = @FixtureID ORDER By DeliveryID DESC";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@FixtureID", FixtureID));

            DataTable dt = DatabaseAccess.selectData(query, par);
            return dt;

        }

        public static DataTable getAppCommentary(int FixtureID)
        {
            String query = @"SELECT DeliveryID, DelNumber, DelNumber / 6 AS Overs, DelNumber % 6 AS OverBalls, Commentary
 FROM Delivery WHERE FixtureID = @FixtureID ORDER By DeliveryID DESC";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@FixtureID", FixtureID));

            DataTable dt = DatabaseAccess.selectData(query, par);
            return dt;

        }

        public static string getBatsmenScore(int FixtureID)
        {
            string batDetails = "";

            string query = @"SELECT TOP (1) OnStrikePlayerID, OffStrikePlayerID FROM Delivery WHERE (FixtureID = @FixtureID) ORDER BY DeliveryID DESC";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@FixtureID", FixtureID));

            DataTable dt = DatabaseAccess.selectData(query, par);
            int bat1ID = Convert.ToInt32(dt.Rows[0]["OnStrikePlayerID"]);
            int bat2ID = Convert.ToInt32(dt.Rows[0]["OffStrikePlayerID"]);

            List<SqlParameter> par1 = new List<SqlParameter>();
            par1.Add(new SqlParameter("@bat1ID", bat1ID));

            List<SqlParameter> par2 = new List<SqlParameter>();
            par2.Add(new SqlParameter("@FixtureID", FixtureID));
            par2.Add(new SqlParameter("@bat1ID", bat1ID));

            List<SqlParameter> par4 = new List<SqlParameter>();
            par4.Add(new SqlParameter("@FixtureID", FixtureID));
            par4.Add(new SqlParameter("@bat2ID", bat2ID));
            

            List<SqlParameter> par3 = new List<SqlParameter>();
            par3.Add(new SqlParameter("@bat2ID", bat2ID));

            string query1 = @"SELECT Name FROM UserDetails WHERE (UserDetailID = @bat1ID)";
            string query2 = @"SELECT COUNT(*) AS Deliveries, SUM(Runs) AS Runs FROM Delivery WHERE (OnStrikePlayerID = @bat1ID) AND (FixtureID = @FixtureID) AND (ExtraType < 3)";
            string query3 = @"SELECT Name FROM UserDetails WHERE (UserDetailID = @bat2ID)";
            string query4 = @"SELECT COUNT(*) AS Deliveries, SUM(Runs) AS Runs FROM Delivery WHERE (OnStrikePlayerID = @bat2ID) AND (FixtureID = @FixtureID) AND (ExtraType < 3)";

            DataTable dt1 = DatabaseAccess.selectData(query1, par1);
            DataTable dt2 = DatabaseAccess.selectData(query2, par2);
            batDetails += dt1.Rows[0]["Name"].ToString() + "     " + dt2.Rows[0]["Runs"].ToString() + "(" + dt2.Rows[0]["Deliveries"].ToString() + ");";

            dt1 = DatabaseAccess.selectData(query3, par3);
            dt2 = DatabaseAccess.selectData(query4, par4);

            batDetails += dt1.Rows[0]["Name"].ToString() + "     " + dt2.Rows[0]["Runs"].ToString() + "(" + dt2.Rows[0]["Deliveries"].ToString() + ");";

            return batDetails;
        }


    }
}