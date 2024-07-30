using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class edit_assignment
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Edit_assignment(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"UPDATE pc_student.Army_Assignment SET taskname = @taskname, image = @image, description = @description, personnel = @personnel, duedate = @duedate ,status = @status WHERE id = @id";

                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@id", rData.addInfo["id"]),   
                    new MySqlParameter("@taskname", rData.addInfo["taskname"]),
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@description", rData.addInfo["description"]),
                    new MySqlParameter("@personnel", rData.addInfo["personnel"]),
                    new MySqlParameter("@duedate", rData.addInfo["duedate"]),
                    new MySqlParameter("@status", rData.addInfo["status"])
                  
           
                };
 
                // Condition for execute the update query
                
                bool shouldExecuteUpdate = true;
                    

                if (shouldExecuteUpdate)
                {
                    int rowsAffected = ds.ExecuteUpdateSQL(query, myParam);

                    if (rowsAffected > 0)
                    {
                        resData.rData["rMessage"] = "Update Successfully";
                    }
                    else
                    {
                        resData.rData["rMessage"] = "No rows affected. Update failed.";
                    }
                }
                else
                {
                    resData.rData["rMessage"] = "Condition not met. Update query not executed.";
                }
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "Exception occurred: " + ex.Message;
            }
            return resData;
        }

    }
}