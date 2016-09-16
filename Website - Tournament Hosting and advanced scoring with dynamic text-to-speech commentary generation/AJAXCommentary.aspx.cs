                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
using System.Data;

public partial class AJAXCommentary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Fixture t = (Fixture)Session["ID"];
        int ID = Convert.ToInt32(Request.QueryString["ID"]);
        //txtFixtureID.Text = Request.QueryString["ID"];
        Fixture f = FixtureLogic.selectByID(ID);
        int tournamentId = TeamLogic.selectByID(f.TeamID1).TournamentID;

        Tournament tt = TournamentLogic.selectByID(tournamentId);

        Team teamobj1 = TeamLogic.selectByID(f.TeamID1);
        Team teamobj2 = TeamLogic.selectByID(f.TeamID2);
        //lbltournamentname.Text = tt.Title;
        //team1.Text = teamobj1.TeamName;
        //team2.Text = teamobj2.TeamName;
        int overs = tt.TotalOvers;

        DataTable dt = DeliveryLogic.getCommentary(ID);
        if (Request.QueryString["DelID"].ToString() == dt.Rows[0]["DeliveryID"].ToString())
        {
            Response.Clear();
            Response.Write("000");
            Response.Flush();
        }
        else
        {
            lblCommentary.Text = dt.Rows[0]["Commentary"].ToString();
            lblDelNumber.Text = dt.Rows[0]["DelNumber"].ToString();
            lblDeliveryID.Text = dt.Rows[0]["DeliveryID"].ToString();
        }
    }
}