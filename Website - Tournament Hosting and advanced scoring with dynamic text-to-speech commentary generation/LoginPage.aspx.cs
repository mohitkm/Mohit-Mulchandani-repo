                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserDetails"] = null;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String email = txtUsername.Text;
        String pass = txtPassword.Text;
        int ID=UserDetailLogic.validate(email, pass);

        if (ID != 0)
        {
            UserDetail U = UserDetailLogic.selectByID(ID);
            Session["UserDetails"] = U;
            UserDetail utype = UserDetailLogic.selectByID(ID);
            if (utype.UserType == "Scorer")
            {
                Response.Redirect("ScorerHomePage.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }  
        }
        else
        {
            Label1.Visible = true;
        }
    }
}