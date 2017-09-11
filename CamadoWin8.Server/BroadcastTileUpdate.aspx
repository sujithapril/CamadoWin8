<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BroadcastTileUpdate.aspx.cs" Inherits="OnTheRoad.Server.BroadcastTileUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
           Client Channel URI:
        </div>
        <asp:TextBox ID="UriTextBox" runat="server" Width="666px"></asp:TextBox>
        <br />
        <br />
        Enter message:<br />
        <asp:TextBox ID="MessageTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SendToastUpdateButton" runat="server" OnClick="ButtonSendTile_Click"
            Text="Send Toast Notification" />
        <br />
        <br />
        <asp:Button ID="SendTileUpdateButton" runat="server" OnClick="SendTileUpdateButton_Click"
            Text="Send Tile Notification" />
        <br />
        <br />
        Response:<br />
        <asp:TextBox ID="ResponseTextBox" runat="server" Height="78px" Width="199px"></asp:TextBox>
    </form>
</body>
</html>
