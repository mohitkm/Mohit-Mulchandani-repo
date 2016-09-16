                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewTeamMembers.aspx.cs" Inherits="ViewTeamMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <title>Team Members</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>
                    Team Players
                </h3>
            </div>
        </div>
        <div class="clearfix">
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            Team Players</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <p>
                            You have the following players in your roster
                        </p>
                        <asp:GridView GridLines="None" CssClass="table table-striped projects" ID="GridView1"
                            runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <img style="max-width: 200px; max-height: 200px;" src='<%# "UserPhotos/" + Eval("Photo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <%# Eval("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <%# Eval("Email") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile">
                                    <ItemTemplate>
                                        <%# Eval("Mobile") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>View </a>--%>
                                        <a href='<%# "EditTeamMember.aspx?ID="+Eval("UserDetailID") %>' class="btn btn-info btn-xs">
                                            <i class="fa fa-pencil"></i>Edit </a><a href="#" class="btn btn-danger btn-xs"><i
                                                class="fa fa-trash-o"></i>Delete </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
