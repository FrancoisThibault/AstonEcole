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
    public partial class TeachersJQ : AstonPage
    {
        private AstonApiClientTeacher _ClientTeacher;
        private AstonApiClientCourse _ClientCourse;

        protected void Page_Load(object sender, EventArgs e)
        {
            _ClientTeacher = GetApiClient<AstonApiClientTeacher>();
            _ClientCourse = GetApiClient<AstonApiClientCourse>();
        }

        protected override void OnPreRender(EventArgs e)
        {
            var teachers = _ClientTeacher.getTeachers();

            gridTeachers.DataSource = teachers.Select(t => new { TeacherId = t.Id, TeacherName = t.Name }); ;
            gridTeachers.DataBind();

            base.OnPreRender(e);
        }
    }
}