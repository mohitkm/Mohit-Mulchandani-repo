                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendLogic;

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);

            
            UserDetail U = UserDetailLogic.selectByID(ID);
            txtUserDetailID.Text = ID.ToString();
            txtName.Text = U.Name;
            txtEmail.Text = U.Email;
            txtMobile.Text = U.Mobile;
            txtAddress.Text = U.Address;

            //FileUploadPhoto. = U.Photo;
        }
    }
    protected void btnSaveChanges_Click(object sender, EventArgs e)
    {
        UserDetail U = new UserDetail();

        U.UserDetailID = Convert.ToInt32(txtUserDetailID.Text);
        U.Name = txtName.Text;
        U.Email = txtEmail.Text;
        U.Mobile = txtMobile.Text;
        U.Address = txtAddress.Text;
        
        String prefix = DateTime.Now.Ticks.ToString();
        U.Photo = prefix + FileUploadPhoto.FileName;
        FileUploadPhoto.SaveAs(Server.MapPath("UserPhotos\\" + prefix + FileUploadPhoto.FileName));

        UserDetailLogic.update(U);
    }
}