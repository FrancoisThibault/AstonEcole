using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AstonEcole.Web.Infrastructure;
using AstonEcole.DTO;

namespace AstonEcole.Web
{
    public partial class Students : AstonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewStudents_PreRender(object sender, EventArgs e)
        {


            List<Student> ListStudents =  astonApiClient.GetStudents();
            var listeStudents = ListStudents.ToList()
               .Select(eleve => new { Id = eleve.Id, NomStudent = eleve.FirstName,
                   NbCours = (astonApiClient.GetStudent(eleve.Id)).Courses.Count() });

            GridViewStudents.DataSource = listeStudents;
            GridViewStudents.DataBind();

        }

    }
}