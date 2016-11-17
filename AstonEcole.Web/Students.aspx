<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="AstonEcole.Web.Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
