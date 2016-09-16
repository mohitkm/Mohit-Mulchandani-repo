                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ScheduleFixtures.aspx.cs" Inherits="ScheduleFixtures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    <b>Scheduling </b>
                </h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="x_content">
                <br />
                <div id="demo-form2" data-parsley-validate class="form-horizontal form-label-left">
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                        </label>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                            <asp:DropDownList ID="ddlTeam1" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div>
                            <%--<label>
                                VS
                            </label>--%>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                            <asp:DropDownList ID="ddlTeam2" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12">
                        </label>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                            <asp:TextBox ID="txtFixtureDate" class="date-picker form-control col-md-7 col-xs-12"
                                runat="server" placeholder="Fixture Date"></asp:TextBox>
                        </div>
                        <div class="col-md-3 col-sm-3 col-xs-12">
                            <asp:TextBox ID="txtFixtureVenue" placeholder="Fixture Venue" CssClass="form-control col-md-7 col-xs-12"
                                runat="server"></asp:TextBox>
                        </div>
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
                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                            Umpire</label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <asp:TextBox ID="txtUmpire" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                        </div>
                    </div>
                    <div class="x_title">
                        <h2>
                            Scorer Registration</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <asp:Button ID="btnNewScorer" runat="server" Text="New Scorer" OnClick="btnNewScorer_Click" />
                    <asp:Button ID="btnExistingScorer" runat="server" Text="Existing Scorer" OnClick="btnExistingScorer_Click" />
                    <asp:PlaceHolder ID="ExistingScorerPlaceHolder" Visible="false" runat="server">
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Email <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtExistingScorerEmail" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtExistingScorerEmail"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtExistingScorerEmail"
                                runat="server" ErrorMessage="Incorrect Email ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="NewScorerPlaceHolder" Visible="false" runat="server">
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
                                <asp:TextBox ID="txtNewScorerEmail" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtNewScorerEmail"
                                runat="server" ErrorMessage="Field is empty"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNewScorerEmail"
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
                                Photo <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:FileUpload ID="FileUploadPhoto" runat="server" />
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <div class="ln_solid">
                    </div>
                    <div class="form-group">
                        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                            <button type="reset" class="btn btn-primary">
                                Cancel</button>
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Submit"
                                OnClick="btnSubmit_Click1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
