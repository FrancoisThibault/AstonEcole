using AstonEcole.DTO;
using AstonEcole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonEcole.Web
{
    public partial class Teachers : System.Web.UI.Page
    {
        protected override void OnPreRender(EventArgs e)
        {
            using (TeacherServices svc = new TeacherServices())
            {
                var x = svc.LoadTeachersWithNbCourses();
                gridTeachers.DataSource = x.Select(t => new { TeacherId = t.Teacher.Id, TeacherName = t.Teacher.Name, NbCourses = t.NbCourses });
                gridTeachers.DataBind();
            }
            base.OnPreRender(e);
        }

        protected void gridTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelectedTeacher = (int)gridTeachers.SelectedValue;
            Teacher selectedTeacher;
            using (TeacherServices svc = new TeacherServices())
            {
                selectedTeacher = svc.LoadTeacher(idSelectedTeacher);
                hidTeacherId.Value = selectedTeacher.Id.ToString();
                txtTeacherName.Text = selectedTeacher.Name;
            }

            using (CoursesServices svc = new CoursesServices())
            {
                gridCourses.DataSource = svc.LoadCourses().Select(c => new { CourseId = c.Id, CourseName = c.Subject, IsSelected = c.Teacher?.Id == idSelectedTeacher });
                gridCourses.DataBind();
            }
        }

        protected void gridCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox checkBox = e.Row.Cells[e.Row.Cells.Count - 1].Controls[0] as CheckBox;
                if (checkBox != null)
                {
                    checkBox.Enabled = true;
                }
            }
        }

        protected void SaveTeacher_Click(object sender, EventArgs e)
        {
            int idUpdatingTeacher = int.Parse(hidTeacherId.Value);
            using (TeacherServices svc = new TeacherServices())
            {
                Teacher updatingTeacher = svc.LoadTeacher(idUpdatingTeacher);
                updatingTeacher.Name = txtTeacherName.Text;
                List<int> selectedCourses = new List<int>();
                foreach (GridViewRow row in gridCourses.Rows)
                {
                    CheckBox chk = row.Cells[row.Cells.Count - 1].Controls[0] as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        selectedCourses.Add((int)gridCourses.DataKeys[row.RowIndex]["CourseId"]);
                    }
                }

                svc.UpdateCourses(updatingTeacher, selectedCourses);
                svc.Save();
            }
        }
    }
}