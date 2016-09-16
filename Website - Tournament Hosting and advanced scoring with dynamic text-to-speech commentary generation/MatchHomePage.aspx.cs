                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
using System.Data;

public partial class MatchHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            txtFixtureID.Text = ID.ToString();
            Fixture f = FixtureLogic.selectByID(ID);
            int tournamentId = TeamLogic.selectByID(f.TeamID1).TournamentID;

            Tournament tt = TournamentLogic.selectByID(tournamentId);

            Team teamobj1 = TeamLogic.selectByID(f.TeamID1);
            Team teamobj2 = TeamLogic.selectByID(f.TeamID2);
            lbltournamentname.Text = tt.Title;
            team1.Text = teamobj1.TeamName;
            team2.Text = teamobj2.TeamName;
            int overs = tt.TotalOvers;

            DataTable dt = DeliveryLogic.getCommentary(ID);
            lblCommentary.Text = dt.Rows[0]["Commentary"].ToString();
            lblDelNumber.Text = dt.Rows[0]["DelNumber"].ToString();
            lblDeliveryID.Text = dt.Rows[0]["DeliveryID"].ToString();

            //DataTable ft = FixtureLogic.selectByTournamentID(ID);
            //GridView3.DataSource = ft;
            //GridView3.DataBind();

            DataTable lineup = FixtureLogic.selectByFixtureID(ID);
            string tempteam1 = lineup.Rows[0]["Team1PlayingXI"].ToString();
            string tempteam2 = lineup.Rows[0]["Team2PlayingXI"].ToString();

            ArrayList Team1PlayingXI = new ArrayList();
            Team1PlayingXI.AddRange(tempteam1.Split(';'));

            ArrayList Team2PlayingXI = new ArrayList();
            Team2PlayingXI.AddRange(tempteam2.Split(';'));

            lineup = new DataTable();
            lineup.Columns.Add("Team1");
            lineup.Columns.Add("Team2");
            for (int i = 0; i < Team1PlayingXI.Count; i++)
            {
                lineup.Rows.Add(Team1PlayingXI[i], Team2PlayingXI[i]);

            }

            GridView2.DataSource = lineup;
            GridView2.DataBind();
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
}