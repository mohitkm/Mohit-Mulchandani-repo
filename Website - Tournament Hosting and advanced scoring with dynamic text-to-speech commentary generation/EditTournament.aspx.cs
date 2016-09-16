                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;

public partial class EditTournament : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);

            Tournament T = TournamentLogic.selectByID(ID);
            txtTournamentID.Text = ID.ToString();
            txtTitle.Text = T.Title;
            txtDetails.Text = T.Details;
            txtSponsor.Text = T.Sponsors;
            txtBanner.Text = T.Banner;
            txtStartDate.Text = T.StartDate.ToString();
            txtEndDate.Text = T.EndDate.ToString();
            if (T.ScoringType == 1)
                RadioButton1.Checked = true;
            else
                RadioButton2.Checked = true;

            ddlTournamentType.SelectedValue = T.TournamentType.ToString();
            txtNumbOfTeams.Text = T.TotalTeams.ToString();
            txtTotalOvers.Text = T.TotalOvers.ToString();
            
            UserDetail U = UserDetailLogic.selectByID(T.ManagerID);
            txtManagerID.Text = T.ManagerID.ToString();
            txtName.Text = U.Name;
            txtEmail.Text = U.Email;
            txtMobile.Text = U.Mobile;
            txtAddress.Text = U.Address;

            //FileUploadPhoto. = U.Photo;
        }

    }
    protected void btnSaveChanges_Click(object sender, EventArgs e)
    {
        Tournament T = new Tournament();
        UserDetail U = new UserDetail();

        T.TournamentID = Convert.ToInt32(txtTournamentID.Text);
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
        T.TotalTeams = Convert.ToInt32(txtNumbOfTeams.Text);
        T.ManagerID = Convert.ToInt32(txtManagerID.Text);
        T.TotalOvers = Convert.ToInt32(txtTotalOvers.Text);

        U.UserDetailID = Convert.ToInt32(txtManagerID.Text);
        U.Name = txtName.Text;
        U.Email = txtEmail.Text;
        U.Mobile = txtMobile.Text;
        U.Address = txtAddress.Text;
        
        String prefix = DateTime.Now.Ticks.ToString();
        U.Photo = prefix + FileUploadPhoto.FileName;
        FileUploadPhoto.SaveAs(Server.MapPath("UserPhotos\\" + prefix + FileUploadPhoto.FileName));

        UserDetailLogic.update(U);
        TournamentLogic.update(T);

        Response.Redirect("ViewTournaments.aspx");
    }
}