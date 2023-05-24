<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="WebsiteStats.aspx.cs" Inherits="NoteShare.UI.WebsiteStats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .backbtn {
            margin-left: 20px;
        }
    </style>

    <!-- Font Awesome -->
    <link
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css"
        rel="stylesheet" />
    <!-- Google Fonts -->
    <link
        href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"
        rel="stylesheet" />
    <!-- MDB -->
    <link
        href="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.1.0/mdb.min.css"
        rel="stylesheet" />
    <!-- MDB -->
    <script
        type="text/javascript"
        src="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.1.0/mdb.min.js"></script>
    <style>
        .jumbotron {
            padding-top: 30px;
            padding-bottom: 30px;
            margin-bottom: 30px;
            color: inherit;
            background-color: #eee
        }

            .jumbotron .h1, .jumbotron h1 {
                color: inherit
            }

            .jumbotron p {
                margin-bottom: 15px;
                font-size: 21px;
                font-weight: 200
            }

            .jumbotron > hr {
                border-top-color: #d5d5d5
            }

        .container .jumbotron, .container-fluid .jumbotron {
            padding-right: 15px;
            padding-left: 15px;
            border-radius: 6px
        }

        .jumbotron .container {
            max-width: 100%
        }

        @media screen and (min-width:768px) {
            .jumbotron {
                padding-top: 48px;
                padding-bottom: 48px
            }

            .container .jumbotron, .container-fluid .jumbotron {
                padding-right: 60px;
                padding-left: 60px
            }

            .jumbotron .h1, .jumbotron h1 {
                font-size: 63px
            }
        }
    </style>
    <asp:Button ID="BackBTN" runat="server" Text="Back" OnClick="BackBTN_Click" class="backbtn btn btn-warning" /><br />
    <center>
        <h1>Website statistics</h1>
        <div class="container">
            <div class="row">

                <div class="col-lg-4 col-md-6" style="margin-top: 20px">
                    <div class="card border-secondary">
                        <div class="card-body bg-secondary text-white">
                            <div class="row">
                                <div class="col-3">
                                    <i class="fa fa-user-graduate fa-5x"></i>
                                </div>
                                <div class="col-9 text-right">
                                    <h1>
                                        <asp:Label Text="text" runat="server" ID="NumberOfUsersLabel" /></h1>
                                    <h4>Users</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-md-6" style="margin-top: 20px">
                    <div class="card border-danger">
                        <div class="card-body bg-danger text-white">
                            <div class="row">
                                <div class="col-3">
                                    <i class="fa fa-book fa-5x"></i>
                                </div>
                                <div class="col-9 text-right">
                                    <h1>
                                        <asp:Label Text="text" runat="server" ID="NumberOfNotebooksLabel" /></h1>
                                    <h4>Notebooks</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6" style="margin-top: 20px">
                    <div class="card border-warning">
                        <div class="card-body bg-warning text-white">
                            <div class="row">
                                <div class="col-3">
                                    <i class="fa fa-university fa-5x"></i>
                                </div>
                                <div class="col-9 text-right">
                                    <h1>
                                        <asp:Label Text="text" runat="server" ID="NumberOfSchoolsLabel" /></h1>
                                    <h4>Schools</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6" style="margin-top: 20px">
                    <div class="card border-primary">
                        <div class="card-body bg-primary text-white">
                            <div class="row">
                                <div class="col-3">
                                    <i class="fa-solid fa-bars fa-5x"></i>
                                </div>
                                <div class="col-9 text-right">
                                    <h1>
                                        <asp:Label Text="text" runat="server" ID="NumberOfSubjectsLabel" /></h1>
                                    <h4>Subjects</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6" style="margin-top: 20px">
                    <div class="card border-secondary">
                        <div class="card-body bg-secondary text-white">
                            <div class="row">
                                <div class="col-3">
                                    <i class="fa-solid fa-lock fa-5x"></i>
                                </div>
                                <div class="col-9 text-right">
                                    <h1>
                                        <asp:Label Text="1" runat="server" ID="NumberOfAdminsLabel" /></h1>
                                    <h4>Admins</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6" style="margin-top: 20px">
                    <div class="card border-danger">
                        <div class="card-body bg-danger text-white">
                            <div class="row">
                                <div class="col-3">
                                    <i class="fa-solid fa-heart fa-5x"></i>
                                </div>
                                <div class="col-9 text-right">
                                    <h1>
                                        <asp:Label Text="1" runat="server" ID="NumberOfLikesLabel" /></h1>
                                    <h4>Likes</h4>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <br />
        <br />
        <br />
        <div style="display: inline-flex; gap: 50px;justify-content:center">

            <div>
                <h1>Notebooks Statistics</h1>
                <div style="display: flex; gap: 150px">
                    <div>
                        <h3 style="margin-left:70px;">Notebooks format</h3>
                        <canvas id="pieChart5"></canvas>
                    </div>
                    <div>
                        <h3 style="margin-left:70px;">Notebooks Accesibilty</h3>
                        <canvas id="pieChart6"></canvas>
                    </div>
                    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.min.js"></script>
                    <link href="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.css" rel="stylesheet" />
                    <script>
                        // MAKE ROUNDED EDGES FOR PIE CHARTS
                        Chart.defaults.RoundedDoughnut = Chart.helpers.clone(Chart.defaults.doughnut);
                        Chart.controllers.RoundedDoughnut = Chart.controllers.doughnut.extend({
                            draw: function (ease) {
                                var ctx = this.chart.ctx;
                                var easingDecimal = ease || 1;
                                var arcs = this.getMeta().data;
                                Chart.helpers.each(arcs, function (arc, i) {
                                    arc.transition(easingDecimal).draw();

                                    var pArc = arcs[i === 0 ? arcs.length - 1 : i - 1];
                                    var pColor = pArc._view.backgroundColor;

                                    var vm = arc._view;
                                    var radius = (vm.outerRadius + vm.innerRadius) / 2;
                                    var thickness = (vm.outerRadius - vm.innerRadius) / 2;
                                    var startAngle = Math.PI - vm.startAngle - Math.PI / 2;
                                    var angle = Math.PI - vm.endAngle - Math.PI / 2;

                                    ctx.save();
                                    ctx.translate(vm.x, vm.y);

                                    ctx.fillStyle = i === 0 ? vm.backgroundColor : pColor;
                                    ctx.beginPath();
                                    ctx.arc(radius * Math.sin(startAngle), radius * Math.cos(startAngle), thickness, 0, 2 * Math.PI);
                                    ctx.fill();

                                    ctx.fillStyle = vm.backgroundColor;
                                    ctx.beginPath();
                                    ctx.arc(radius * Math.sin(angle), radius * Math.cos(angle), thickness, 0, 2 * Math.PI);
                                    ctx.fill();

                                    ctx.restore();
                                });
                            }
                        });



                        // EXAMPLE 5 - notebook format
                        var ctx5 = document.getElementById("pieChart5");
                        var pieChart5 = new Chart(ctx5, {
                            type: 'pie',
                            options: {
                                cutoutPercentage: 50,
                                legend: {
                                    position: 'left',
                                    labels: {
                                        boxWidth: 10,
                                        fontStyle: 'italic',
                                        fontColor: '#aaa',
                                        usePointStyle: true,
                                    }
                                },
                            },
                            data: {
                                labels: [
                                    "online",
                                    "document",
                                ],
                                datasets: [
                                    {
                                        data: [<%=NoteShare.Models.NotebookTbl.getAllNotebooks().FindAll(x => x.Format == "online").Count%>, <%= NoteShare.Models.NotebookTbl.getAllNotebooks().FindAll(x => x.Format == "document").Count%>],
                                                   borderWidth: 2,
                                                   borderColor: [
                                                       '#46d8d5',
                                                       "#f5e132",
                                                   ],
                                                   backgroundColor: [
                                                       'rgba(70, 215, 212, 0.22)',
                                                       "rgba(245, 225, 50, 0.23)",
                                                   ],
                                                   hoverBackgroundColor: [
                                                       '#46d8d5',
                                                       "#f5e132",
                                                   ]
                                               }]
                                       }
                                   });

                        // EXAMPLE 5 - notebook format
                        var ctx6 = document.getElementById("pieChart6");
                        var pieChart6 = new Chart(ctx6, {
                            type: 'pie',
                            options: {
                                cutoutPercentage: 50,
                                legend: {
                                    position: 'left',
                                    labels: {
                                        boxWidth: 10,
                                        fontStyle: 'italic',
                                        fontColor: '#aaa',
                                        usePointStyle: true,
                                    }
                                },
                            },
                            data: {
                                labels: [
                                    "private",
                                    "public",
                                ],
                                datasets: [
                                    {
                                        data: [<%=NoteShare.Models. NotebookTbl.getAllNotebooks().FindAll(x => x.Accessibility == "public").Count%>, <%= NoteShare.Models.NotebookTbl.getAllNotebooks().FindAll(x => x.Accessibility == "private").Count%>],
                                                   borderWidth: 2,
                                                   borderColor: [
                                                       '#46d8d5',
                                                       "#f5e132",
                                                   ],
                                                   backgroundColor: [
                                                       'rgba(70, 215, 212, 0.22)',
                                                       "rgba(245, 225, 50, 0.23)",
                                                   ],
                                                   hoverBackgroundColor: [
                                                       '#46d8d5',
                                                       "#f5e132",
                                                   ]
                                               }]
                                       }
                                   });

                    </script>
                </div>
            </div>
        </div>
        <br />
        <br />
        <div>
            <h2>Most Liked Notebooks:</h2>
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
        </div>
        <br />
        <br />
        <br />
        <div>
            <h2>Active users</h2>

            <br />
            <br />
            <style>
                .school-block {
                    border-style: solid;
                    margin-top: 30px;
                    margin-left: 30px;
                    width: 30vh;
                }
            </style>
            <asp:DataList ID="ActiveUsersDataList" runat="server" Height="117px" OnItemCommand="Users_ItemCommand" Width="268px" RepeatColumns="6">
                <ItemTemplate>
                    <div class="school-block">
                        <h4><b>Username:</b><asp:Label Text='<%#Eval("Username") %>' runat="server" /></h4>
                        <asp:Button Text="profile" runat="server" CssClass="btn btn-primary" Style="margin-left: 10px; margin-bottom: 10px;" CommandName="UserClick" CommandArgument='<%# Eval("UserId") %>' />
                        <asp:Button Text="Delete" runat="server" Style="margin-left: 10px; margin-bottom: 10px;" class="btn btn-danger" CommandName="DeleteUser" CommandArgument='<%#Eval("UserId") %>' />
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <br />
            <br />
        </div>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
