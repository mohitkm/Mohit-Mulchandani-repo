                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
using System.Data;

public partial class ScorerHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDetail U = (UserDetail)Session["UserDetails"];
        int id = Convert.ToInt32(U.UserDetailID);
        DataTable dt = FixtureLogic.selectByScorerID(id);
         g1.DataSource = dt;
         g1.DataBind();
    
    }
}