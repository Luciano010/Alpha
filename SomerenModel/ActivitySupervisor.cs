using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class ActivitySupervisor
    {
        public int ActivityId { get; set; }
        public int TeacherId { get; set; }
        public Activity Activity { get; set; }
        public Teacher Teacher { get; set; }

        public ActivitySupervisor(int activityId, int teacherId)
        {
            ActivityId = activityId;
            TeacherId = teacherId;
        }


    }
}
