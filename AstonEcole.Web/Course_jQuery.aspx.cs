using AstonEcole.ApiClient;
using AstonEcole.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AstonEcole.Web
{
    public partial class Course_jQuery : AstonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
    }
}