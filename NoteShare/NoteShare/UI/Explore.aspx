<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="Explore.aspx.cs" Inherits="NoteShare.UI.Explore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .backbtn {
            margin-left: 20px;
        }
    </style>

    <asp:Button ID="BackBTN" runat="server" Text="Back" OnClick="BackBTN_Click" class="backbtn btn btn-warning" /><br />
    <style>
        .data-list-item {
            width: 150px;
            height: 150px;
            font-size: 10px;
            transition: 0.4s;
        }

            .data-list-item:hover {
                width: 180px;
                height: 180px;
                font-size: 12px;
            }
    </style>


    <center>
        <h1>Explore Notebooks</h1>
        <div>
            <asp:TextBox runat="server" type="text" ID="UserTB" placeholder="User" />
            <asp:DropDownList runat="server" ID="SubjectsDropdownlist" AppendDataBoundItems=true DataTextField="Name" DataValueField="Name" SelectMethod="GetSubjects">
        </asp:DropDownList>
         
             <asp:DropDownList runat="server" ID="SchoolsDropDownList" DataTextField="Name" DataValueField="Name" SelectMethod="GetUserSchools">
        </asp:DropDownList>
            <asp:TextBox runat="server" type="text" ID="DescripionTB" placeholder="Descripion" />
        </div>
        <br />
        <asp:Button Text="Search" runat="server" ID="SearchButton" CssClass="btn btn-primary" OnClick="SearchButton_Click" /><br />
        <br />

        <asp:Label Text="Notebooks in this context doesn't exist" runat="server" Visible="false" ID="NotFoundLabel" />
        <asp:DataList ID="Notebooks" runat="server" Height="117px" OnItemCommand="Notebooks_ItemCommand" RepeatDirection="Horizontal" Width="268px">
            <ItemTemplate>
                <div class="data-list-item">
                    <center>
                        <asp:ImageButton ID="ColorIMG" class='data-list-item' ImageUrl='<%#"colors/" + Eval("Color") %>' runat="server" style="width: 150px; height: 150px;" CommandName="NotebookClick" CommandArgument='<%# Eval("NotebookId") %>' />
                    </center>
                    <h4 style="text-align: center;">
                        <asp:Label ID="TitleLBL" Text='<%# Eval("title") %>' runat="server" /></h4>
                </div>
            </ItemTemplate>
        </asp:DataList>

        <br />
        <br />
        <h1>Explore the most liked notebooks❤️</h1>
        <br />
        <br />

        <asp:Label Text="Notebooks in this context doesn't exist" runat="server" Visible="false" ID="Label1" />
        <asp:DataList ID="MostLikedDataList" runat="server" Height="117px" OnItemCommand="MostLikeNotebooks_ItemCommand" RepeatDirection="Horizontal" Width="268px">
            <ItemTemplate>
                <div class="data-list-item">
                    <center>
                        <asp:ImageButton ID="ColorIMG" class='data-list-item' ImageUrl='<%#"colors/" + Eval("Color") %>' runat="server" style="width: 150px; height: 150px;" CommandName="NotebookClick" CommandArgument='<%# Eval("NotebookId") %>' />
                    </center>
                    <h4 style="text-align: center;">
                        <asp:Label ID="TitleLBL" Text='<%# Eval("title") %>' runat="server" /></h4>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
        <h1>Reacently added notebooks</h1>
        <br />
        <br />

        <asp:Label Text="Notebooks in this context doesn't exist" runat="server" Visible="false" ID="Label2" />
        <asp:DataList ID="RecentlyAddedNotebooks" runat="server" Height="117px" OnItemCommand="Notebooks_ItemCommand" RepeatDirection="Horizontal" Width="268px">
            <ItemTemplate>
                <div class="data-list-item">
                    <center>
                        <asp:ImageButton ID="ColorIMG" class='data-list-item' ImageUrl='<%#"colors/" + Eval("Color") %>' runat="server" style="width: 150px; height: 150px;" CommandName="NotebookClick" CommandArgument='<%# Eval("NotebookId") %>' />
                    </center>
                    <h4 style="text-align: center;">
                        <asp:Label ID="TitleLBL" Text='<%# Eval("title") %>' runat="server" /></h4>
                    <h4 style="text-align: center;">
                        <asp:Label ID="CreateDateLBL" Text='<%# ((DateTime)Eval("CreatedDate")).ToString("dd/MM/yyyy") %>' runat="server" /></h4>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </center>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
