                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDetail U = (UserDetail)Session["UserDetails"];
        lblName.Text = U.Name;
        lblName1.Text = U.Name;
        Image1.ImageUrl = "UserPhotos/" + U.Photo;
        Image2.ImageUrl = "UserPhotos/" + U.Photo;

        if (U.UserType == "Admin")
        {   
            AdminPlaceHolder.Visible = true;
        }
        
        DataTable dt = TournamentLogic.getTournaments(U.UserDetailID);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            ManagerPlaceHolder.Visible = true;

        }
        DataTable dt1 = TeamLogic.getTeams(U.UserDetailID);
        if (dt1.Rows.Count > 0)
        {
            Repeater2.DataSource = dt1;
            Repeater2.DataBind();
            OwnerPlaceHolder.Visible = true;

        }
    }
}
