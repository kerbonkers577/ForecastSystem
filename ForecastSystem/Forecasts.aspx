<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forecasts.aspx.cs" Inherits="ForecastSystem.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2><%: Title %>.</h2>
    <!--This is the search text box, button and grid view, to copy, copy from the div with class container to the ending div-->
    <div class="container">
        <div>
            <asp:TextBox ID="txtSearch" placeholder="Search Name" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnCitySearch" runat="server" CssClass="button btn-primary" Text="Search By Name" OnClick="FilterUsers"/>
        </div>
        <div>
            <asp:GridView ID="Forecasts" CssClass="table" runat="server"></asp:GridView>
        </div>
    </div>

    <!-- These are the controls for adding a new user-->
    <div class="container">
        <div>
            <!--Add-->
             <asp:TextBox ID="txtNewUsername" placeholder="Add New Username" runat="server"></asp:TextBox> <br />
             <asp:TextBox ID="txtNewPassword" placeholder="Add New Password" runat="server"></asp:TextBox> <br />
            <asp:Button ID="btnAddUser" text="Add New User" CssClass="btn btn-primary" runat="server" OnClick="AddUser"/>
        </div>
    </div>
    <br />

    <!--These are the controls for updating a user-->
    <!--Update-->
    <div class="container">
        <div>
            <asp:DropDownList ID="ddUserUpdate" runat="server" AppendDataBoundItems="false"></asp:DropDownList><br />
             <asp:TextBox ID="txtUpdateUsername" placeholder="Add New Username" runat="server"></asp:TextBox><br />
             <asp:TextBox ID="txtUpdatePassword" placeholder="Add New Password" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnUpdateUser" Text="Update Selected User" CssClass="btn btn-primary" runat="server" OnClick="UpdateUser"/>
        </div>
    </div>

    <!--These are the controls for deleting a user-->
    <!--Delete-->
    <div class="container">
        <div>
            <asp:DropDownList ID="ddDelteUser" runat="server" AppendDataBoundItems="false"></asp:DropDownList><br />
            <asp:Button ID="Button1" Text="Delete Selected User" CssClass="btn btn-primary" runat="server" OnClick="DeleteUser"/>
        </div>
    </div>

    
    
</asp:Content>

