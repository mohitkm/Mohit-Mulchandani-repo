                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFixtures.aspx.cs" Inherits="ViewFixtures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>
                    Fixtures
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
                            Draws</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <p>
                            The Following are the Tournament Fixtures
                        </p>
                        <asp:GridView GridLines="None" CssClass="table table-striped projects" ID="GridView1"
                            runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Fixture ID">
                                    <ItemTemplate>
                               <%# Eval("FixtureID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Team 1 ">
                                    <ItemTemplate>
                                        <%# Eval("TeamName1") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Team 2">
                                    <ItemTemplate>
                                        <%# Eval("TeamName2") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <%# Eval("ScDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Details">
                                    <ItemTemplate>
                                        <%# Eval("Details") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Venue">
                                    <ItemTemplate>
                                        <%# Eval("ScVenue") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Scorer ID">
                                    <ItemTemplate>
                                        <%# Eval("ScorerID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i>View </a>--%>
                                        <a href='<%# "EditTeams.aspx?ID="+Eval("FixtureID") %>' class="btn btn-info btn-xs"><i
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

