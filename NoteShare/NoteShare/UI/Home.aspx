<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NoteShare.UI.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .home-btn {
            height: 25vh;
            width: 25vh;
            font-size: 40px;
            margin-top: 5vh;
            transition: 0.5s;
        }

            .home-btn:hover {
                height: 27vh;
                width: 27vh;
            }
    </style>
    <asp:Panel runat="server" ID="loggedInAsPanel" Visible="false">
        <h4>you are logged in as:<asp:Label Text="" ID="LoggedAsUserLabel" runat="server" /></h4>
        <asp:Button Text="Log out" CssClass="btn btn-danger" runat="server" ID="LogOutUseruButton" OnClick="LogOutUseruButton_Click" />
    </asp:Panel>

    <center>
        <br />
        <h1>
            <asp:Label ID="WelcomeLBL" runat="server" Text="Welcome"></asp:Label></h1>
        <br />

        <asp:Button class="home-btn" runat="server" ID="AdminPanelButton" Text="Admin Panel" Visible="false" OnClick="AdminPanelButton_Click" Style="font-size: 30px;"></asp:Button>
        <asp:Button class="home-btn" runat="server" ID="WebsiteStats" Text="Website stats" Visible="false" OnClick="WebsiteStats_Click" Style="font-size: 30px;"></asp:Button>

        <style>
            .buttons-container {
                display: flex;
                justify-content: center;
                align-items: center;
                gap: 10px;
                padding: 0px 50px;
            }

            .home-btn {
                flex-basis: 20%; /* set the initial size of the buttons */
                flex-shrink: 0; /* prevent the buttons from shrinking */
            }
        </style>

        <div class="buttons-container">
            <button class="home-btn" style="font-size: 30px;">🔍 &#13;&#10;<a href="Explore.aspx">explore</a></button>
            <button class="home-btn" style="font-size: 30px;"><a href="UserInfo.aspx">personal information</a></button>
            <button class="home-btn" style="font-size: 30px;"><a href="UserNotebooks.aspx" style="font-size: 30px;">your notebooks</a></button>
            <button class="home-btn" style="font-size: 30px;">❤️ &#13;&#10;<a href="LikedNotebooks.aspx">liked notebooks</a></button>
            <button class="home-btn" style="font-size: 30px;">➕&#13;&#10;<a href="CreateNotebook.aspx">new notebook</a></button>
        </div>


        <br />
        <br />
        <br />

    </center>
</asp:Content>
