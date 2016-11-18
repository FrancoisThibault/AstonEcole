<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="AstonEcole.Web.Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <title></title>
</head>
<body>
     <script>
        $(document).ready(function () {
            
            // On passe par l'API du projet Api
            $("#getStudents").click(function () {
                $.getJSON("http://localhost:56089/api/Students")
                    .done(function (data) {
                        // On success, 'data' contains a list of students
                        $.each(data, function (key, item) {
                            // Add a list item for the product.
                            $('<li>', { text: item.FirstName }).appendTo($('#students'));
                        });
                    })
            });

            // on passe par l'API du projet Web
            $("#quand").click(function () {
                $.getJSON("http://localhost:51767/api/Test")
                    .done(function (data) {
                        // On success, 'data' contains la dae du jour
                        $("#txtDateJour").text(data.FirstName);
                    })
            });

            // on passe par l'API du projet Web
            $("#VoirEleve1").click(function () {
                $.getJSON("http://localhost:51767/api/Students/1")
                    .done(function (data) {
                        // On success, 'data' contains la dae du jour
                        $("#txtNomEleve").text(data.FirstName);
                    })
            });

            // on passe par l'API du projet Web
            $("#VoirEleve2").click(function () {
                $.getJSON("http://localhost:51767/api/Students/2")
                    .done(function (data) {
                        // On success, 'data' contains la dae du jour
                        $("#txtNomEleve").text(data.FirstName);
                    })
            });

            // on passe par l'API du projet Web
            $("#VoirEleve3").click(function () {
                $.getJSON("http://localhost:51767/api/Students/3")
                    .done(function (data) {
                        // On success, 'data' contains la dae du jour
                        $("#txtNomEleve").text(data.FirstName);
                    })
            });

            // on passe par l'API du projet Web
            $("#VoirEleve").click(function () {
                var inputIdEleve = $("#quelIdEleve").val();
                $.getJSON("http://localhost:51767/api/Students/" + inputIdEleve)
                    .done(function (data) {
                        // On success, 'data' contains la dae du jour
                        $("#txtNomEleve").text(data.FirstName);
                    })
            });

        });
    </script>
    <form id="form1" runat="server">

         <div>
               <input type="button" id="quand" value="Quel jour sommes-nous ?"/>
     <span id="txtDateJour"></span>
              <input type="button" id="getStudents" value="Récupérer les élèves..." />
    <ul id="students"></ul>
        
               <input type="button" id="VoirEleve1" value="Quel est le nom de l'étudiant 1 ?"/>
              <input type="button" id="VoirEleve2" value="Quel est le nom de l'étudiant 2 ?"/>
              <input type="button" id="VoirEleve3" value="Quel est le nom de l'étudiant 3 ?"/>
                <input type="button" id="VoirEleve" value="Quel est le nom de l'étudiant ?"/>
             <input type="text" id="quelIdEleve" />
             <span id="txtNomEleve"></span>
    

            </div>
        

    <div>

        <asp:GridView ID="GridViewStudents" DataKeyNames="Id" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewStudents_SelectedIndexChanged"  OnPreRender="GridViewStudents_PreRender">
            <Columns>
                 <asp:BoundField HeaderText="Id Student" DataField="Id" />
                <asp:BoundField HeaderText="Nom Student" DataField="NomStudent" />
                <asp:BoundField HeaderText="Nombre Cours" DataField="NbCours" />
                                
                <asp:CommandField  SelectText="Voir" ShowSelectButton="true" /> 
                
            </Columns>
        </asp:GridView>
    
        <asp:TextBox ID="TextBoxNomEleve" runat="server"></asp:TextBox>
    
    </div>

         

         <div>
           <asp:GridView ID="GridViewListeCours" DataKeyNames="Id" runat="server" AutoGenerateColumns="False"  OnRowDataBound="GridViewListeCours_RowDataBound" >
            <Columns>
                 <asp:BoundField HeaderText="Id Cours" DataField="Id" />
                <asp:BoundField HeaderText="Sujet Cours" DataField="Subject" />                 
                <asp:CheckBoxField HeaderText="Assiste" DataField="Assiste"  />
                
            </Columns>
        </asp:GridView>
             </div>

          <div>
            <asp:Button runat="server"  ID="ButtonValider"   Text="Valider" OnClick="ButtonValider_Click" />
        </div>

    </form>
</body>
</html>
