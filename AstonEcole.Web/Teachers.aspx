<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teachers.aspx.cs" Inherits="AstonEcole.Web.Teachers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.10.2.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <div>
            <asp:GridView ID="gridTeachers" runat="server" AutoGenerateColumns="False" DataKeyNames="TeacherId" OnSelectedIndexChanged="gridTeachers_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="TeacherId" />
                    <asp:BoundField HeaderText="Nom" DataField="TeacherName" />
                    <asp:CommandField HeaderText="" SelectText="Editer..." ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
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

        <br />
        <span id="monSpan" runat="server"></span>

        <br />

        <a href="TeachersJQ.aspx">TeachersJQ</a>
        <a href="index.aspx">Index</a>

        <br />
            <input type="button" id="getEleves" value="Récupérer les élèves..." />
            <ul id="teachers"></ul>
            <script>
                $(document).ready(function () {
                    $("#getEleves").click(function () {
                        $.getJSON("http://localhost:56089/api/Teachers")
                        .done(function (data) {
                            // On success, 'data' contains a list of products.
                            $.each(data, function (key, item) {
                                // Add a list item for the product.
                                $('<li>', { text: item.Name }).appendTo($('#teachers'));
                            });
                        })
                    });
                });
          </script>
    </form>
</body>
</html>
