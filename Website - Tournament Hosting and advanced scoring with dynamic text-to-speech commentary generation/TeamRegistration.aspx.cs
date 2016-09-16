                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
public partial class TeamRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Team T = new Team();

        T.TeamName = txtTeamName.Text;
        T.Details = txtTeamDetails.Text;
        T.Banner = txtTeamBanner.Text;
        T.IsActive = true;
        String prefix = DateTime.Now.Ticks.ToString();
        T.Logo = prefix + FileUpload1.FileName;
        T.TournamentID = Convert.ToInt32(Request.QueryString["ID"]);
        FileUpload1.SaveAs(Server.MapPath("UserPhotos\\" + prefix + FileUpload1.FileName));

        UserDetail U = new UserDetail();
        U.Name = txtName.Text;
        U.Email = txtEmail.Text;
        U.Mobile = txtMobile.Text;
        U.Address = txtAddress.Text;
        U.IsActive = true;
        U.Password = "";
        U.UserType = "GU";

        String prefix1 = DateTime.Now.Ticks.ToString();
        U.Photo = prefix1 + FileUploadPhoto.FileName;
        FileUploadPhoto.SaveAs(Server.MapPath("UserPhotos\\" + prefix1 + FileUploadPhoto.FileName));


        UserDetailLogic.insert(U);
        T.ManagerID = UserDetailLogic.getID(txtEmail.Text);

        TeamLogic.insert(T);
        Response.Redirect("Default.aspx");

    }
}