using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_feedback
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Army_feedback(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Army_Feedback(title,message) values(@title,@message)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                    new MySqlParameter("@title", rData.addInfo["title"]),
                    new MySqlParameter("@message", rData.addInfo["message"]),
                   
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Feedback Added SuccessFully";
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
               
            }
            return resData;
        }
    }
}