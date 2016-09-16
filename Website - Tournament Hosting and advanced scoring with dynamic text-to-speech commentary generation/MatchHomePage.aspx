                      <!-- Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani -->
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="MatchHomePage.aspx.cs" Inherits="MatchHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style>
        .a
        {
            margin: 0 0 0 250px;
        }
        
        .b
        {
            margin: 0 0 0 250px;
        }
        .c
        {
            margin: 0 0 0 130px;
        }
        d.
        {
            margin: 0 0 0 100px;
            border-width: medium;
            border-style: solid;
        }
        .txtFixtureID
        {
            display: none;
        }
        .lblDeliveryID
        {
            display: none;
        }
    </style>
    <form id="form1" runat="server">
    <div class="main-content" style="height: inherit;">
        <div class="soccer-inner">
            <h1>
                <asp:Label ID="lbltournamentname" runat="server"></asp:Label>
            </h1>
            <h2>
                <asp:Label ID="team1" CssClass="a" runat="server"></asp:Label><asp:Label CssClass="c"
                    Text="VS" runat="server"></asp:Label><asp:Label CssClass="b" ID="team2" runat="server"></asp:Label>
            </h2>
            <h3 class="ScoreBox">
                <asp:Label ID="lblfirstBat" runat="server"></asp:Label>
                <asp:Label ID="lblTotalRuns" CssClass="d" Text="Runs" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Overs"></asp:Label>
                <asp:Label ID="lblOvers" CssClass="d" Text="" runat="server"></asp:Label>
            </h3>
            <asp:TextBox ID="txtFixtureID" CssClass="txtFixtureID" runat="server"></asp:TextBox>
            <br />
            <div class="sap_tabs">
                <div id="horizontalTab" style="display: block; width: 100%; margin: 0px;">
                    <ul class="resp-tabs-list">
                        <li class="resp-tab-item grid1"><span>COMMENTARY</span></li>
                        <li class="resp-tab-item grid2"><span>LINE UPS</span></li>
                    </ul>
                    <div class="resp-tabs-container">
                        <div class="tab-1 resp-tab-content">
                            <div class="facts">
                                <div class="CommentaryBox">
                                    <asp:Label ID="lblDelNumber" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblCommentary" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblDeliveryID" CssClass="lblDeliveryID" runat="server" Text=""></asp:Label>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <div class="resp-tabs-container">
                            <div class="tab-1 resp-tab-content">
                                <div class="facts">
                                    <table>
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Team1">
                                                    <ItemTemplate>
                                                        <%# Eval("Team1")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Team2">
                                                    <ItemTemplate>
                                                        <%# Eval("Team2")%>
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
    <script>
        //alert("1");
        refresh1 = function () {
            //alert("2");
            $.get("AJAXScore.aspx?ID=" + $(".txtFixtureID").val(), function (data) {
                $(".ScoreBox").html(data);
                //$(".ScoreBox").append(data);
                //alert("3");
            });
            return false;
        }

        var tid = setInterval(refresh1, 10000);

    </script>
    <script>
        //alert("1");
        refresh2 = function () {
            ///alert($(".lblDeliveryID").html());
            $.get("AJAXCommentary.aspx?ID=" + $(".txtFixtureID").val() + "&DelID=" + $(".lblDeliveryID").last().html(), function (data) {
                //$(".CommentaryBox").html(data);
                //alert(data);
                if (data.indexOf("000") == -1) {
                    $(".CommentaryBox").append(data + '<br/>');
                }
            });
            return false;
        }

        var tid = setInterval(refresh2, 3000);

    </script>
</asp:Content>
