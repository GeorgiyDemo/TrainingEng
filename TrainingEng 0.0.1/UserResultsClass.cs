using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingEng_0._0._1
{
    class UserResultsClass
    {
        int classId;
        int topicId;
        int points;
        String username;
        String time;
        public UserResultsClass(String classId, String topicId, String points, String username, String time)
        {
            this.classId = Int32.Parse(classId);
            this.topicId = Int32.Parse(topicId);
            this.points = Int32.Parse(points);
            this.username = username;
            this.time = time;

        }

        //TODO
        public override string ToString()
        {
            return "";
        }
    }
}
