                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;

public partial class TournamentRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        

       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Tournament T = new Tournament();
        UserDetail U = new UserDetail(); 

        T.Title = txtTitle.Text;
        T.Details = txtDetails.Text;
        T.Sponsors = txtSponsor.Text;
        T.Banner = txtBanner.Text;
        T.StartDate = Convert.ToDateTime(txtStartDate.Text);
        T.EndDate = Convert.ToDateTime(txtEndDate.Text);
        if (RadioButton1.Checked)
            T.ScoringType = 1;
        else if (RadioButton2.Checked)
            T.ScoringType = 2;
        T.TournamentType = Convert.ToInt32(ddlTournamentType.SelectedValue);
      
        T.TotalTeams = Convert.ToInt32(txtTotalTeams.Text);
        T.TotalOvers = Convert.ToInt32(txtTotalOvers.Text);

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
        T.ManagerID = UserDetailLogic.getID(txtEmail.Text);

        TournamentLogic.insert(T);
        Response.Redirect("ViewTournaments.aspx");
    }
}