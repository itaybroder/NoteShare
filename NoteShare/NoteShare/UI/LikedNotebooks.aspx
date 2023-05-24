<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="LikedNotebooks.aspx.cs" Inherits="NoteShare.UI.LikedNotebooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style>
        .backbtn {
            margin-left: 20px;
        }
    </style>

    <asp:Button ID="BackBTN" runat="server" Text="Back" OnClick="BackBTN_Click" class="backbtn btn btn-warning" /><br />
    <center>
        <div class="animate__animated animate__rubberBand">
            <h3>Your Liked Notebooks</h3>
            <br />
            <br />

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
        </div>
    </center>
</asp:Content>
