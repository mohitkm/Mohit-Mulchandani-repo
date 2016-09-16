                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackendLogic;

public partial class TournamentHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Tournament t = (Tournament)Session["ID"];
        
        tname.Visible = true;

        int ID = Convert.ToInt32(Request.QueryString["ID"]);
        Tournament T = TournamentLogic.selectByID(ID);
        tname.Text = T.Title;
        stdate.Text = T.StartDate.ToString();
        endate.Text = T.EndDate.ToString();
       // DataTable dt = TournamentLogic.getTournaments(t.TournamentID);


      
        DataTable dt = TeamLogic.selectByTournamentID(ID);
        GridView1.DataSource = dt;
      
        GridView1.DataBind();
        
        GridView2.DataSource = dt;
        GridView2.DataBind();



        DataTable ft = FixtureLogic.selectByTournamentID(ID);
        GridView3.DataSource = ft;
        GridView3.DataBind();
      

       
         }
}