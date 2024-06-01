<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FarmerPage.aspx.cs" Inherits="Agri_Energy_Connect.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" style="line-height: 200px;">
    <title>Login</title>
    <h1>
        <asp:Label ID="farmerPageLbl" runat="server" Text="Farmer's Hub" ForeColor="White"></asp:Label>
    </h1>
    <style>
        .container {
            height: auto;
            width: auto;
            text-align: center;
            background: #33dfff;
        }
        .center {
            display: flex;
            justify-content: center;
            align-items: center;
            height: auto;
            background: #33dfff;
        }
        .add-product-form button {
            background-color: #4CAF50;
            color: white;
            padding: 10px 15px;
            border: none;
            cursor: pointer;
            width: 100%;
        }
        .error-message {
            color: red;
            margin-top: 10px;
        }
        .add-product-form {
            background-color: #f9f9f9;
            border: 1px solid #CCCCCC;
            padding: 20px;
            width: 300px; 
            display: flex;
            flex-direction: column;
        }
        .add-product-form input[type="text"] {
            margin-bottom: 10px;
            padding: 8px;
            box-sizing: border-box;
        }
    </style>
</head>
<body class ="container">
    <form id="form1" runat="server">
        <div class="center">
            <asp:GridView ID="FarmerProductView" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <div class="add-product-form">
                <h2>Add New Product</h2>
                <asp:TextBox ID="ProductNameTextBox" runat="server" placeholder="Product Name"></asp:TextBox>
                <asp:TextBox ID="CategoryTextBox" runat="server" placeholder="Category"></asp:TextBox>
                <asp:TextBox ID="ProductionDateTextBox" runat="server" placeholder="Production Date (YYYY-MM-DD)"></asp:TextBox>
                <asp:Button ID="AddProductButton" runat="server" Text="Add Product" OnClick="AddProductButton_Click" />
                <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="error-message" Visible="false"></asp:Label>
            </div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
