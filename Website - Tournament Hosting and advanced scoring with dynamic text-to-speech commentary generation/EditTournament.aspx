                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="EditTournament.aspx.cs" Inherits="EditTournament" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <title>Edit Tournament</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>
                        Tournament Details</h2>
                    <div class="clearfix">
                    </div>
                </div>
                <div class="x_content">
                    <br />
                    <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                Tournament ID <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtTournamentID" runat="server" CssClass="form-control col-md-7 col-xs-12"
                                    Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                Title <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTitle"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                Details
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtDetails" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">
                                Sponsor
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtSponsor" CssClass="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Banner
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtBanner" CssClass="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Start Date <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtStartDate" class="date-picker form-control col-md-7 col-xs-12"
                                    runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtStartDate"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                End Date <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtEndDate" class="date-picker form-control col-md-7 col-xs-12"
                                    runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtEndDate"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Scoring Type <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <div id="ScoringType" class="btn-group" data-toggle="buttons">
                                    <label class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-default">
                                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="ScoringType" Checked="true" />
                                        &nbsp; Basic &nbsp;
                                    </label>
                                    <label class="btn btn-default" data-toggle-class="btn-primary" data-toggle-passive-class="btn-default">
                                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="ScoringType" Checked="false" />
                                        Advanced
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Tournament Type <span class="required">*</span>
                            </label>
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:DropDownList ID="ddlTournamentType" CssClass="select2_single form-control" runat="server">
                                    <asp:ListItem Value="1">League</asp:ListItem>
                                    <asp:ListItem Value="2">Knockout</asp:ListItem>
                                    <asp:ListItem Value="3">Group Stage & Knockout</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Number of teams <span class="required">*</span>
                            </label>
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:TextBox ID="txtNumbOfTeams" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtNumbOfTeams"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                               Total Overs <span class="required">*</span>
                            </label>
                            <div class="col-md-3 col-sm-3 col-xs-12">
                                <asp:TextBox ID="txtTotalOvers" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtTotalOvers"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                        </div>
                        
                        <div class="x_title">
                            <h2>
                                Manager Details</h2>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" >
                                Manager ID <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtManagerID" runat="server" CssClass="form-control col-md-7 col-xs-12"
                                    Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Name <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtName"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Email <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtEmail"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail"
                                runat="server" ErrorMessage="Incorrect Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Mobile <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtMobile"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
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
                                Photo
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
                                <asp:Button ID="btnSaveChanges" runat="server" CssClass="btn btn-success" Text="Save Changes"
                                    OnClick="btnSaveChanges_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
