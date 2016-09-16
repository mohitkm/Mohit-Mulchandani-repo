                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="RegisteredTournaments.aspx.cs" Inherits="RegisteredTournaments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <form id="form1" runat="server">
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
    <div class="main-content">
        <div class="soccer-inner">
           
                <div class="about">
                <asp:GridView GridLines="None" ID="GridView1" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Tournament ID">
                                    <ItemTemplate>
                               <%# Eval("TournamentID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tournament name ">
                                    <ItemTemplate>
                                       <a href='<%# "TournamentHomePage.aspx?ID="+Eval("TournamentID") %>'>
                                        <%# Eval("Title")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Total Teams">
                                    <ItemTemplate>
                                        <%# Eval("TotalTeams") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="StartDate">
                                    <ItemTemplate>
                                        <%# Eval("StartDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="EndDate">
                                    <ItemTemplate>
                                        <%# Eval("EndDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Details">
                                    <ItemTemplate>
                                        <%# Eval("Details") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                               
                            </Columns>
                        </asp:GridView>
                            </div>
                      
                    </div>
                </div>
            </div>
        </form>
</asp:Content>
