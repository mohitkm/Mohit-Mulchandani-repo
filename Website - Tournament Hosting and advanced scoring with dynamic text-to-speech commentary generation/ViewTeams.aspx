                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewTeams.aspx.cs" Inherits="ViewTeams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <title>View Teams</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>
                    Teams
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
                            Team</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <p>
                            The Following Teams have participated in Tournament
                        </p>
                        <asp:GridView GridLines="None" CssClass="table table-striped projects" ID="GridView1"
                            runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Team Logo">
                                    <ItemTemplate>
                                        <img style="height:100px;width:200px" src='<%# "UserPhotos/" + Eval("Logo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Team Name">
                                    <ItemTemplate>
                                        <%# Eval("TeamName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Details">
                                    <ItemTemplate>
                                        <%# Eval("Details") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Manager ID">
                                    <ItemTemplate>
                                        <%# Eval("ManagerID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tournament ID">
                                    <ItemTemplate>
                                        <%# Eval("TournamentID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>View </a>--%>
                                        <a href='<%# "EditTeams.aspx?ID="+Eval("TeamID") %>' class="btn btn-info btn-xs"><i
                                            class="fa fa-pencil"></i>Edit </a><a href="#" class="btn btn-danger btn-xs"><i class="fa fa-trash-o">
                                            </i>Delete </a>
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
