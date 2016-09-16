                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AddTeamMember.aspx.cs" Inherits="AddTeamMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <title>Team Member Registration</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_content">
                    <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">
                        <div class="x_title">
                            <h2>
                                Team Member Registration</h2>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Name <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Email <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEmail"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail"
                                runat="server" ErrorMessage="Invalid Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Mobile <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobile"
                                ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Details <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtDetails" TextMode="MultiLine" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Address <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Photo <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:FileUpload ID="FileUploadPhoto" runat="server" />
                            </div>
                        </div>
                        <div class="ln_solid">
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
