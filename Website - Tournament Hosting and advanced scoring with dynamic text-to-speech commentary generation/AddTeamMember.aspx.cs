                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;

public partial class AddTeamMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        UserDetail U = new UserDetail();
        U.Name = txtName.Text;
        U.Email = txtEmail.Text;
        U.Mobile = txtMobile.Text;
        U.Address = txtAddress.Text;
        U.IsActive = true;
        U.Password = "";
        U.UserType = "GU";

        String prefix = DateTime.Now.Ticks.ToString();
        U.Photo = prefix + FileUploadPhoto.FileName;
        FileUploadPhoto.SaveAs(Server.MapPath("UserPhotos\\" + prefix + FileUploadPhoto.FileName));

        UserDetailLogic.insert(U);
        int ID = UserDetailLogic.getID(txtEmail.Text);

        TeamMember T = new TeamMember();
        T.UserDetailID = ID;
        T.TeamID = Convert.ToInt32(Request.QueryString["ID"]) ;
        T.IsActive = true;
        T.Details = txtDetails.Text;
        T.Matches = 0;
        T.Runs = 0;
        T.BattingAverage = 0;
        T.Hundred = 0;
        T.Fifty = 0;
        T.TopScore = 0;
        T.Wickets = 0;
        T.FiveWickets = 0;
        T.BestBowling = 0;
        T.Catches = 0;

        TeamMemberLogic.insert(T);

        Response.Redirect("Default.aspx");

    }
}