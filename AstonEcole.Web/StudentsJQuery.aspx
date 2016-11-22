<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsJQuery.aspx.cs" Inherits="AstonEcole.Web.StudentsJQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <title></title>
</head>
<body>
    <script>

        $(document).ready(function () {

         

            // récuperer l'id du 1er td quand clic sur la ligne tr
            var grid = $("#GridViewStudents");
            $("tr", grid).on("click", function () {
                var idEleve = $("td:first", this).text();
                $("#monSpan").text(" idEleve :" + idEleve);
                $.getJSON("http://localhost:51767/api/Students/" + idEleve)
                    .done(function (data) {
                        // On success, 'data' contains l'eleve sélectionné
                        // $("#inputNomEleve").text(data.FirstName);
                        // $("#inputNomEleve").visible = true;
                        $("#inputNomEleve").val(data.FirstName);
                    });
            })


        });



    </script>

    <form id="form1" runat="server">
        <div>
             <label>Liste des étudiants</label>
        </div>

        <div>

            <asp:GridView ID="GridViewStudents" runat="server" OnPreRender="GridViewStudents_PreRender" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Id Student" DataField="Id" />
                    <asp:BoundField HeaderText="Nom Student" DataField="NomStudent" />
                    <asp:BoundField HeaderText="Nombre Cours" DataField="NbCours" />
                </Columns>
            </asp:GridView>

        </div>

       

            <div>
                <label>Nom Etudiant</label>
                <input id="inputNomEleve" />
            </div>

          
      
        <div>
            <span id="monSpan"></span>
        </div>


        <div hidden="hidden">           
            <input type="button" id="VoirEleve" value="Quel est le nom de l'étudiant ?" />
            <input type="text" id="quelIdEleve" />
            <span id="txtNomEleve"></span>
        </div>
    </form>
</body>
</html>
