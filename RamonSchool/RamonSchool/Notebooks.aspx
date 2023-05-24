<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notebooks.aspx.cs" Inherits="RamonSchool.Notebooks" EnableEventValidation="false" %>

<!DOCTYPE html>

<html>

<head>
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
        <center>
            <br />
            <br />
               <h3>In Ramon, it is importnat to us to keep up with technology. </h3>
                <h1>Explore Notebooks of students from the <b>NoteShare</b> App.</h1>
                

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


   
        <br />
        <br />

        
        <asp:DataList ID="NotebooksDataList" runat="server" Height="117px" OnItemCommand="NotebooksDataList_ItemCommand" RepeatDirection="Horizontal" Width="268px">
            <ItemTemplate>
                <div class="data-list-item">
                    <center>
                        <asp:ImageButton ID="ColorIMG" class='data-list-item' ImageUrl='<%#"colors/" + Eval("Color") %>'  runat="server" style="width: 150px; height: 150px;"  CommandName="NotebookClick" CommandArgument='<%# Eval("NotebookId") %>' />
                    </center>
                    <h4 style="text-align: center;">
                        <asp:Label ID="TitleLBL" Text='<%# Eval("title") %>' runat="server" /></h4>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
       
    </center>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
        </center>
     
        
    </form>
</body>
</html>
