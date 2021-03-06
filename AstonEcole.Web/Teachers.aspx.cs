﻿using AstonEcole.ApiClient;
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
    public partial class Teachers : AstonPage
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

        protected void gridTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelectedTeacher = (int)gridTeachers.SelectedValue;
            Teacher selectedTeacher = _ClientTeacher.getTeacher(idSelectedTeacher);
            hidTeacherId.Value = selectedTeacher.Id.ToString();
            txtTeacherName.Text = selectedTeacher.Name;


            gridCourses.DataSource = _ClientCourse.GetCourses().Select(c => new { CourseId = c.Id, CourseName = c.Subject, IsSelected = c.Teacher?.Id == idSelectedTeacher });
            gridCourses.DataBind();
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
            
            {
                Teacher updatingTeacher = _ClientTeacher.getTeacher(idUpdatingTeacher);
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

                _ClientTeacher.UpdateTeacher(updatingTeacher, selectedCourses);
            }
        }
    }
}