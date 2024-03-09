<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="hw3_conkin._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW 3 - [name redacted]</title>
    <link rel="stylesheet" href="siteStyling.css" />
    <style type="text/css">
        .auto-style1 {
            width: 200px;
            height: 150px;
        }
    </style>
    <script>
        async function refreshPage() {
            await sleep(100); 
            location.reload(); 
        }

        function sleep(ms) {
            return new Promise(resolve => setTimeout(resolve, ms));
        }
    </script>
</head>
<body id="body" runat="server">
    <form id="form1" runat="server" autocomplete="off">
        <div id="header">
            <h3>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                HW 3 - [name redacted]</h3>
            <p><a href="classDiagram.html">Class Diagram</a></p>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="eventCreator" runat="server" GroupingText="Create Event">
                        Event Name:
                        <asp:TextBox ID="eventName" runat="server" Height="17px" Width="188px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="eventName" Display="Dynamic" ErrorMessage="Event Name can not be empty." ForeColor="Red" Type="String" ValidationGroup="eventMaking"></asp:RequiredFieldValidator>
                        <br />
                        <p>
                            Available Seat Numbers: First
                            <asp:TextBox ID="seatMinimum" runat="server" Width="25px"></asp:TextBox>
                            Last
                            <asp:TextBox ID="seatMaximum" runat="server" Width="25px"></asp:TextBox>
                            <asp:RangeValidator ID="minimumSeatValidator" runat="server" ControlToValidate="seatMinimum" ErrorMessage="First seat must be positive.-" ForeColor="Red" MaximumValue="150000" MinimumValue="0" Type="Integer" ValidationGroup="eventMaking"></asp:RangeValidator>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="seatMaximum" ErrorMessage=" Last seat must be greater than 0." ForeColor="Red" MaximumValue="150000" MinimumValue="1" Type="Integer" ValidationGroup="eventMaking"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="seatMinimum" Type="Integer" ValidationGroup="eventMaking"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="seatMaximum" Type="Integer" ValidationGroup="eventMaking"></asp:RequiredFieldValidator>
                        </p>
                        <asp:Button ID="makeEvent" ClientIDMode="AutoID" OnClientClick="refreshPage()" runat="server" CausesValidation="true" OnClick="makeEvent_Click" Text="Make Event" ValidationGroup="eventMaking" />
                        &nbsp;<asp:Button ID="startOver" runat="server" OnClick="startOver_Click" Text="Start Over" />
                        <br />
                        <div>
                    </asp:Panel>
                    <asp:Panel ID="ticketPurchaser" runat="server" GroupingText="Purchase Ticket">
                        <p>
                            Name
                                <asp:TextBox ID="name" runat="server"></asp:TextBox>
                            Age
                                <asp:TextBox ID="age" runat="server" Width="25px"></asp:TextBox>
                            <asp:RangeValidator ID="ageValidator" runat="server" ControlToValidate="age" ErrorMessage="Age must be positive. " ForeColor="Red" MaximumValue="130" MinimumValue="0" Type="Integer" ValidationGroup="ticketPurchasing"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="name" ErrorMessage="Name can not be empty." ForeColor="Red" Type="String" ValidationGroup="ticketPurchasing"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="age" Type="Integer" ValidationGroup="ticketPurchasing"></asp:RequiredFieldValidator>
                        </p>
                        <p>
                            Pick Seat,
                                <asp:Label ID="lblAvailableSeats" runat="server" ForeColor="Red"></asp:Label>
                            &nbsp;available
                        </p>
                        <p>
                            <asp:ListBox ID="lbxAvailableSeats" runat="server" Height="173px" Width="58px"></asp:ListBox>
                            <asp:Button ID="btnPurchase" runat="server" OnClick="btnPurchase_Click" Text="Purchase" ValidationGroup="ticketPurchasing" />
                            <asp:Button ID="btnEventSummary" runat="server" PostBackUrl="summary.aspx" Text="Event Summary" OnClick="btnEventSummary_Click" />
                        </p>
                    </asp:Panel>

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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div id="purchaseTicket">
        </div>

        <%--        <label>Debug Info:</label><br />
        <asp:TextBox ID="txbDebugInfo" runat="server" Height="214px" Width="470px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>--%>
    </form>


</body>
</html>
