                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="LiveScores.aspx.cs" Inherits="LiveScores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
 
  <form runat="server">   
     <div class="main-content" style="height: inherit;">
        <div class="soccer-inner">
    <h2>
    
        <center>
            <asp:Label ID="tournamentname" runat="server"></asp:Label>
        </center>
    </h2>
    <br />
    <asp:GridView GridLines="None" ID="GridView1" runat="Server" AutoGenerateColumns="false"
        Style="overflow: inherit;"> 
             <Columns>
           <%-- <asp:TemplateField HeaderText="Tournament Name">
                <ItemTemplate>
                    <%# Eval("TournamentID") %>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Team 1 Name ">
                <ItemTemplate>
                    <%# Eval("TeamName1")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Team 2 name ">
                <ItemTemplate>
                    <%# Eval("TeamName2")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# "MatchHomePage.aspx?ID="+ Eval("FixtureID") %>'>
           Live Scores          </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h3>
    </h3>
    </div>
    </div>
    </form>
</asp:Content>
