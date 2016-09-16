                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
using System.Data;

public partial class AndroidSupport : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Random rnd = new Random();
        TemplateUtility.initcomment();

        if (Request.Params["type"] == "Login")
        {

            String email = Request.QueryString["email"];
            String password = Request.QueryString["password"];
            int ID = UserDetailLogic.validate(email, password);
            if (ID != 0)
            {
                Response.Write(ID.ToString());

            }
            else
            {
                Response.Write("Failed");
            }


        }

        else if (Request.Params["type"] == "Outstanding")
        {
            int ScorerID = Convert.ToInt32(Request.Params["ScorerID"]);
            DataTable dt = FixtureLogic.selectByScorerID(ScorerID, 1);
            String oustanding = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    oustanding += (dt.Rows[i]["TeamName1"].ToString() + " Vs " + dt.Rows[i]["TeamName2"].ToString() + ":" + dt.Rows[i]["FixtureID"] + ";");
                }
                Response.Write(oustanding);
            }
            else
            {
                Response.Write("No Fixtures");
            }


        }

        else if (Request.Params["type"] == "Past")
        {
            int ScorerID = Convert.ToInt32(Request.Params["ScorerID"]);
            DataTable dt = FixtureLogic.selectByScorerID(ScorerID, 2);
            String past = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    past += (dt.Rows[i]["TeamName1"].ToString() + " Vs " + dt.Rows[i]["TeamName2"].ToString() + ":" + dt.Rows[i]["FixtureID"] + ";");
                }
                Response.Write(past);
            }
            else
            {
                Response.Write("No Fixtures");
            }


        }
        else if (Request.Params["type"] == "FixtureData")
        {
            int FixtureID = Convert.ToInt32(Request.Params["FixtureID"]);
            DataTable dt = FixtureLogic.selectByFixtureID(FixtureID);
            String res = "";
            if (dt.Rows[0]["Status"].ToString() == "1")
            {
                res = dt.Rows[0]["TeamName1"] + ";" + dt.Rows[0]["TeamID1"] + ";"
                    + dt.Rows[0]["TeamName2"] + ";" + dt.Rows[0]["TeamID2"] + ";"
                    + dt.Rows[0]["Status"] + ";" + dt.Rows[0]["Umpire"] + ";"
                    + dt.Rows[0]["ScoringType"] + ";" + dt.Rows[0]["TotalOvers"] + ";" + "1" + ";" + "1";
            }
            else if (dt.Rows[0]["Status"].ToString() == "2")
            {
                res = dt.Rows[0]["TeamName1"] + ";" + dt.Rows[0]["TeamID1"] + ";"
                    + dt.Rows[0]["TeamName2"] + ";" + dt.Rows[0]["TeamID2"] + ";"
                    + dt.Rows[0]["Status"] + ";" + dt.Rows[0]["Umpire"]
                    + dt.Rows[0]["ScoringType"] + ";" + dt.Rows[0]["TotalOvers"] + ";" + "0" + ";" + "0";
            }
            Response.Write(res);

        }
        else if (Request.Params["type"] == "StartScoring")
        {
            int x = FixtureLogic.startScoring(Convert.ToInt32(Request.Params["FixtureID"]),
                                                Convert.ToInt32(Request.Params["FirstBat"]),
                                                Convert.ToInt32(Request.Params["TossResult"]),
                                                Request.Params["Team1PlayingXI"].ToString(),
                                                Request.Params["Team2PlayingXI"].ToString());
            if (x == 1)
                Response.Write("Success");

            else
                Response.Write("Failed");




        }

        else if (Request.Params["type"] == "FixtureTeam1")
        {
            int TeamID = Convert.ToInt32(Request.Params["TeamID"]);
            DataTable dt = TeamMemberLogic.getPlayersByTeam(TeamID);
            String res = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                res += dt.Rows[i]["Name"] + ";" + dt.Rows[i]["UserDetailID"] + ";";
            }

            Response.Write(res);

        }

        else if (Request.Params["type"] == "FixtureTeam2")
        {
            int TeamID = Convert.ToInt32(Request.Params["TeamID"]);
            DataTable dt = TeamMemberLogic.getPlayersByTeam(TeamID);
            String res = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                res += dt.Rows[i]["Name"] + ";" + dt.Rows[i]["UserDetailID"] + ";";
            }

            Response.Write(res);

        }

        else if (Request.Params["type"] == "delivery")
        {

            try
            {
                int index, random;
                string commentary;
                string Batsman, Bowler, DPlayer, OBatsman;
                Delivery D = new Delivery();
                D.DelNumber = Convert.ToInt32(Request.Params["DeliveryNumber"]);
                D.BowlerID = Convert.ToInt32(Request.Params["Bowler"]);
                D.DeliveryLength = Request.Params["DeliveryLength"].ToString();
                D.DeliveryPosition = Request.Params["DeliveryPosition"].ToString();
                D.DeliveryType = Request.Params["DeliveryType"].ToString();
                D.OnStrikePlayerID = Convert.ToInt32(Request.Params["OnStrikePlayer"]);
                D.OffStrikePlayerID = Convert.ToInt32(Request.Params["OffStrikePlayer"]);
                D.StrikeType = Request.Params["StrikeType"].ToString();
                D.StrikeDirection = Request.Params["StrikeDirection"].ToString();
                D.StrikeElevation = Request.Params["StrikeElevation"].ToString();
                D.Runs = Convert.ToInt32(Request.Params["Runs"]);
                D.ExtraType = Convert.ToInt32(Request.Params["ExtraType"]);
                D.ExtraRuns = Convert.ToInt32(Request.Params["ExtraRun"]);
                D.DismissalType = Convert.ToInt32(Request.Params["DismissalType"]);
                D.DismissedPlayerID = Convert.ToInt32(Request.Params["DismissedPlayers"]);
                D.FixtureID = Convert.ToInt32(Request.Params["FixtureID"]);

                Batsman = Request.Params["BatsmanName"].ToString();
                Bowler = Request.Params["BowlerName"].ToString();
                OBatsman = Request.Params["OffBatsmanName"].ToString();
                DPlayer = Request.Params["DismissedPlayerName"].ToString();

                if (D.DismissalType > 0)
                {
                    switch (D.DismissalType)
                    {
                        //Bowled
                        case 1:
                            index = 7;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            if (random == 0 || random == 2)
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                            else
                                commentary = commentary.Replace("#SType", D.StrikeType);
                            break;

                        case 2:
                            index = 8;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            commentary = commentary.Replace("#SType", D.StrikeType);
                            commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            if (random == 1)
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                            break;

                        case 3:
                            index = 9;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            commentary = commentary.Replace("#SType", D.StrikeType);
                            commentary = commentary.Replace("#DType", D.DeliveryType);
                            break;

                        case 4:
                            index = 10;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            if (random == 2)
                                commentary = commentary.Replace("#SType", D.StrikeType);
                            break;

                        case 5:
                            index = 11;
                            if (D.Runs == 0)
                                random = rnd.Next(0, 1);
                            else
                                random = 2;
                            commentary = TemplateUtility.commentary[index, random];
                            commentary = commentary.Replace("#DPlayer", DPlayer);
                            if (random > 0)
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                                if (random > 1)
                                    commentary = commentary.Replace("#Run", D.Runs.ToString());
                            }

                            break;

                        case 6:
                            index = 12;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            commentary = commentary.Replace("#SType", D.StrikeType);
                            commentary = commentary.Replace("#DType", D.DeliveryType);

                            break;

                        default:
                            commentary = "#Bowler to #Batsman. No Commentary Generated";
                            break;
                    }
                }
                else if (D.ExtraType > 0 && D.Runs == 0)
                {
                    switch (D.ExtraType)
                    {
                        case 1:
                            index = 13;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            commentary = commentary.Replace("#ERuns", D.ExtraRuns.ToString());
                            break;

                        case 2:
                            index = 14;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            commentary = commentary.Replace("#ERuns", D.ExtraRuns.ToString());
                            commentary = commentary.Replace("#SType", D.StrikeType);
                            commentary = commentary.Replace("#DType", D.DeliveryType);
                            break;

                        case 3:
                            index = 15;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            break;

                        case 4:
                            index = 16;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            commentary = commentary.Replace("#DType", D.DeliveryType);
                            commentary = commentary.Replace("#DPosition", D.DeliveryPosition);
                            commentary = commentary.Replace("#ERuns", D.ExtraRuns.ToString());
                            break;

                        default:
                            commentary = "#Bowler to #Batsman. No Commentary Generated";
                            break;

                    }
                }
                else if (D.ExtraType == 3 && D.Runs > 0)
                {
                    index = D.Runs;
                    random = 2;
                    commentary = TemplateUtility.commentary[index, random];
                    commentary += TemplateUtility.commentary[15, 0];
                    switch (index)
                    {
                        case 1:
                            commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            break;
                        case 2:
                            commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            break;

                        case 3:
                            commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            break;

                        case 4:
                            commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            commentary = commentary.Replace("#DType", D.DeliveryType);
                            break;

                        case 6:
                            commentary = commentary.Replace("#SType", D.StrikeType);
                            commentary = commentary.Replace("#DType", D.DeliveryType);
                            break;

                        default:
                            commentary = "#Bowler to #Batsman. No Commentary Generated";
                            break;
                    }
                }
                else
                {
                    switch (D.Runs)
                    {
                        case 0:
                            index = 0;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            if (random == 0)
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                            else if (random == 1)
                            {
                                commentary = commentary.Replace("#SType", D.StrikeType);
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            }
                            else
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            }
                            break;

                        case 1:
                            index = 1;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            if (random == 0 || random == 2)
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            }
                            else
                            {
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                                commentary = commentary.Replace("#DPosition", D.DeliveryPosition);
                                commentary = commentary.Replace("#SType", D.StrikeType);
                            }
                            break;

                        case 2:
                            index = 2;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];

                            if (random == 0)
                            {
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                                commentary = commentary.Replace("#SType", D.StrikeType);
                            }
                            else if (random == 2)
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            }
                            break;

                        case 3:
                            index = 3;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            if (random == 0)
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                            else if (random == 1)
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                                commentary = commentary.Replace("#OBatsman", OBatsman);
                            }
                            else
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                                commentary = commentary.Replace("#SType", D.StrikeType);
                            }
                            break;

                        case 4:
                            index = 4;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];
                            if (random == 0)
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                                commentary = commentary.Replace("#SType", D.StrikeType);
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                            }
                            else if (random == 1)
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                                commentary = commentary.Replace("#SType", D.StrikeType);
                                commentary = commentary.Replace("#SElevation", D.StrikeElevation);
                            }
                            else
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                            }
                            break;

                        case 6:
                            index = 6;
                            random = rnd.Next(0, 2);
                            commentary = TemplateUtility.commentary[index, random];

                            if (random == 0 || random == 1)
                            {
                                commentary = commentary.Replace("#SDirection", D.StrikeDirection);
                                commentary = commentary.Replace("#SType", D.StrikeType);
                            }
                            else
                            {
                                commentary = commentary.Replace("#SType", D.StrikeType);
                                commentary = commentary.Replace("#DType", D.DeliveryType);
                            }
                            break;

                        default:
                            commentary = "#Bowler to #Batsman. No Commentary Generated";
                            break;
                    }
                }

                commentary = commentary.Replace("#Batsman", Batsman);
                commentary = commentary.Replace("#Bowler", Bowler);

                D.Commentary = commentary;
                int X = DeliveryLogic.insert(D);
                if (X == 1)
                {
                    Response.Write("SAVED");
                }
                else
                {
                    Response.Write("FAILED");
                }

            }
            catch (Exception ee)
            {
                Response.Write(ee.Message);
            }


        }

    }
}