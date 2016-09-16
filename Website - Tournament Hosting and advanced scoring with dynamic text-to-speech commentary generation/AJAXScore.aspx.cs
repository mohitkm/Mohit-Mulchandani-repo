                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;

public partial class AJAXScore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["ID"]);
        Fixture f = FixtureLogic.selectByID(ID);
        int tournamentId = TeamLogic.selectByID(f.TeamID1).TournamentID;

        Tournament tt = TournamentLogic.selectByID(tournamentId);

        Team teamobj1 = TeamLogic.selectByID(f.TeamID1);
        Team teamobj2 = TeamLogic.selectByID(f.TeamID2);
        int overs = tt.TotalOvers;


        if (DeliveryLogic.getmaxdelivery(ID) <= (overs * 6))
        {
            lblTotalRuns.Text = DeliveryLogic.getfirstruns((overs * 6), f.FixtureID).ToString() + "/" + DeliveryLogic.getfirstwickets((overs * 6), f.FixtureID).ToString();
            // lblTotalOvers.Text = DeliveryLogic.getfirstruns((overs * 6), f.FixtureID).ToString();

            int overs1 = DeliveryLogic.getfirstovers((overs * 6), f.FixtureID) / 6;
            int balls = DeliveryLogic.getfirstovers((overs * 6), f.FixtureID) % 6;

            lblOvers.Text = overs1.ToString() + "." + balls.ToString();
            if (f.FirstBat == f.TeamID1)
            {
                lblfirstBat.Text = teamobj1.TeamName;

            }
            else
            {
                lblfirstBat.Text = teamobj2.TeamName;
            }
        }
        else
        {

            lblTotalRuns.Text = DeliveryLogic.getsecondruns((overs * 6), f.FixtureID).ToString() + "/" + DeliveryLogic.getsecondwickets((overs * 6), f.FixtureID).ToString();

            int overs2 = (DeliveryLogic.getsecondovers((overs * 6), f.FixtureID) - 120) / 6;
            int balls = (DeliveryLogic.getsecondovers((overs * 6), f.FixtureID) - 120) % 6;

            lblOvers.Text = overs2.ToString() + "." + balls.ToString();

            if (f.FirstBat == f.TeamID1)
            {
                lblfirstBat.Text = teamobj2.TeamName;

            }
            else
            {
                lblfirstBat.Text = teamobj1.TeamName;
            }
        }
    }
}