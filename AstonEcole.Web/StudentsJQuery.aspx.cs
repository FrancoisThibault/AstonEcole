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
    public partial class StudentsJQuery :AstonPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewStudents_PreRender(object sender, EventArgs e)
        {
            // List<Student> ListStudents = GetApiClient<AstonApiClientStudent>().GetStudents();

            List<StudentNbCours> ListStudents = GetApiClient<AstonApiClientStudent>().GetStudentsWithNbCours();

            var listeStudents = ListStudents.ToList() 
               .Select(eleve => new
               {
                   Id = eleve.theStudent.Id,
                   NomStudent = eleve.theStudent.FirstName,
                   NbCours = eleve.NbCours
               });

            GridViewStudents.DataSource = listeStudents;
            GridViewStudents.DataBind();
        }
    }
}