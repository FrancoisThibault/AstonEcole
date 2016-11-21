<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeachersJQ.aspx.cs" Inherits="AstonEcole.Web.TeachersJQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <br />
        <br />
        <div>
            <asp:GridView ID="gridTeachers" runat="server" AutoGenerateColumns="False" DataKeyNames="TeacherId" >
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="TeacherId" />
                    <asp:BoundField HeaderText="Nom" DataField="TeacherName" />
                </Columns>
            </asp:GridView>
        
        <br />
            <asp:HiddenField ID="hidTeacherId" runat="server" />
            <asp:TextBox ID="txtTeacherName" runat="server"></asp:TextBox>
            
        <br />
        <br />
        <span id="monSpan" runat="server"></span>
       </div>
              <script>
                $(document).ready(function () {
                    var grid = $("#gridTeachers");
                    $("td", grid).on("click", function () {
                        $("#monSpan").text((this).parentElement.firstElementChild.innerText);
                    });
                });
             </script>
    </form>
</body>
</html>
