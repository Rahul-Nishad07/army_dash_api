using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class edit_mission
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Edit_mission(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"UPDATE pc_student.Army_mission SET missionname = @missionname, image1 = @image1, image2 = @image2, desc1 = @desc1, desc2 = @desc2 ,status = @status WHERE id = @id";

                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@id", rData.addInfo["id"]),   
                    new MySqlParameter("@missionname", rData.addInfo["missionname"]),
                    new MySqlParameter("@image1", rData.addInfo["image1"]),
                    new MySqlParameter("@image2", rData.addInfo["image2"]),
                    new MySqlParameter("@desc1", rData.addInfo["desc1"]),
                    new MySqlParameter("@desc2", rData.addInfo["desc2"]),
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