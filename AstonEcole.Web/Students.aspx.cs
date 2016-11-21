using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AstonEcole.Web.Infrastructure;
using AstonEcole.DTO;
 
using AstonEcole.ApiClient;

namespace AstonEcole.Web
{
    public partial class Students : AstonPage
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

        protected void GridViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idStudent = (int)GridViewStudents.SelectedValue;

            Student SelectedStudent = GetApiClient<AstonApiClientStudent>().GetStudent(idStudent);

            this.TextBoxNomEleve.Text = SelectedStudent.FirstName;

            var query = GetApiClient<AstonApiClientCourse>().GetCourses().Select(cours => new { Id = cours.Id, Subject = cours.Subject,
                Assiste = SelectedStudent.Courses.Any(c => c.Id == cours.Id) });


            GridViewListeCours.DataSource = query.ToList();
            GridViewListeCours.DataBind();
        }

        // rendre les checkbox éditables
        protected void GridViewListeCours_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // si c'est une ligne de données et pas en-tête 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Cell[2] la troisième cellule contient un seul contrôle le checkbox => le rendre éditable   
                ((CheckBox)e.Row.Cells[2].Controls[0]).Enabled = true;
            }
        }

        protected void ButtonValider_Click(object sender, EventArgs e)
        {

            int idStudent = (int)GridViewStudents.SelectedValue;

            // récupération de la liste des cours sélectionnés
            List<int> listIdCoursSelectionnes = new List<int>();

            foreach (GridViewRow row in GridViewListeCours.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (((CheckBox)row.Cells[2].Controls[0]).Checked)
                    {
                        int idCours = (int)GridViewListeCours.DataKeys[row.RowIndex][0];
                        listIdCoursSelectionnes.Add(idCours);
                    }

                }
            }

            //mettre a jour les cours de l'étudiant sélectionné
            Student SelectedStudent = GetApiClient<AstonApiClientStudent>().GetStudent(idStudent);

            List<Course> listAllCourses = GetApiClient<AstonApiClientCourse>().GetCourses();

            SelectedStudent.FirstName = TextBoxNomEleve.Text;

            SelectedStudent.Courses = listAllCourses.Where(c => listIdCoursSelectionnes.Contains(c.Id)).ToList();

            GetApiClient<AstonApiClientStudent>().UpdateStudent(SelectedStudent);

        }

    }
}