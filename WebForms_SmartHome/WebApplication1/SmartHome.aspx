<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmartHome.aspx.cs" Inherits="WebApplication1.SmartHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SMART HOME</title>
    <style type="text/css">
        .auto-style1 {
            height: 69px;
        }
        .auto-style2 {
            height: 271px;
        }
        .auto-style3 {
            height: 212px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="allTable">
                <tr>
                    <td class="auto-style3">Тип устройства:
                    <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListBox ID="gadgetType" runat="server" AutoPostBack="True" Height="110px" OnSelectedIndexChanged="gadgetType_SelectedIndexChanged" Width="160px">
                            <asp:ListItem Value="Window">Окна</asp:ListItem>
                            <asp:ListItem Value="Lamp">Лампы</asp:ListItem>
                            <asp:ListItem Value="Climate">Кондиционер</asp:ListItem>
                            <asp:ListItem Value="Alarm">Сигнализация</asp:ListItem>
                            <asp:ListItem Value="Freedge">Холодильник</asp:ListItem>
                            <asp:ListItem Value="TV">Телевизор</asp:ListItem>
                        </asp:ListBox>
                        &nbsp;&nbsp;
                        <br />
                        <asp:Label ID="choosed" runat="server"></asp:Label>
                        <br />
                        <br />
                        Введите имя устройства:&nbsp;&nbsp;
                    <asp:TextBox ID="gadgetName" runat="server" OnTextChanged="gadgetName_TextChanged" Width="149px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;
                    <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Add" runat="server" Height="30px" Text="Добавить" Width="70px" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Delete" runat="server" Height="30px" Text="Удалить" Width="70px" />
                    </td>
                    <td class="auto-style3">Доступные устройства выбранного типа:<br />
                        <asp:Label ID="usedGadget" runat="server" Text="Выберите тип устройства" Height="250px" Width="500px" style="margin-bottom: 0px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" rowspan="2">
                        <asp:Button ID="On" runat="server" Height="30px" Text="On" Width="60px" Visible="False" ForeColor="#006600" />
                        &nbsp;<asp:Button ID="Off" runat="server" Height="30px" Text="Off" Width="60px" Visible="False" ForeColor="#CC0000" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:Button ID="Open" runat="server" Height="30px" Text="Open" Width="60px" Visible="False" />
                        &nbsp;<asp:Button ID="Close" runat="server" Height="30px" Text="Close" Width="60px" Visible="False" />
                        <br />
                        <br />
                        <asp:Button ID="TempUp" runat="server" Text="Temp Up" Visible="False" ForeColor="#CC0000" />
                        &nbsp;<asp:Button ID="TempDown" runat="server" Text="TempDown" Visible="False" ForeColor="#0000CC" />
                        &nbsp;<asp:TextBox ID="SetTemp" runat="server" AutoPostBack="True" OnTextChanged="SetTemp_TextChanged" TextMode="Number" Visible="False" Width="134px"></asp:TextBox>
                        <asp:Button ID="OkTempSet" runat="server" Text="Set" Visible="False" />
                        <br />
                        <br />
                        <asp:Button ID="VolUp" runat="server" Text="Volume Up" Visible="False" Width="100px" />
                        &nbsp;<asp:Button ID="VolDown" runat="server" Text="Volume Down" Visible="False" Width="100px" />
                        &nbsp;
                    <asp:Button ID="Mute" runat="server" Text="Mute" Visible="False" Width="50px" />
                        &nbsp;<br />
                        <asp:Button ID="ChannelUp" runat="server" Text="Channel Up" Visible="False" Width="100px" />
                        &nbsp;<asp:Button ID="ChannelDown" runat="server" Text="Channel Down" Visible="False" Width="100px" />
                        &nbsp;<br />
                        <br />
                    </td>
                    <td class="auto-style1">
                        <br />
                        <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Height="40px" Width="400px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Все доступные устройства в доме:
                        <br />
                        <asp:Label ID="allGadgetsLabel" runat="server" Height="250px" Width="500px"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
