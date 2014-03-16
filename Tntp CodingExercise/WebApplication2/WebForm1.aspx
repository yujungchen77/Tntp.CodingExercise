<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       
    
    </div>
    <asp:Button ID="btnInsert" runat="server" onclick="btnInsert_Click" 
        Text="Insert bios Data to MongoDB" />
        <asp:Button ID="btnConvert" runat="server" Text="Convert Data to MS Sql Server" 
        onclick="btnConvert_Click" />

    <br />
         <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
