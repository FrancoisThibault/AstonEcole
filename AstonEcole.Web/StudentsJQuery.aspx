<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsJQuery.aspx.cs" Inherits="AstonEcole.Web.StudentsJQuery" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <title></title>




    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="stylesheet" href="Content/bootstrap.min.css" />
     <link rel="stylesheet" href="Content/Student.css" />
</head>
<body>
    <script>

        $(document).ready(function () {




            var grid = $("#GridViewStudents");

            // récuperer l'id du 1er td quand clic sur la ligne tr
            //$("tr", grid).on("click", function () {
            //    var idEleve = $("td:first", this).text();
            //    $("#monSpan").text(" idEleve :" + idEleve);
            //    $.getJSON("http://localhost:51767/api/Students/" + idEleve)
            //        .done(function (data) {
            //            // On success, 'data' contains l'eleve sélectionné
            //            // $("#inputNomEleve").text(data.FirstName);
            //            // $("#inputNomEleve").visible = true;
            //            $("#inputNomEleve").val(data.FirstName);
            //        });
            //})


            //// On passe par l'API du projet Api
            //$("tr", grid).on("click", function () {
            //    var idEleve = $("td:first", this).text();
            //    $.getJSON("http://localhost:51767/api/Students/" + idEleve)
            //        .done(function (data) {
            //            // On success, 'data' contains a list of students
            //            $.each(data, function (propertyName, valueOfPropertyName) {
            //                // Add a list item for the product.
            //                $('<li>', { text: propertyName+" "+ valueOfPropertyName }).appendTo($('#students'));
            //            });
            //        })
            //});

            //$("tr", grid).on("click", function () {
            //    var idEleve = $("td:first", this).text();
            //    $.getJSON("http://localhost:51767/api/Students/" + idEleve)
            //        .done(function (data) {
            //            // On success, 'data' contains a list of students
            //            $.each(data, function (propertyName, valueOfPropertyName) {
            //                // Add a list item for the product.

            //                var li = $('<li>', { text: myfunc(propertyName, valueOfPropertyName) });
            //                li.appendTo($('#students'));
            //            });
            //        })
            //});

            $("tr", grid).on("click", function () {
                var idEleve = $("td:first", this).text();
                $.getJSON("http://localhost:51767/api/Students/" + idEleve)
                    .done(function (data) {

                        var rowDetailStudent = $('<div>');

                        rowDetailStudent.addClass("row rowDetailStudent");
                        rowDetailStudent.appendTo($('#divDetailStudent'));

                        // On success, 'data' contains a list of students
                        $.each(data, function (propertyName, valueOfPropertyName) {
                            // Add a list item for the product.
                            // var row = $('<div>', { class : myfunc(propertyName, valueOfPropertyName) });
                            //var div = $('div', { 'id': 'newtab', 'class': 'row' });
                            //div.appendTo($('#divDetailStudent'));

                             
                            var found = false;
                            $("#divdetailstudent div").each(function (divelement) {
                                if (divelement.attr('id') == 'Id') {
                                     
                                    if (divelement.attr('text') == valueofpropertyname) {
                                        found = true;
                                    }
                                }
                            })

                            //if (propertyName == 'Id') {
                            //    $(rowDetailStudent, { id: "rowDetailStudent" + valueOfPropertyName });
                            //}

                            if (!found)
                            {

                                var row = $('<div>');
                                row.addClass("row rowDetailPropertyStudent");
                                row.appendTo(rowDetailStudent);


                                var col = $('<div>', { text: propertyName, id: propertyName });
                                col.addClass('col-md-2 colName');
                                col.appendTo(row);

                                var col2 = $('<div>', { text: valueOfPropertyName });
                                col2.addClass('col-md-2 colValue');
                                col2.appendTo(row);

                                var col3 = $('<div>', { text: valueOfPropertyName });
                                col3.addClass('col-md-2 colValue2');
                                col3.appendTo(row);
                            }

                         

                             

                            //var div2 = document.createElement('div');
                            //div2.addClass("row");
                            //$('#divDetailStudent').appendChild(div2);

                            //var li = $('<li>', { text: myfunc(propertyName, valueOfPropertyName) });
                            //li.appendTo($('#students'));
                        });
                    })
            });



            function myfunc(a, b) {
                return a + " : " + b;
                //if (jQuery.isEmptyObject(b)) {
                //    if (jQuery.type(b) === "string") {
                //        return a + " : " + b;
                //    }
                //    else {
                //        if (jQuery.type(b) === "number") {
                //            return a + " : " + b.toString();;
                //        }
                //        else {
                //            return a + " : [] ";
                //        }

                //    }

                //}
                //else {
                //    $.each(b, function (propertyName, valueOfPropertyName) {
                //        //if (jQuery.isPlainObject(valueOfPropertyName)) {
                //            return propertyName + " :" + myfunc(propertyName, valueOfPropertyName);
                //       // }
                //    })
                //}
                //if (jQuery.isEmptyObject(b)) {
                //    return b.propertyName + " : " + b.valueOfPropertyName;
                //}
                //else {
                //    $.each(b, function (propertyName, valueOfPropertyName) {

                //       return propertyName + " :" + myfunc(propertyName, valueOfPropertyName);

                //    })
                //}
                //  return a + " : " + b + "\n type : " + jQuery.type(b) + "\n" + b.propertyName + " : " + b.valueOfPropertyName + "isEmptyObject : " + jQuery.isEmptyObject(b);
            }

            //// On passe par l'API du projet Api
            //$("tr", grid).on("click", function () {
            //    var idEleve = $("td:first", this).text();
            //    $.getJSON("http://localhost:51767/api/Students")
            //        .done(function (data) {
            //            // On success, 'data' contains a list of students
            //            $.each(data, function (key, item) {
            //                // Add a list item for the product.
            //                $('<li>', { text: item.FirstName }).appendTo($('#students'));
            //            });
            //        })
            //});


        });



    </script>

    <form id="form1" runat="server">
        <div class="container">
            <div>

                <h1>Liste des étudiants</h1>
            </div>

            <div>

                <asp:GridView CssClass="table table-hover table-striped" ID="GridViewStudents" runat="server" OnPreRender="GridViewStudents_PreRender" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Id Student" DataField="Id" />
                        <asp:BoundField HeaderText="Nom Student" DataField="NomStudent" />
                        <asp:BoundField HeaderText="Nombre Cours" DataField="NbCours" />
                    </Columns>
                </asp:GridView>

            </div>



          <%--  <div>
                <label>Nom Etudiant</label>
                <input id="inputNomEleve" />
            </div>

            <div>
                <ul id="students">
                    <li>

                        <label>Identifiant Etudiant</label>
                        <input id="liIdEleve" />
                    </li>
                    <li>

                        <label>Nom Etudiant</label>
                        <input id="liNomEleve" />

                    </li>

                </ul>

            </div>--%>

            <div id="divDetailStudent">
               
            </div>


            <div>
                <span id="monSpan"></span>
            </div>


            <div hidden="hidden">
                <input type="button" id="VoirEleve" value="Quel est le nom de l'étudiant ?" />
                <input type="text" id="quelIdEleve" />
                <span id="txtNomEleve"></span>
            </div>
        </div>
    </form>
</body>
</html>
