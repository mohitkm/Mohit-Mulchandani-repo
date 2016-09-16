                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
using System.Data;

public partial class ClientAndroid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["type"] == "GetLiveMatches")
        {
            DataTable dt = FixtureLogic.selectByStatus(3);
            String fixtures = "";
            if (dt.Rows.Count == 0)
                Response.Write("Failed");
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fixtures += (dt.Rows[i]["TeamName1"].ToString() + " Vs " + dt.Rows[i]["TeamName2"].ToString() + ":" + dt.Rows[i]["FixtureID"] + ";");
                }
                Response.Write(fixtures);
            }
        }
        else if (Request.Params["type"] == "FixtureData")
        {
            int runs,wickets,overs;
            string teamName;
            int FixtureID = Convert.ToInt32(Request.Params["FixtureID"]);
            DataTable dt = FixtureLogic.selectByFixtureID(FixtureID);
            if (dt.Rows[0]["FirstBat"].ToString() == dt.Rows[0]["TeamID1"].ToString())
                teamName = dt.Rows[0]["TeamName1"].ToString();
            else
                teamName = dt.Rows[0]["TeamName2"].ToString();

            runs = DeliveryLogic.getfirstruns(120, FixtureID);
            wickets = DeliveryLogic.getfirstwickets(120, FixtureID);
            overs = DeliveryLogic.getfirstovers(120, FixtureID);
            String res = "";
            res = dt.Rows[0]["TeamName1"] + ";" + dt.Rows[0]["TeamID1"] + ";"
                + dt.Rows[0]["TeamName2"] + ";" + dt.Rows[0]["TeamID2"] + ";"
                + teamName + ";" + runs.ToString() + "/" + wickets.ToString() + ";" + (overs / 6).ToString() + "." + (overs % 6).ToString(); 
            Response.Write(res);

        }
        else if (Request.Params["type"] == "FixtureTeam1")
        {
            int FixtureID = Convert.ToInt32(Request.Params["FixtureID"]);
            DataTable dt = FixtureLogic.getPlayersByTeam(FixtureID);
            string res = "";
            res = dt.Rows[0]["Team1PlayingXI"].ToString();
            Response.Write(res);

        }

        else if (Request.Params["type"] == "FixtureTeam2")
        {
            int FixtureID = Convert.ToInt32(Request.Params["FixtureID"]);
            DataTable dt = FixtureLogic.getPlayersByTeam(FixtureID);
            string res = "";
            res = dt.Rows[0]["Team2PlayingXI"].ToString();
            Response.Write(res);

        }
        else if (Request.Params["type"] == "GetBatsmenScore")
        {
            int FixtureID = Convert.ToInt32(Request.Params["FixtureID"]);
            string res = DeliveryLogic.getBatsmenScore(FixtureID);
            Response.Write(res);
        }
        else if (Request.Params["type"] == "GetCommentary")
        {
            int FixtureID = Convert.ToInt32(Request.Params["FixtureID"]);
            DataTable dt = DeliveryLogic.getAppCommentary(FixtureID);
            string res = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                res += dt.Rows[i]["Overs"].ToString() + "." + dt.Rows[i]["OverBalls"] + "  " + dt.Rows[i]["Commentary"].ToString() + "#####";
            }

            Response.Write(res);

        }

    }
}