                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
using System.Data;

public partial class ViewTeamMembers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = TeamMemberLogic.getPlayerDetails(Convert.ToInt32(Request.QueryString["ID"]));
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}