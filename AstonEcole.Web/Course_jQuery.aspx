<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course_jQuery.aspx.cs" Inherits="AstonEcole.Web.Course_jQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link rel="stylesheet" type="text/css" href="Content/StyleSheetCourse.css" />
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
</head>
<body>
    <form id="form_CoursejQuery" runat="server">

        <asp:ScriptManager runat="server">
            <Scripts>
                <%--Pour plus d'informations sur les scripts de regroupement dans ScriptManager, consultez http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Scripts Framework--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Scripts de site--%>
            </Scripts>
        </asp:ScriptManager>

        <div class="container body-content">
            <h2>Bienvenue sur ma page cours de mon Application Web</h2>

            <div>
                <asp:GridView ID="gridCourses" runat="server" AutoGenerateColumns="false" DataKeyNames="CourseId" CssClass="Grid">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="CourseId" />
                        <asp:BoundField HeaderText="Sujet" DataField="Subject" />
                        <asp:BoundField HeaderText="Enseignant" DataField="TeacherName" />
                        <asp:BoundField HeaderText="Nb. Elèves" DataField="NbStudents" />
                    </Columns>
                </asp:GridView>

            </div>

            <%--            <span id="monSpan"></span>--%>
            <br />
            <h4>Détail du cours</h4>
            <div>
                <ul id="details"></ul>
            </div>
            <br />
            <a href="Courses.aspx">Retour</a>
            <br />
            <br />
            <a href="Index.aspx">Accueil</a>
        </div>

        <div class="container body-content">
            <%--            <asp:ContentPlaceHolder ID="MainContent" runat="server">
            </asp:ContentPlaceHolder>--%>
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Mon ASP.NET Application</p>
            </footer>
        </div>
    </form>

    <script>

        $(document).ready(function () {
            // Envoyez une demande(requête) d'AJAX
            var gridQuery = $("#gridCourses");

            $("td", gridQuery).click(function () {

                $('#details').empty();

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
