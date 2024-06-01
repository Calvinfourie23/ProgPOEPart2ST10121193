<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Agri_Energy_Connect.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" style="line-height: 200px;">
    <title>Login</title>
    <h1>
        <asp:Label ID="LoginLbl" runat="server" Text="Login" ForeColor="White"></asp:Label>
    </h1>
    <style>
        .container {
            height: auto;
            width: auto;
            text-align: center;
            background: #33dfff;
        }
    </style>
</head>
<body class="container" runat="server">
    <form id="form1" runat="server">
        
        <div>
            <div>
                <b>
                    <asp:Label ID="emailLbl" runat="server" Text="Email" ForeColor="White" style ="padding: 33px"></asp:Label>
                </b>
                <input id="emailTxt" type="text" runat="server"/>
            </div>
            <div>
                <b>
                    <asp:Label ID="passLbl" runat="server" Text="Password" ForeColor="White" style ="padding: 20px"></asp:Label>
                </b>
                <input id="passTxt" type="password" runat="server"/>
            </div>
            <div style ="padding-top: 10px">
                <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
                <br />
                <br />
                <asp:Label ID="errorLbl" runat="server" Text=" " ForeColor="White"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
