using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class delete_army_mission
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Delete_army_mission(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"DELETE FROM pc_student.Army_mission WHERE id = @id";
               
               
              // Check if id is present in rData.addInfo and is not null or empty
                bool shouldExecuteDelete = true;

                if (shouldExecuteDelete)
                {
                    // Your parameters
                    MySqlParameter[] myParam = new MySqlParameter[]
                    {
                    new MySqlParameter("@id", rData.addInfo["id"]) 
                    };

                // Assuming id is present in rData addInfo

                    int rowsAffected = ds.ExecuteDeleteSQL(query, myParam);

                    if (rowsAffected > 0)
                    {
                        resData.rData["rMessage"] = "delete Successfully";
                    }
                    else
                    {
                        resData.rData["rMessage"] = "No rows affected. Delete failed.";
                    }
                }
                else
                {
                    resData.rData["rMessage"] = "id not provided or is empty. Delete query not executed.";
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