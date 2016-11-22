<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course_jQuery.aspx.cs" Inherits="AstonEcole.Web.Course_jQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
</head>
<body>
    <form id="form_CoursejQuery" runat="server">
        <div>
            <h3>Liste des cours</h3>
        </div>
        <div>
            <asp:GridView ID="gridCourses" runat="server" AutoGenerateColumns="false" DataKeyNames="CourseId">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="CourseId" />
                    <asp:BoundField HeaderText="Sujet" DataField="Subject" />
                    <asp:BoundField HeaderText="Enseignant" DataField="TeacherName" />
                    <asp:BoundField HeaderText="Nb. Elèves" DataField="NbStudents" />
                </Columns>
            </asp:GridView>

        </div>
        <div></div>
        <span id="monSpan"></span>

        <br />
        <div>
            <%--            <asp:DetailsView ID="DetailsView_jQuery" runat="server" Height="50px" Width="125px" Visible="False">--%>
<%--            <asp:DetailsView ID="DetailsView_jQuery" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="ObjectDataSource1"
                AllowPaging="True" EnableViewState="False">

            </asp:DetailsView>--%>
        </div>

        <h4>Détail du cours</h4>
        <div>
            <ul id="details"></ul>
        </div>
    </form>
    <script>

        $(document).ready(function () {
            // Envoyez une demande(requête) d'AJAX
            var gridQuery = $("#gridCourses");

            $("td", gridQuery).click(function () {

                //$("#monSpan").text((this).parentElement.firstElementChild.innerText);
                var idCours = (this).parentElement.firstElementChild.innerText

                $.getJSON("http://localhost:51767/api/Course/" + idCours)
                    .done(function (data) {
                        // Sur le succès, 'les données' contiennent une liste de cours.
                        $('<li>', { text: "< -- Le cours -- >" }).appendTo($('#details'));
                        $('<li>', { text: "Id du Cours : " + data.Id }).appendTo($('#details'));
                        $('<li>', { text: "Nom de la matière : " + data.Subject }).appendTo($('#details'));
                        $('<br/>').appendTo($('#details'));
                        $('<li>', { text: "< -- Le prof -- >" }).appendTo($('#details'));
                        $('<li>', { text: "Id du professeur : " + data.Teacher.Id }).appendTo($('#details'));
                        $('<li>', { text: "Nom du professeur : " + data.Teacher.Name }).appendTo($('#details'));
                        $('<br/>').appendTo($('#details'));

                    })
            });
        });

        ////AUTRE ...
        //$(document).ready(function () {
        //    // Envoyez une demande(requête) d'AJAX
        //    $("#getStudents").click(function () {
        //        $.getJSON("http://localhost:56089/api/Students")
        //            .done(function (data) {
        //                // Sur le succès, 'les données' contiennent une liste de produits.
        //                $.each(data, function (key, item) {
        //                    // Ajoutez un article de liste pour le produit.
        //                    $('<li>', { text: item.FirstName }).appendTo($('#students'));
        //                });
        //            })
        //    });

        //    $("#quand").click(function () {
        //        $.getJSON("http://localhost:51767/api/Test")
        //            .done(function (data) {
        //                // On success, 'data' contains a list of products.
        //                $("#txtDateJour").text(data);
        //            })
        //    });
        //});
    </script>
</body>
</html>
