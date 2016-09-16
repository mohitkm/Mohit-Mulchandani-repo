                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;
public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
          

            //     UserDetail U = new UserDetailLogic.selectByID(ID);

           
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["ID"]);
        
        UserDetail U = new UserDetail();
        U.UserDetailID = ID;
        U.Password = txtNewPassword.Text;
        UserDetailLogic.updatePassword(U);

    }
}