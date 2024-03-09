<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="summary.aspx.cs" Inherits="hw3_conkin.summary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW 3 - Summary</title>
    <link rel="stylesheet" href="siteStyling.css" />
    <style type="text/css">
        .auto-style1 {
            width: 200px;
            height: 150px;
        }
    </style>
</head>
<body id="body" runat="server">
    <img id="dancingCats" src="path-to-your-dancing-cats.gif" style="display: none;" />
    <audio id="audio" src="path-to-your-audio-file.mp3" preload="auto"></audio>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <h3>Ticket Holders for
            <asp:Label ID="eventName" runat="server" ForeColor="Red" Font-Italic="true"></asp:Label></h3>

        <div id="header">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="purchaseMoreTickets" runat="server" Text="Purchase More Tickets" PostBackUrl="default.aspx" />
                    <p>
                        Sort:
            <asp:RadioButtonList ID="sortList" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="sortList_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Enabled="true" Text="Order Purchased"></asp:ListItem>
                <asp:ListItem Text="Name"></asp:ListItem>
                <asp:ListItem Text="Seat"></asp:ListItem>
            </asp:RadioButtonList>
                    </p>
                    <p>
                        Remove Ticket Holder 
            <asp:DropDownList ID="personToRemove" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="personToRemove_SelectedIndexChanged"></asp:DropDownList>&nbsp;
            <asp:Button ID="removePerson" runat="server" Text="Remove" OnClick="removePerson_Click" />
                    </p>
                    <asp:TextBox ID="displayEvent" runat="server" Height="290px" Width="463px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    <p>
        &nbsp;</p>

                    <asp:Panel ID="catPanel" runat="server" Visible="false">
                        <div>
                            <img alt="" class="auto-style1" src="dancingCat.gif" />
                            <img alt="" class="auto-style1" src="dancingCat.gif" />
                            <img alt="" class="auto-style1" src="dancingCat.gif" />
                            <img class="auto-style1" src="dancingCat.gif" />
                            <img class="auto-style1" src="dancingCat.gif" />
                            <img class="auto-style1" src="dancingCat.gif" />
                        </div>
                    </asp:Panel>
    </form>
    </body>
</html>
