<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RamonSchool.Home" %>

<!DOCTYPE html>

<html>
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
                    <a class="nav-link active" href="Home.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="About.aspx">About</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Notebooks.aspx">Notebooks</a>
                </li>
                
            </ul>
        </div>
    </nav>
    
    <main>
        <form runat="server">
        <center>
            <h1 style="margin-top:40px;">Welcome to Ramon high school</h1>
            <p>Ramon high school is located in hod hasharon, israel. which is named after ilan ramon, who was the first person on the moon.<br />
             the school has various of subjects to offer to the students. proffetional teachers and many more...</p>

            <iframe width="550" height="309" src="https://www.youtube.com/embed/oktbGF7jgaY" title="תיכון ע"ש אילן רמון" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>

            <br />
            <br />
            <p>Explore our new feture, check out our students notebooks or, see the students info</p>

            <style>
                .btn{
                    width:200px;
                    height:200px;
                    font-size:30px;
                }
            </style>
            <div style="display:flex;justify-content:center; gap:30px;">
                <div>
                    <button class="btn btn-danger" onclick="window.location.href = 'Notebook.aspx' > Notebooks</button>
                </div>
                
            </div>
            <br />
            <br />
            <br />
            <br />

        </center>
        </form>
    </main>
</body>
</html>
