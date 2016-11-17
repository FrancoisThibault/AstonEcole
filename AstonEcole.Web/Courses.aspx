<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="AstonEcole.Web.Courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridCourses" runat="server" AutoGenerateColumns="false" DataKeyNames="CourseId" OnSelectedIndexChanged="gridCourses_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Sujet" DataField="Subject" />
                    <asp:BoundField HeaderText="Enseignant" DataField="TeacherName" />
                    <asp:BoundField HeaderText="Nb. Elèves" DataField="NbStudents" />
                    <asp:CommandField HeaderText="" SelectText="Editer..." ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="NewCourse" runat="server" OnClick="NewCourse_Click" Text="Nouveau cours" />
        </div>
        <div>
            <asp:HiddenField ID="hidIdCourse" runat="server" />
            <asp:TextBox ID="txtCourseSubject" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlTeachers" runat="server" DataValueField="TeacherId" DataTextField="TeacherName"></asp:DropDownList>
            <asp:GridView ID="gridStudents" runat="server" AutoGenerateColumns="false" DataKeyNames="StudentId" OnRowDataBound="gridStudents_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Nom" DataField="StudentName" />
                    <asp:CheckBoxField DataField="IsSelected" ReadOnly="false" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="SaveCourse" runat="server" Text="Sauvegarder" OnClick="SaveCourse_Click" />
        </div>
    </form>
</body>
</html>
