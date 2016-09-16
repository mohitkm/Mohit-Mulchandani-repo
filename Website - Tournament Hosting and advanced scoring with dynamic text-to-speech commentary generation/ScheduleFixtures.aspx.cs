                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackendLogic;


public partial class ScheduleFixtures : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = TeamLogic.selectByTournamentID(Convert.ToInt32(Request.QueryString["ID"]));
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ddlTeam1.DataSource = ds.Tables[0];
            ddlTeam1.DataTextField = "TeamName";
            ddlTeam1.DataValueField = "TeamID";
            ddlTeam1.DataBind();
            ddlTeam1.Items.Insert(0, new ListItem("Select team 1", null, true));


            ddlTeam2.DataSource = ds.Tables[0];
            ddlTeam2.DataTextField = "TeamName";
            ddlTeam2.DataValueField = "TeamID";
            ddlTeam2.DataBind();
            ddlTeam2.Items.Insert(0, new ListItem("Select team 2", null, true));
        }
    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        Fixture F = new Fixture();
        F.TeamID1 = Convert.ToInt32(ddlTeam1.SelectedItem.Value);
        F.TeamID2 = Convert.ToInt32(ddlTeam2.SelectedItem.Value);
        F.ScDate = Convert.ToDateTime(txtFixtureDate.Text);
        F.ScVenue = txtFixtureVenue.Text;
        F.Details = txtDetails.Text;
        F.Umpire = txtUmpire.Text;
        F.Status = 1;
        F.Result = 0;
        F.Team1PlayingXI = "";
        F.Team2PlayingXI = "";
        if (NewScorerPlaceHolder.Visible)
        {
            UserDetail U = new UserDetail();

            U.Name = txtName.Text;
            U.Email = txtNewScorerEmail.Text;
            U.Mobile = txtMobile.Text;
            U.Address = txtAddress.Text;
            U.IsActive = true;
            U.Password = "";
            U.UserType = "Scorer";
            String prefix = DateTime.Now.Ticks.ToString();
            U.Photo = prefix + FileUploadPhoto.FileName;
            FileUploadPhoto.SaveAs(Server.MapPath("UserPhotos\\" + prefix + FileUploadPhoto.FileName));

            UserDetailLogic.insert(U);
            F.ScorerID = UserDetailLogic.getID(txtNewScorerEmail.Text);

        }
        else
        {
            string email = txtExistingScorerEmail.Text;
            int ScorerID = UserDetailLogic.getID(email);
            if (ScorerID != 100)
                F.ScorerID = ScorerID;
            else
                F.ScorerID = 0;
        }
        FixtureLogic.insert(F);
        Response.Redirect("Default.aspx");


    }
    protected void btnNewScorer_Click(object sender, EventArgs e)
    {
        NewScorerPlaceHolder.Visible = true;
    }
    protected void btnExistingScorer_Click(object sender, EventArgs e)
    {
        ExistingScorerPlaceHolder.Visible = true;
    }
}