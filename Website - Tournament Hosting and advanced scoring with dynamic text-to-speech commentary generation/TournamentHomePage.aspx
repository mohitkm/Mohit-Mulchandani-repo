                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="TournamentHomePage.aspx.cs" Inherits="TournamentHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style>
        .label1
        {
            max-width: 400px;
            max-height: 60px;
            border-width: 0px;
            margin-left: 720px;
            white-space: inherit;
        }
        
        .label2
        {
            font-family: Bitter-Regular;
            font-style: oblique;
            background: white;
            color: black;
            cursor: text;
            font-size: 12px;
        }
    </style>
    <form id="form1" runat="server">
    <div class="main-content" style="height: inherit;">
        <div class="soccer-inner">
            <h2 class="tittle">
                <asp:Label ID="tname" runat="server" Text=""></asp:Label></h2>
            <table class="label1">
                <tr>
                    <td class="label2">
                        Starting Date:
                    </td>
                    <td>
                        <asp:Label ID="stdate" runat="server" CssClass="label2" Text="Starting Date"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label2">
                        Ending Date:
                    </td>
                    <td>
                        <asp:Label ID="endate" runat="server" CssClass="label2"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <div class="sap_tabs">
                <div id="horizontalTab" style="display: block; width: 100%; margin: 0px;">
                    <ul class="resp-tabs-list">
                        <li class="resp-tab-item grid1"><span>TEAMS</span></li>
                        <li class="resp-tab-item grid2"><span>FIXTURES</span></li>
                        <li class="resp-tab-item grid3"><span>TABLE</span></li>
                    </ul>
                    <div class="resp-tabs-container">
                        <div class="tab-1 resp-tab-content">
                            <div class="facts">
                                <table>
                                    <asp:GridView GridLines="None" ID="GridView1" runat="server" AutoGenerateColumns="false"
                                        Style="overflow: inherit;">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Team Logo">
                                                <ItemTemplate>
                                                    <img style="height: 100px; width: 200px" src='<%# "UserPhotos/" + Eval("Logo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Team ID ">
                                                <ItemTemplate>
                                                    <%# Eval("TeamID")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Team name ">
                                                <ItemTemplate>
                                                    <a href='<%# "TeamHomePage.aspx?ID="+Eval("TeamID") %>'>
                                                        <%# Eval("TeamName")%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </table>
                            </div>
                        </div>
                        <div class="resp-tabs-container">
                            <div class="tab-1 resp-tab-content">
                                <div class="facts">
                                    <table>
                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Team 1">
                                                    <ItemTemplate>
                                                        <%# Eval("TeamName1") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Team 2 ">
                                                    <ItemTemplate>
                                                        <%# Eval("TeamName2") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Venue">
                                                    <ItemTemplate>
                                                        <%# Eval("ScVenue") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </table>
                                </div>
                            </div>
                            <div class="resp-tabs-container">
                                <div class="tab-1 resp-tab-content">
                                    <div class="facts">
                                        <table>
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="TeamID">
                                                        <ItemTemplate>
                                                            <%# Eval("TeamID")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="TeamName">
                                                        <ItemTemplate>
                                                            <a href='<%# "TeamHomePage.aspx?ID="+Eval("TeamID") %>'>
                                                                <%# Eval("TeamName")%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Points">
                                                        <ItemTemplate>
                                                            <%# Eval("Points")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <script src="js/easyResponsiveTabs.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#horizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion           
                width: 'auto', //auto or any width like 600px
                fit: true   // 100% fit in a container
            });
        });
    </script>
</asp:Content>
