using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_notifications
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Army_notifications(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Army_notification(subject,message,status,date) values(@subject,@message,@status,@date)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                    new MySqlParameter("@subject", rData.addInfo["subject"]),
                    new MySqlParameter("@message", rData.addInfo["message"]),
                    new MySqlParameter("@status", rData.addInfo["status"]),
                    new MySqlParameter("@date", rData.addInfo["date"])
 
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Notification send SuccessFully";
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
                // Log the exception as needed
            }

            return resData;
        }
    }
}