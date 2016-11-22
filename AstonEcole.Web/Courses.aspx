<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="AstonEcole.Web.Courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="Content/StyleSheetCourse.css" />
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:GridView ID="gridCourses" runat="server" AutoGenerateColumns="false" DataKeyNames="CourseId" OnSelectedIndexChanged="gridCourses_SelectedIndexChanged"
                CssClass="Grid">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="CourseId" />
                    <asp:BoundField HeaderText="Sujet" DataField="Subject" />
                    <asp:BoundField HeaderText="Enseignant" DataField="TeacherName" />
                    <asp:BoundField HeaderText="Nb. Elèves" DataField="NbStudents" />
                    <asp:CommandField HeaderText="" SelectText="Editer..." ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="NewCourse" runat="server" OnClick="NewCourse_Click" Text="Nouveau cours" />
            <br />
        </div>

        <span id="monSpan"></span>

        <div>
            <asp:HiddenField ID="hidIdCourse" runat="server" />
            <br />
            <asp:TextBox ID="txtCourseSubject" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlTeachers" runat="server" DataValueField="TeacherId" DataTextField="TeacherName"></asp:DropDownList>
            <br />
            <br />
            <asp:GridView ID="gridStudents" runat="server" AutoGenerateColumns="false" DataKeyNames="StudentId" OnRowDataBound="gridStudents_RowDataBound"
                CssClass="Grid">
                <Columns>
                    <asp:BoundField HeaderText="Nom" DataField="StudentName" />
                    <asp:CheckBoxField DataField="IsSelected" ReadOnly="false" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="SaveCourse" runat="server" Text="Sauvegarder" OnClick="SaveCourse_Click" />
        </div>
        <br />
        <a href="Course_jQuery.aspx">Cours jQuery</a>
        <br />
        <br />
        <a href="Index.aspx">Accueil</a>
    </form>
    <script>
        //$(document).ready(function () {

        //    var grid = $("#gridCourses");
        //    $("tr", grid).on("click", function () {
        //        $("#monSpan").text($("td:first", this).text());
        //    });

        //});

        $(document).ready(function () {

            var grid = $("#gridCourses");
            $("td", grid).on("click", function () {
                $("#monSpan").text((this).parentElement.firstElementChild.innerText);
            });

        });
    </script>
</body>
</html>
