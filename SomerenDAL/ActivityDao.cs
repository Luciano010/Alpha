using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class ActivityDao : BaseDao
    {
        public List<Activity> GetAllActivities()
        {
            string query = "SELECT * FROM [Activity]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    ActivityId = (int)dr["activityId"],
                    ActivitiyName = dr["activityName"].ToString(),
                    StartTime = (DateTime)dr["startTime"],
                    FinishTime = (DateTime)dr["finishTime"]
                };
                activities.Add(activity);
            }
            return activities;
        }
        public List<ActivitySupervisor> GetAllActivitiesSupervisors()
        {
            string query = "SELECT * FROM [ActivitySupervisor]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadActivitySupervisorTable(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<ActivitySupervisor> ReadActivitySupervisorTable(DataTable dataTable)
        {
            List<ActivitySupervisor> activitiesSupervisors = new List<ActivitySupervisor>();

            foreach (DataRow dr in dataTable.Rows)
            {
                activitiesSupervisors.Add(new ActivitySupervisor((int)dr["ActivityId"], (int)dr["LecturerId"]));
                
            }
            return activitiesSupervisors;
        }

        public void AddActivitySupervisor(ActivitySupervisor activitySupervisor)
        {
            string query = "INSERT INTO ActivitySupervisor (ActivityId, LecturerId) VALUES (@addActivityId, @addTeacherId)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@addActivityId", activitySupervisor.ActivityId);
            sqlParameters[1] = new SqlParameter("@addTeacherId", activitySupervisor.TeacherId);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void RemoveActivitySupervisor(ActivitySupervisor activitySupervisor)
        {
            string query = "DELETE FROM ActivitySupervisor WHERE ActivityId = @ActivityId AND LecturerId = @TeacherId";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ActivityId", activitySupervisor.ActivityId);
            sqlParameters[1] = new SqlParameter("@TeacherId", activitySupervisor.TeacherId);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
