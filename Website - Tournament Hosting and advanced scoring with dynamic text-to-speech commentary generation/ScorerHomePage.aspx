                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="ScorerHomePage.aspx.cs" Inherits="ScorerHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>
                    Tournament's Name
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
                            My Matches</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <asp:GridView GridLines="None" ID="g1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped projects">
                            <Columns>
                                <asp:TemplateField HeaderText="FixtureID">
                                    <ItemTemplate>
                                        <%# Eval("FixtureID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Team 1">
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
                                 <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
  <a href='<%# "Scoring.aspx?ID="+Eval("FixtureID") %>'>
                                     <asp:Button Text="Start Scoring" runat="server"/></a>
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
