                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseConnectivity;
using BackendLogic;
using System.Data;

public partial class LiveScores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            int status = 3;

            Fixture f = FixtureLogic.selectBySStatus(status);
            DataTable dt = FixtureLogic.selectByStatus(status);
            //int tid = Convert.ToInt32(f.TournamentID);
            //Tournament t = TournamentLogic.selectByID(tid);

            int team1id = Convert.ToInt32(f.TeamID1);
            int team2id = Convert.ToInt32(f.TeamID2);

            GridView1.DataSource = dt;
            GridView1.DataBind();

        
        
    }

    
}