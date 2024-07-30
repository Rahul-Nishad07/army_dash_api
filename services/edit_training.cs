using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class edit_training
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Edit_training(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"UPDATE pc_student.Army_programs SET programname1 = @programname1, image = @image, objective = @objective, topic = @topic, duration = @duration WHERE id = @id";

                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@id", rData.addInfo["id"]),   
                    new MySqlParameter("@programname1", rData.addInfo["programname1"]),
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@objective", rData.addInfo["objective"]),
                    new MySqlParameter("@topic", rData.addInfo["topic"]),
                    new MySqlParameter("@duration", rData.addInfo["duration"])
                    
                  
           
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