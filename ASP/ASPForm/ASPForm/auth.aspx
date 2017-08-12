<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auth.aspx.cs" Inherits="ASPForm.auth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 445px;
        }
        .auto-style3 {
            width: 445px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 66px;
        }
        .auto-style6 {
            height: 23px;
            width: 66px;
        }
        .auto-style7 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div >
         &nbsp;<div>
            </div>
            <div style="height: 93px">
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3"></td>
                        <td class="auto-style6">
                            <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style7" Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="Login1_Authenticate">
                                <LayoutTemplate>
                                    <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                                        <tr>
                                            <td>
                                                <table cellpadding="0">
                                                    <tr>
                                                        <td align="center" colspan="2" style="color:White;background-color:#6B696B;font-weight:bold;">Выполнить вход</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Имя пользователя:</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Поле &quot;Имя пользователя&quot; является обязательным." ToolTip="Поле &quot;Имя пользователя&quot; является обязательным." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Пароль:</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Поле &quot;Пароль&quot; является обязательным." ToolTip="Поле &quot;Пароль&quot; является обязательным." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Запомнить учетные данные." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="color:Red;">
                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" OnClick="LoginButton_Click" Text="Выполнить вход" ValidationGroup="Login1" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                            </asp:Login>
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
     </div>
    </form>
</body>
</html>
