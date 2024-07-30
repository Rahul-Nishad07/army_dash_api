using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_assignmentform
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Army_assignmentform(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Army_Assignment(taskname,image,description,personnel,duedate,status) values(@taskname,@image,@description,@personnel,@duedate,@status)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
              
                    new MySqlParameter("@taskname", rData.addInfo["taskname"]),
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@description", rData.addInfo["description"]),
                    new MySqlParameter("@personnel", rData.addInfo["personnel"]),
                    new MySqlParameter("@duedate", rData.addInfo["duedate"]),
                    new MySqlParameter("@status", rData.addInfo["status"])
                  
 
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Assignment added SuccessFully";
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
               
            }
            return resData;
        }
    }
}