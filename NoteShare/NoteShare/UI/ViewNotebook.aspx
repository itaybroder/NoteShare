<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="ViewNotebook.aspx.cs" Inherits="NoteShare.UI.ViewNotebook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <!-- FontAwesome Icons -->
        <link
            rel="stylesheet"
            href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.1.1/css/all.min.css" />

    <style>
        .backbtn {
            margin-left: 20px;
        }
    </style>
    <style>
        .home-btn {
            height: 300px;
            width: 300px;
            font-size: 30px;
            margin-top: 5vh;
            transition: 0.5s;
        }

            .home-btn:hover {
                height: 320px;
                width: 320px;
            }

        .backbtn {
            margin-left: 20px;
        }
    </style>
    <asp:Button ID="BackBTN" runat="server" Text="Back" OnClick="BackBTN_Click" class="backbtn btn btn-warning" /><br />
    <asp:Button ID="SwitchView" runat="server" class="btn btn-info" Text="Switch View" OnClick="SwitchView_Click" Style="position: absolute; top: 29%; left: 90%;" />
    <br />
    <div style="position: absolute; top: 54%; left: 67%;">
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
            <asp:ImageButton ID="LikeButton" runat="server" ImageUrl="~/UI/Assets/LikeBefore.png" OnClick="LikeButton_Click" class="like-btn" />
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
            <h4>created date:<asp:Label ID="CreateDate" runat="server" Text=""></asp:Label></h4>
            <h4>notebook type:<asp:Label ID="NotebookTypeLabel" runat="server" Text=""></asp:Label></h4>
            <h4>notebook school:<asp:Label ID="NotebookSchoolLabel" runat="server" Text=""></asp:Label></h4>
            <asp:Button ID="UpdateButton" runat="server" Text="Update Notebook" class="home-btn" OnClick="UpdateButton_Click" Style="margin-top: 0px; margin-bottom: 5px; width: 300px; height: 40px; font-size: 18px;" />
            <h4>
                <h4>notebook creator:<asp:Label ID="UserLinkl" runat="server" Text=""></asp:Label></h4>
        </div>


        <br />
    </center>


    <asp:Panel ID="OnlinePanel" runat="server" Visible="false">

        

        <asp:Panel runat="server" ID="EditView" Visible="false">
            <center>
                <div class="containerr">
                    <div class="options">
                        <button id="bold" type="button" class="option-button format">
                            <i class="fa-solid fa-bold"></i>
                        </button>



                        <button id="italic" type="button" class="option-button format">
                            <i class="fa-solid fa-italic"></i>
                        </button>
                        <button id="underline" type="button" class="option-button format">
                            <i class="fa-solid fa-underline"></i>
                        </button>
                        <button id="strikethrough" type="button" class="option-button format">
                            <i class="fa-solid fa-strikethrough"></i>
                        </button>
                        <button id="superscript" type="button" class="option-button script">
                            <i class="fa-solid fa-superscript"></i>
                        </button>
                        <button id="subscript" type="button" class="option-button script">
                            <i class="fa-solid fa-subscript"></i>
                        </button>
                        <!-- List -->
                        <button id="insertOrderedList" type="button" class="option-button">
                            <div class="fa-solid fa-list-ol"></div>
                        </button>
                        <button id="insertUnorderedList" type="button" class="option-button">
                            <i class="fa-solid fa-list"></i>
                        </button>
                        <!-- Undo/Redo -->
                        <button id="undo" type="button" class="option-button">
                            <i class="fa-solid fa-rotate-left"></i>
                        </button>
                        <button id="redo" type="button" class="option-button">
                            <i class="fa-solid fa-rotate-right"></i>
                        </button>
                        <!-- Link -->
                        <button id="createLink" type="button" class="adv-option-button">
                            <i class="fa fa-link"></i>
                        </button>
                        <button id="unlink" type="button" class="option-button">
                            <i class="fa fa-unlink"></i>
                        </button>
                        <!-- Alignment -->
                        <button id="justifyLeft" type="button" class="option-button align">
                            <i class="fa-solid fa-align-left"></i>
                        </button>
                        <button id="justifyCenter" type="button" class="option-button align">
                            <i class="fa-solid fa-align-center"></i>
                        </button>
                        <button id="justifyRight" type="button" class="option-button align">
                            <i class="fa-solid fa-align-right"></i>
                        </button>
                        <button id="justifyFull" type="button" class="option-button align">
                            <i class="fa-solid fa-align-justify"></i>
                        </button>
                        <button id="indent" type="button" class="option-button spacing">
                            <i class="fa-solid fa-indent"></i>
                        </button>
                        <button id="outdent" type="button" class="option-button spacing">
                            <i class="fa-solid fa-outdent"></i>
                        </button>
                        <!-- Headings -->
                        <select id="formatBlock" class="adv-option-button">
                            <option value="H1">H1</option>
                            <option value="H2">H2</option>
                            <option value="H3">H3</option>
                            <option value="H4">H4</option>
                            <option value="H5">H5</option>
                            <option value="H6">H6</option>
                        </select>
                        <!-- Font -->
                        <select id="fontName" type="button" class="adv-option-button"></select>
                        <select id="fontSize" class="adv-option-button"></select>
                        <!-- Color -->
                        <div class="input-wrapper">
                            <input type="color" id="foreColor" class="adv-option-button" />
                            <label for="foreColor">Font Color</label>
                        </div>
                        <div class="input-wrapper">
                            <input type="color" id="backColor" class="adv-option-button" />
                            <label for="backColor">Highlight Color</label>
                        </div>
                    </div>



                    <div runat="server" id="textinput" contenteditable="true" onchange="HtmlChange()" style="overflow-y: scroll; height: 400px;">
                    </div>



                    <script src="editor.js"></script>
                    <!-- Stylesheet -->
                    <link rel="stylesheet" href="editor.css" />

                    <br />
                    <button type="button" onclick="sendData()" class="btn btn-success" style="font-size: 20px; width: 80px; height: 40px;">Save</button>
                    <script>

                        function get(name) {
                            if (name = (new RegExp('[?&]' + encodeURIComponent(name) + '=([^&]*)')).exec(location.search))
                                return decodeURIComponent(name[1]);
                        }

                        function sendData() {
                            var xhr = new XMLHttpRequest();
                            xhr.open("POST", "https://localhost:44326/UI/ViewNotebook.aspx", true);
                            xhr.setRequestHeader('Content-Type', 'application/json');
                            xhr.setRequestHeader('mytext', document.getElementById("ContentPlaceHolder2_textinput").innerHTML);
                            xhr.setRequestHeader('notebookId', get("id"));
                            xhr.send(JSON.stringify({
                                "mytext": document.getElementById("ContentPlaceHolder2_textinput").innerHTML,
                            }));
                        }

                    </script>
                </div>
            </center>
        </asp:Panel>

        <asp:Panel runat="server" ID="CantEditPanel" Visible="true" DefaultButton="">
            <center>
                <div runat="server" id="CantEditDiv" class="notebookContent-block" style="overflow-y: scroll; height: 60vmin; width: 100vmin;">
                </div>
            </center>
  
            <br />
            <br />
        </asp:Panel>


        <!--Script-->
    </asp:Panel>


    <asp:Panel runat="server" ID="DocumentPanel" Visible="false">

        <center>
            <div style="display: inline-flex; gap: 100px">

                <asp:Button ID="DownloadButton" runat="server" Text="Download Notebook" class="home-btn" OnClick="DownloadButton_Click" />
            </div>
        </center>
        <h3>
            <asp:Label Text="" runat="server" ID="ErrorLabel" /></h3>
    </asp:Panel>
              <style>
                .comments-section {
                    position: absolute;
                    top: 55vmin;
                    left: 10vmin;
                    width: 36vmin;
                    height: 80vmin;
                    border-style: solid;
                    overflow-y: scroll;
                }

                .add-comment-block {
                    position: absolute;
                    top: 40vmin;
                    left: 10vmin;
                    width: 40vmin;
                    height: 12vmin;
                    border-style: solid;
                }
            </style>

            <asp:Panel runat="server" ID="CommentPanel" DefaultButton="AddCommentBTN">
                <div class="comments-section" style="padding: 10px;">


                    <asp:DataList runat="server" ID="CommentsDataList" OnItemCommand="Comments_ItemCommand" OnItemDataBound="CommentsDataList_ItemDataBound">
                        <ItemTemplate>
                            <div class="panel panel-default" style="width: 250px">
                                <div class="panel-heading" style="display: flex; justify-content: space-between">
                                    <div>
                                        
                                        <b><%# NoteShare.Models.UserTbl.GetUserByUserId((int)Eval("UserId")).Username %> </b>
                                        <p style="padding: 0; margin: 0; font-size: 12px"><%# ((DateTime)Eval("CreatedDate")).ToString("dd/MM/yyyy") %></p>
                                    </div>
                                    <div>
                                        <asp:LinkButton runat="server" Visible="false" ID="DeleteCommentButton" class="btn btn-danger px-3" CommandName="DeleteUser" CommandArgument='<%#Eval("CommentId") %>'> 
                                            <i class="fa fa-trash" aria-hidden="true"></i>
                                        </asp:LinkButton>
                                    </div>

                                </div>

                                <div class="panel-body"><%# Eval("Comment") %></div>
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
    <asp:Button Text="Delete Notebook" CssClass="btn btn-danger" ID="DeleteNotebookButton" OnClick="DeleteNotebookButton_Click" runat="server" />
</asp:Content>
