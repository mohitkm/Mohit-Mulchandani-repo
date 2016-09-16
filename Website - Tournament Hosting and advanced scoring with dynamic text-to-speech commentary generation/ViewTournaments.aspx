                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewTournaments.aspx.cs" Inherits="ViewTournaments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <title>Tournaments</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>
                    My Tournaments
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
                            Tournaments</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <p>
                            You have the following tournaments
                        </p>
                        <asp:GridView GridLines="None" CssClass="table table-striped projects" ID="GridView1"
                            runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemTemplate>
                                        <%# Eval("Title") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Manager Name">
                                    <ItemTemplate>
                                        <%# Eval("ManagerName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <%# Eval("StartDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date">
                                    <ItemTemplate>
                                        <%# Eval("EndDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Scoring Type">
                                    <ItemTemplate>
                                        <%# Eval("ScoringType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tournament Type">
                                    <ItemTemplate>
                                        <%# Eval("TournamentType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TotalTeams">
                                    <ItemTemplate>
                                        <%# Eval("TotalTeams") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>View </a>--%>
                                        <a href='<%# "EditTournament.aspx?ID="+Eval("TournamentID") %>' class="btn btn-info btn-xs">
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
