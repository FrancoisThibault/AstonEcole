using AstonEcole.ApiClient;
using AstonEcole.DTO;
using AstonEcole.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonEcole.Web
{
    public partial class Courses : AstonPage
    {
        protected override void OnPreRender(EventArgs e)
        {
            using (AstonApiClientCourse apiClientCourse = new AstonApiClientCourse())
            {
                gridCourses.DataSource = apiClientCourse.GetCourseNbEleves().Select(c =>
                new
                {
                    CourseId = c.Course.Id,
                    Subject = c.Course.Subject,
                    TeacherName = c.Course.Teacher?.Name,
                    NbStudents = c.NbStudents
                });

                gridCourses.DataBind();
            }

            base.OnPreRender(e);
        }

        protected void gridStudents_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gridCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelectedCourse = (int)gridCourses.SelectedValue;
            Course selectedCourse;
            using (AstonApiClientCourse apiClientCourse = new AstonApiClientCourse())
            {
                selectedCourse = apiClientCourse.GetCourseById(idSelectedCourse);
            }

            DisplayCourseDetails(selectedCourse);
        }

        private void DisplayCourseDetails(Course course)
        {
            hidIdCourse.Value = course.Id.ToString();
            txtCourseSubject.Text = course.Subject;

            using (AstonApiClientTeacher apiClientTeach = new AstonApiClientTeacher())
            {
                ddlTeachers.DataSource = apiClientTeach.getTeachers().Result.Select(t => new { TeacherId = t.Id, TeacherName = t.Name });
                ddlTeachers.DataBind();
                ddlTeachers.SelectedValue = course.Teacher?.Id.ToString();
            }

            using (AstonApiClientStudent apiClientStudent = new AstonApiClientStudent())
            {
                IEnumerable<Student> studentInCourse = apiClientStudent.GetStudents().Result.Where(s => s.Id == course.Id).ToList();
                IEnumerable<Student> allStudents = apiClientStudent.GetStudents().Result;
                gridStudents.DataSource = allStudents.Select(s => new { StudentId = s.Id, StudentName = s.FirstName, IsSelected = studentInCourse.Contains(s) });
                gridStudents.DataBind();
            }
        }

        protected void NewCourse_Click(object sender, EventArgs e)
        {
            using (AstonApiClientCourse apiClientCourse = new AstonApiClientCourse())
            {
                Course newCourse = new Course();
                newCourse.Students = new List<Student>();
                apiClientCourse.AddCourse(newCourse);
                DisplayCourseDetails(newCourse);
            }
        }

        protected void SaveCourse_Click(object sender, EventArgs e)
        {
            //int idSelectedCourse = int.Parse(hidIdCourse.Value);
            //Course selectedCourse;
            //using (AstonApiClientCourse apiClientCourse = new AstonApiClientCourse())
            //{
            //    if (idSelectedCourse == 0)
            //    {
            //        selectedCourse = apiClientCourse.CreateCourse();
            //    }
            //    else
            //    {
            //        selectedCourse = svc.LoadCourse(idSelectedCourse);
            //    }

            //    // Le sujet
            //    selectedCourse.Subject = txtCourseSubject.Text;

            //    // Le prof
            //    selectedCourse.Teacher = new TeacherServices(svc).LoadTeacher(int.Parse(ddlTeachers.SelectedValue));

            //    // Les élèves
            //    List<int> selectedStudents = new List<int>();
            //    foreach (GridViewRow row in gridStudents.Rows)
            //    {
            //        CheckBox chk = row.Cells[row.Cells.Count - 1].Controls[0] as CheckBox;
            //        if (chk != null && chk.Checked)
            //        {
            //            selectedStudents.Add((int)gridStudents.DataKeys[row.RowIndex]["StudentId"]);
            //        }
            //    }

            //    svc.UpdateStudents(selectedCourse, selectedStudents);

            //    svc.Save();
            //}
        }
    }
}