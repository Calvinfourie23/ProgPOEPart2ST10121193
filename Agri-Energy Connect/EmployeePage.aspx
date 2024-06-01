<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="Agri_Energy_Connect.EmployeePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee's Hub</title>
    <style>
        .container {
            height: auto;
            width: auto;
            text-align: center;
            background: #33dfff;
        }
        .input-container {
            margin-bottom: 10px;
        }
        .grid-container {
            margin-top: 20px;
        }
    </style>
</head>
<body class="container">
    <form id="form1" runat="server">
        <div class="input-container">
            <h2>Add New Farmer Profile</h2>
            <asp:TextBox ID="FirstNameTextBox" runat="server" placeholder="First Name"></asp:TextBox>
            <br />
            <asp:TextBox ID="LastNameTextBox" runat="server" placeholder="Last Name"></asp:TextBox>
            <br />
            <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Email"></asp:TextBox>
            <br />
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <br />
            <asp:Button ID="AddFarmerButton" runat="server" Text="Add Farmer" OnClick="AddFarmerButton_Click" />
        </div>

        <div class="input-container">
            <h2>Filter Products</h2>
            <asp:Label ID="FilterLabel" runat="server" Text="Filter by Date Range:"></asp:Label>
            <br />
            <asp:TextBox ID="StartDateTextBox" runat="server" placeholder="Start Date (YYYY-MM-DD)"></asp:TextBox>
            <br />
            <asp:TextBox ID="EndDateTextBox" runat="server" placeholder="End Date (YYYY-MM-DD)"></asp:TextBox>
            <br />
            <asp:Button ID="FilterButton" runat="server" Text="Filter" OnClick="FilterButton_Click" />
        </div>

        <div class="grid-container">
            <h2>List of Products</h2>
            <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="ProductionDate" HeaderText="Production Date" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
