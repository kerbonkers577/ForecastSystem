<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ForecastSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Weather Forecast System</h1>
        <p class="lead">Welcome to the Weather Forecast Database System</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Sign in</h2>
        </div>
        <div>
            <asp:TextBox ID="txtUsername" placeholder="Username" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPassword" type="password" placeholder="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" text="Login" runat="server" OnClick="btnLogin_Click"/>
        </div>
    </div>
    
    
	
</asp:Content>
