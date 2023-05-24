<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="RamonSchool.About" %>

<!DOCTYPE html>

<html>
<head>
    <title>About Ramon High School</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            font-size: 16px;
            line-height: 1.5;
        }

        h1 {
            text-align: center;
            margin-bottom: 20px;
            color: #3f3f3f;
        }

        p {
            margin-bottom: 20px;
        }
    </style>

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
                    <a class="nav-link active" href="Home.aspx">
                        <img src="Logo.png" width="60" height="60" /></a>

                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Home.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link active" href="About.aspx">About</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="Notebooks.aspx">Notebooks</a>
                </li>
                
            </ul>
        </div>
    </nav>


    <main style="padding: 20px">
        <h1>About Ramon High School</h1>
        <p>Ramon High School is a comprehensive high school located in [insert city], Israel. Founded in [insert year], our school has a rich history of academic excellence and a commitment to providing students with a well-rounded education.</p>
        <p>At Ramon, we believe in fostering a positive and supportive learning environment where every student has the opportunity to reach their full potential. Our faculty is comprised of dedicated and experienced educators who work closely with students to ensure they receive a challenging and rewarding education.</p>
        <p>Our academic programs are designed to meet the needs and interests of all students, regardless of their abilities. Our curriculum is diverse, covering a wide range of subjects, including mathematics, science, humanities, and the arts. In addition to rigorous academics, we offer a variety of extracurricular activities, such as sports, music, and drama, to help students develop their interests and skills outside of the classroom.</p>
        <p>Our commitment to excellence is reflected in the achievements of our students, who regularly go on to attend some of the top universities both in Israel and around the world. If you're looking for a high-quality education in a supportive and challenging learning environment, consider joining the Ramon community!</p>
    </main>

</body>
</html>
