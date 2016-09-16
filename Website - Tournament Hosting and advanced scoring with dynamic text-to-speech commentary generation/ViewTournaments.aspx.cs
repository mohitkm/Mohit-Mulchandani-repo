                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackendLogic;

public partial class ViewTournaments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = TournamentLogic.select();
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
}