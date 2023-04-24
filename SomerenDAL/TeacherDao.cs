using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;


namespace SomerenDAL
{
    public class TeacherDao : BaseDao
    {
        public List<Teacher> GetAllTeachers()
        {
            string query = "SELECT * FROM [Teacher]";
            //string query = "SELECT * FROM [Teacher]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    teacherId = (int)dr["TeacherId"],
                    firstName = dr["firstName"].ToString(),
                    lastName = dr["lastName"].ToString(),
                    phoneNumber = (int)dr["phoneNumber"],
                    Role = dr["Role"].ToString(),
                    Age = (int)dr["Age"]
                };
                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
