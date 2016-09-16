                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackendLogic;

public partial class TeamHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Team t = (Team)Session["ID"];

        tname.Visible = true;

        int ID = Convert.ToInt32(Request.QueryString["ID"]);
        Team T = TeamLogic.selectByID(ID);
        tname.Text = T.TeamName;
        int ID2=ID;

        // DataTable dt = TournamentLogic.getTournaments(t.TournamentID);



        DataTable dt = TeamMemberLogic.getPlayerDetails(ID);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        DataTable dtt = FixtureLogic.selectByTeamID(ID, ID2);
        GridView2.DataSource = dtt;
        GridView2.DataBind();

        DataTable dttt = FixtureLogic.selectByTeamID(ID, ID2); 
        GridView3.DataSource = dttt;
        GridView3.DataBind();
    }
}