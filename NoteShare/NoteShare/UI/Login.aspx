<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NoteShare.UI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="animate__animated animate__rubberBand">
            <h1>Login</h1>
            <br />
            <asp:TextBox runat="server" ID="UsernameTB" CssClass="login-textbox" placeholder="Username" /><br />
            <br />
            <asp:TextBox runat="server" ID="PasswordTB" CssClass="login-textbox" placeholder="Password" type="password" /><br />
            <br />
            <asp:Button ID="LoginBTN" runat="server" Text="Login" CssClass="btn btn-danger login-btn" OnClick="LoginBTN_Click" /><br />
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error"></asp:Label><br />
            <a href="Register.aspx">dont have an account?</a>
        </div>
    </center>
</asp:Content>
