using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenService
{
    public class TeacherService
    {
        private TeacherDao teacherdb;

        public TeacherService()
        {
            teacherdb = new TeacherDao();
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = teacherdb.GetAllTeachers();
            return teachers;
        }

        public Teacher GetTeacherById(int id)
        {
            foreach (Teacher teacher in GetTeachers())
            {
                if (teacher.teacherId == id)
                {
                    return teacher;
                }
            }

            return null;
        }
    }
}
