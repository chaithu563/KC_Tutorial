<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="height: 389px; width: 972px">


        <br />
        <br />
        <form  runat="server">
&nbsp;MyName&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp;<br />
        MySalary
       <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        Myage
       <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            </form>
    </div>
</body>
</html>
