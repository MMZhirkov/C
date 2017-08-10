<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="auth.aspx.cs" Inherits="ASPForm.auth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div >
         //header
            <div>
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </div>
            <div style="height: 93px">
               <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
         <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enter" />
            </div>
     </div>
    </form>
</body>
</html>
