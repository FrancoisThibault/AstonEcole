<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teachers.aspx.cs" Inherits="AstonEcole.Web.Teachers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridTeachers" runat="server" AutoGenerateColumns="False" DataKeyNames="TeacherId" OnSelectedIndexChanged="gridTeachers_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Nom" DataField="TeacherName" />
                    <asp:BoundField HeaderText="Nb. Cours" DataField="NbCourses" />
                    <asp:CommandField HeaderText="" SelectText="Editer..." ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:HiddenField ID="hidTeacherId" runat="server" />
            <asp:TextBox ID="txtTeacherName" runat="server"></asp:TextBox>
            <asp:GridView ID="gridCourses" runat="server" AutoGenerateColumns="False" DataKeyNames="CourseId" OnRowDataBound="gridCourses_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Nom" DataField="CourseName" />
                    <asp:CheckBoxField HeaderText="Assigné" DataField="IsSelected" ReadOnly="False" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="SaveTeacher" runat="server" OnClick="SaveTeacher_Click"/>
        </div>
    </form>
</body>
</html>
