<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNotebook.aspx.cs" Inherits="RamonSchool.ViewNotebook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <div class="container-fluid">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link active" href="Home.aspx"> <img src="Logo.png" width="60" height="60" /></a>
                   
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Home.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="About.aspx">About</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link active" href="Notebooks.aspx">Notebooks</a>
                </li>
                
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div>
            <div style="position: absolute; top: 20%; left: 67%;">
                <style>
                    .like-btn {
                        width: 40px;
                        height: 40px;
                        transition: 0.1s;
                    }

                        .like-btn:hover {
                            width: 42px;
                            height: 42px;
                        }
                </style>
                <center>
                    <asp:ImageButton ID="LikeButton" runat="server" ImageUrl="./Assets/LikeBefore.png" OnClick="LikeButton_Click" class="like-btn" />
                    <asp:Label Text="0" runat="server" Style="font-size: 23px; margin-left: 2px;" ID="LikeCountLabel" />
                </center>
            </div>

            <center>
                <br />
                <style>
                    .notebookInfo-block {
                        border-style: solid;
                        margin-top: 30px;
                        margin-left: 30px;
                        width: 60vh;
                    }

                    .notebookContent-block {
                        border-style: solid;
                        width: 90vh;
                    }
                </style>

                <div class="notebookInfo-block">
                    <h1>Title:
                <asp:Label ID="NoteTitle" runat="server" Text=""></asp:Label></h1>
                    <h2>Subject:
                <asp:Label ID="NotebookSubject" runat="server" Text=""></asp:Label></h2>
                    <h4>
                        <asp:Label ID="DescriptionLabel" runat="server" Text=""></asp:Label></h4>
                    <h4>last updated:<asp:Label ID="DateLBL" runat="server" Text=""></asp:Label></h4>
                    
             
                    <h4>
                        <h4>notebook creator:<asp:Label ID="UserLinkl" runat="server" Text=""></asp:Label></h4>
                </div>


                <br />
            </center>


            <asp:Panel ID="OnlinePanel" runat="server" Visible="true">

                <asp:Panel runat="server" ID="CantEditPanel" Visible="true" DefaultButton="">
                    <center>
                        <div runat="server" id="CantEditDiv" class="notebookContent-block" style="overflow-y: scroll; height: 60vmin; width: 100vmin;">
                        </div>
                    </center>
                    <style>
                        .comments-section {
                            position: absolute;
                            top: 35vmin;
                            left: 10vmin;
                            width: 40vmin;
                            height: 70vmin;
                            border-style: solid;
                            overflow-y: scroll;
                        }

                        .add-comment-block {
                            position: absolute;
                            top: 20vmin;
                            left: 10vmin;
                            width: 40vmin;
                            height: 12vmin;
                            border-style: solid;
                        }
                    </style>

                    <asp:Panel runat="server" ID="CommentPanel" DefaultButton="AddCommentBTN">
                        <div class="comments-section" style="padding: 10px;">


                            <asp:DataList runat="server" ID="CommentsDataList">
                                <ItemTemplate>
                                    <div class="card" style="width: 250px">
                                        <div class="card-header" style="display: flex; justify-content: space-between">
                                            <div>
                                                <b><%# Eval("Username") %> </b>
                                                <p style="padding: 0; margin: 0; font-size: 12px"><%# ((DateTime)Eval("CreatedDate")).ToString("dd/MM/yyyy") %></p>
                                            </div>
                               

                                        </div>

                                        <div class="card-body"><%# Eval("Comment") %></div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>

                        <div class="add-comment-block">
                            <center>
                                <h4>Add a comment</h4>
                                <div style="display: inline-flex; gap: 5px;">
                                    <asp:TextBox runat="server" Style="height: 5vmin; width: 30vmin; font-size: 20px; overflow: auto;" ID="CommentTextBox" TextMode="multiline" />
                                    <asp:Button Text="add" runat="server" ID="AddCommentBTN" OnClick="AddCommentBTN_Click" />
                                </div>

                            </center>

                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                </asp:Panel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
