                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;

public partial class UserRegistration : System.Web.UI.Page
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
        switch(ddlUserType.SelectedIndex)
        {
            case 1:
                U.UserType="Admin";
                break;
            case 2:
                U.UserType="GU";
                break;
            case 3:
                U.UserType="Scorer";
                break;
            default:
                U.UserType="GU";
                break;
               
        }
        String prefix = DateTime.Now.Ticks.ToString();
        U.Photo = prefix + FileUploadPhoto.FileName;
        FileUploadPhoto.SaveAs(Server.MapPath("UserPhotos\\" + prefix + FileUploadPhoto.FileName));

        UserDetailLogic.insert(U);
    }
}