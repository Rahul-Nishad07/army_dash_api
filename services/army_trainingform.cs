using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_trainingform
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Army_trainingform(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Army_programs(programname1,image,objective,topic,duration) values(@programname1,@image,@objective,@topic,@duration)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                    new MySqlParameter("@programname1", rData.addInfo["programname1"]),
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@objective", rData.addInfo["objective"]),
                    new MySqlParameter("@topic", rData.addInfo["topic"]),
                    new MySqlParameter("@duration", rData.addInfo["duration"]),
                  
 
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Training Classes added SuccessFully";
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
               
            }

            return resData;
        }
    }
}