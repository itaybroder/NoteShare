<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="NoteShare.UI.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .backbtn {
            margin-left: 20px;
        }
    </style>

    <asp:Button ID="BackBTN" runat="server" Text="Back" OnClick="BackBTN_Click" class="backbtn btn btn-warning" /><br />
    <center>
        <h3>Welcome to the admin panel, here you can have access for all the users, notebooks and schools</h3>


        <div class="container animate__animated animate__bounceInLeft">
            <div class="row">

                <div class="col-lg-6">
                    <h1>Users:</h1>
                    <asp:TextBox runat="server" placeholder="search" OnTextChanged="Search_TextChanged" ID="SearchText"  AutoPostBack = True/>
                    <asp:DataList ID="UsersDataList" runat="server" Height="117px" OnItemCommand="Users_ItemCommand" Width="268px" RepeatColumns="2">
                        <ItemTemplate>
                            <div class="school-block">
                                <h4><b>Username:</b><asp:Label Text='<%#Eval("Username") %>' runat="server" /></h4>
                                <asp:Button Text="profile" runat="server" CssClass="btn btn-primary" Style="margin-left: 10px; margin-bottom: 10px;" CommandName="UserClick" CommandArgument='<%# Eval("UserId") %>' />
                                <asp:Button Text="Delete" runat="server" Style="margin-left: 10px; margin-bottom: 10px;" class="btn btn-danger" CommandName="DeleteUser" CommandArgument='<%#Eval("UserId") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>

                </div>
                <div class="col-lg-6">
                    <style>
                        .school-block {
                            border-style: solid;
                            margin-top: 30px;
                            margin-left: 30px;
                            width: 30vh;
                        }
                    </style>

                    <h1>Schools:</h1>
                    <asp:Button Text="Add School" runat="server" ID="AddSchoolButton" OnClick="AddSchoolButton_Click" />
                    <asp:Panel runat="server" ID="createSchool" Visible="false">
                        <br />
                        <asp:TextBox runat="server" ID="CreateSchoolName" placeholder="School name" /><br />
                        <br />
                        <asp:TextBox runat="server" ID="CreateSchoolCountry" placeholder="School Country" /><br />
                        <br />
                        <asp:TextBox runat="server" ID="CreateSchoolAddress" placeholder="School Address" />
                        <br />
                        <br />
                        <asp:Button Text="Submit" runat="server" ID="submitSchoolButton" OnClick="submitSchoolButton_Click" />
                        <asp:Button Text="cancel" runat="server" ID="CancelButton" OnClick="CancelButton_Click" />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="EditSchool" Visible="false">
                        <br />
                        <asp:TextBox runat="server" ID="EditSchoolName" placeholder="School name" /><br />
                        <br />
                        <asp:TextBox runat="server" ID="EditSchoolCountry" placeholder="School Country" /><br />
                        <br />
                        <asp:TextBox runat="server" ID="EditSchoolAddress" placeholder="School Address" />
                        <br />
                        <asp:Label Text="" runat="server" Visible="false" ID="schoolIdLabel" />
                        <br />
                        <asp:Button Text="Submit" runat="server" ID="EditSchoolSummit" OnClick="EditSchoolSummit_Click" />
                        <asp:Button Text="cancel" runat="server" ID="Button2" OnClick="CancelButton_Click" />
                    </asp:Panel>
                    <asp:DataList ID="SchoolsDataList" runat="server" Height="117px" OnItemCommand="Schools_ItemCommand" Width="268px" RepeatColumns="2">
                        <ItemTemplate>
                            <div class="school-block">
                                <h4><b>Name:</b><asp:Label Text='<%#Eval("Name") %>' runat="server" /></h4>
                                <h4><b>Country:</b><asp:Label Text='<%#Eval("Country") %>' runat="server" /></h4>
                                <h4><b>Address:</b><asp:Label Text='<%#Eval("Address") %>' runat="server" /></h4>
                                <h4><b>Number of users:</b><asp:Label Text='<%# NoteShare.Models.UserInSchoolTbl.getAllUsersInSchoolBySchoolId((int)Eval("SchoolId")).Count  %>' runat="server" /></h4>
                                <h4><b>Number of notebooks:</b><asp:Label Text='<%# NoteShare.Models.NotebookTbl.getNotebooksFromSchoolId((int)Eval("SchoolId")).Count  %>' runat="server" /></h4>


                                <asp:Button Text="Edit" runat="server" Style="margin-left: 10px; margin-bottom: 10px;" CssClass="btn btn-primary" CommandName="EditSchool" CommandArgument='<%#Eval("SchoolId") %>' />
                                <asp:Button Text="Delete" runat="server" Style="margin-left: 10px; margin-bottom: 10px;" class="btn btn-danger" CommandName="DeleteSchool" CommandArgument='<%#Eval("SchoolId") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="col-lg-6">
                    <style>
                        .school-block {
                            border-style: solid;
                            margin-top: 30px;
                            margin-left: 30px;
                            width: 30vh;
                        }
                    </style>

                    <h1>Subjects:</h1>
                    <asp:Panel runat="server" ID="Panel1">
                        <br />
                        <asp:TextBox runat="server" ID="SubjectTextBox" placeholder="Add a Subject" />
                        <asp:Button Text="add" runat="server" ID="AddSubjectButton" OnClick="AddSubjectButton_Click" /><br />
                        <br />

                    </asp:Panel>
                    <asp:DataList ID="SubjectsDataList" runat="server" Height="117px" Width="268px" OnItemCommand="SubjectsDataList_ItemCommand" RepeatColumns="2">
                        <ItemTemplate>
                            <div class="school-block">
                                <h4>
                                    <asp:Label Text='<%#Eval("Name") %>' runat="server" /></h4>
                                <asp:Button Text="Delete" runat="server" Style="margin-left: 10px; margin-bottom: 10px;" class="btn btn-danger" CommandName="DeleteSubject" CommandArgument='<%#Eval("SubjectId") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </center>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
