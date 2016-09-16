                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <title>Password</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">
        <div class="form-group">
            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                Old Password <span class="required">*</span>
            </label>
            <div class="col-md-6 col-sm-6 col-xs-12">
                <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOldPassword"
                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                New Password <span class="required">*</span>
            </label>
            <div class="col-md-6 col-sm-6 col-xs-12">
                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNewPassword"
                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                Confirm New Password <span class="required">*</span>
            </label>
            <div class="col-md-6 col-sm-6 col-xs-12">
                <asp:TextBox ID="txtConfirmNewPassword" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtConfirmNewPassword"
                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtConfirmNewPassword"
                ControlToCompare="txtNewPassword" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>
        </div>
        <div class="form-group">
            <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                <button type="reset" class="btn btn-primary">
                    Cancel</button>
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Submit"
                    OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>
