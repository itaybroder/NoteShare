<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="CreateNotebook.aspx.cs" Inherits="NoteShare.UI.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="BackBTN" runat="server" Text="Back" OnClick="BackBTN_Click" Style="margin-left: 20px;" CssClass="btn btn-warning" />
    <center>
        <style>
            img {
                width: 140px;
                height: 140px;
            }
        </style>
        <h1>
            <asp:Label Text="Create your own notebook!" runat="server" ID="ModeLabel" /></h1>

        <br />
        <asp:TextBox runat="server" ID="TitleLBL" placeholder="Notebook Title" /><br />
        <br />
        <h2>Pick a subject:</h2>
        <asp:DropDownList runat="server" ID="SubjectsDropdownlist" DataTextField="Name" DataValueField="Name" SelectMethod="GetSubjects">
        </asp:DropDownList>

        <br />
        <br />
        <asp:TextBox runat="server" Height="127px" TextMode="MultiLine" Width="361px" ID="Description" placeholder="notebook description..." /><br />
        <br />

        <h4>choose your notebook accessibility</h4>
        <asp:RadioButtonList ID="accessibilityList" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text='public' Value="public" style="margin-right: 25px; font-size: 20px;" />
            <asp:ListItem Text='private' Value="private" Selected="True" style="font-size: 20px;" />
        </asp:RadioButtonList>
        <h4>choose a color</h4>

        <asp:RadioButtonList ID="ColorsList" runat="server" RepeatDirection="Horizontal" >
            <asp:ListItem Text='<img src="colors/red.png" alt="img1"/>' Value="red.png" Selected="True" />
            <asp:ListItem Text='<img src="colors/blue.png" alt="img2" />' Value="blue.png" />
            <asp:ListItem Text='<img src="colors/purple.png" alt="img2" />' Value="purple.png" />
            <asp:ListItem Text='<img src="colors/green.png" alt="img2" />' Value="green.png" />
        </asp:RadioButtonList>
        <br />

        <h4>choose the notebook school</h4>
        <asp:DropDownList runat="server" ID="SchoolsDropDownList" DataTextField="Name" DataValueField="SchoolId" SelectMethod="GetUserSchools">
        </asp:DropDownList>


        <h4>choose your notebook format</h4>
        <asp:RadioButtonList ID="FormatList" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="FormatList_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text='document' Value="document" style="margin-right: 25px; font-size: 20px;" />
            <asp:ListItem Text='online editor' Value="online" Selected="True" style="font-size: 20px;" />
        </asp:RadioButtonList>

        <asp:FileUpload ID="DocumentUpload" runat="server" /><br />


        <asp:Button Text="Create!" runat="server" OnClick="SubmitData" ID="SubmitButton" CssClass="btn btn-primary" /><br />
        <br />
    </center>

</asp:Content>

