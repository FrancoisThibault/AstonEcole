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

        <asp:GridView ID="GridViewStudents" DataKeyNames="Id" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewStudents_SelectedIndexChanged" OnPreRender="GridViewStudents_PreRender">
            <Columns>
                 <asp:BoundField HeaderText="Id Student" DataField="Id" />
                <asp:BoundField HeaderText="Nom Student" DataField="NomStudent" />
                <asp:BoundField HeaderText="Nombre Elèves" DataField="NbCours" />
                                
                <asp:CommandField  SelectText="Voir" ShowSelectButton="true" /> 
                
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
