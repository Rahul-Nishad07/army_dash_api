using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_edit_soldier
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Army_edit_soldier(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Your update query
                var query = @"UPDATE pc_student.Army_soldiers SET username = @username,email = @email, phone = @phone, password = @password, image = @image ,dob = @dob, rank = @rank,address = @address, unit = @unit ,degree =@degree WHERE email = @email";

               
                // Your parameters
                MySqlParameter[] myParam = new MySqlParameter[]
                {
           
                    new MySqlParameter("@username",rData.addInfo["username"]),
                 new MySqlParameter("@email",rData.addInfo["email"]),
                 new MySqlParameter("@phone",rData.addInfo["phone"]),
                 new MySqlParameter("@password",rData.addInfo["password"]),
                   new MySqlParameter("@image",rData.addInfo["image"]),
                 new MySqlParameter("@dob",rData.addInfo["dob"]),
                 new MySqlParameter("@rank",rData.addInfo["rank"]),
                 new MySqlParameter("@address",rData.addInfo["address"]),
                 new MySqlParameter("@unit",rData.addInfo["unit"]),
                 new MySqlParameter("@degree",rData.addInfo["degree"])
           
                };
 
                // Condition for execute the update query
                
                bool shouldExecuteUpdate = true;
                    

                if (shouldExecuteUpdate)
                {
                    int rowsAffected = ds.ExecuteUpdateSQL(query, myParam);

                    if (rowsAffected > 0)
                    {
                        resData.rData["rMessage"] = "update Successfully";
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