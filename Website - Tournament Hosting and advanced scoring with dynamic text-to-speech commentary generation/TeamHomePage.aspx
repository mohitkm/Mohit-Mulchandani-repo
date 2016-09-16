                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="TeamHomePage.aspx.cs" Inherits="TeamHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
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
            
            <br />
            <br />
            <div class="sap_tabs">
                        <div id="horizontalTab" style="display: block; width: 100%; margin: 0px;">
                            <ul class="resp-tabs-list">
                                <li class="resp-tab-item grid1"><span>Players</span></li>
                                <li class="resp-tab-item grid2"><span>TOURNAMENT
                                    STATS</span></li>
                                <li class="resp-tab-item grid3"><span>FIXTURES
                                    </span></li>
                            </ul>
                            <div class="resp-tabs-container">
                                <div class="tab-1 resp-tab-content">
                                    <div class="facts">
                                       
                                              <table>
                                            <asp:GridView GridLines="None" ID="GridView1" runat="server" AutoGenerateColumns="false"
                                            Style="overflow: inherit;">
                                      
                                            <Columns>
                                               <%-- <asp:TemplateField HeaderText="Team Logo">
                                                    <ItemTemplate>
                                                        <img style="height: 100px; width: 200px" src='<%# "UserPhotos/" + Eval("Logo") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Team Member name ">
                                                    <ItemTemplate>
                                                   
                                                            <%# Eval("Name")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email">
                                                    <ItemTemplate>
                                                        <%# Eval("Email") %>
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
                                               <asp:TemplateField HeaderText="ID1">
                                               <ItemTemplate>
                                               <%# Eval("TeamID1") %>
                                               </ItemTemplate>
                                               </asp:TemplateField>
                                               </Columns>

                                               </asp:GridView>
                                            </table>
                                       
                                    </div>
                                </div>
                        
                                <div class="resp-tabs-container">
                                <div class="tab-1 resp-tab-content" aria-labelledby="tab_item-0">
                                    <div class="facts">
                                       
                                            <table>
                                                <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="false">
                                                <Columns>
                                                <asp:TemplateField HeaderText="TeamID1">
                                              <ItemTemplate>
                                                   
                                                            <%# Eval("TeamName1")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TeamID2">
                                              <ItemTemplate>
                                                   
                                                            <%# Eval("TeamName2")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                </Columns>
                                                </asp:GridView>
                                            </table>
                                       
                                    </div>
                                </div>
                                </div>
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
                            </div>
                        </div>
                    </div>
      
    </div>
    </div>
    </form>
</asp:Content>

