                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
public partial class EditTeams : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);

            Team T = TeamLogic.selectByID(ID);
            txtTeamID.Text = ID.ToString();
            txtTeamName.Text = T.TeamName;
            txtTeamDetails.Text = T.Details;
            txtTeamBanner.Text = T.Banner;
           // ddlTournamentType.SelectedValue = T.TournamentType.ToString();
          //  txtNumbOfTeams.Text = T.TotalTeams.ToString();
           
            //FileUploadPhoto. = U.Photo;
        }


    }

    protected void btnSaveChanges_Click(object sender, EventArgs e)
    {
        Team T = new Team();
      
        T.TeamID = Convert.ToInt32(txtTeamID.Text);
        T.TeamName = txtTeamName.Text;
        T.Details = txtTeamDetails.Text;
        T.Banner = txtTeamBanner.Text;
        T.ManagerID = Convert.ToInt32(txtTeamManager.Text);
        String prefix = DateTime.Now.Ticks.ToString();
        T.Logo = prefix + FileUpload1.FileName;
        FileUpload1.SaveAs(Server.MapPath("UserPhotos\\" + prefix + FileUpload1.FileName));
      
        TeamLogic.update(T);

        Response.Redirect("ViewTeams.aspx");
    }
}
