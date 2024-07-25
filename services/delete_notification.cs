


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class delete_notification
    {
        dbServices ds = new dbServices();
public async Task<responseData> Delete_notification(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"
                    DELETE FROM pc_student.Army_notification 
                    WHERE id = @id;
                ";

                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@id", rData.addInfo["id"])
                };

                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > dbData[0].Count() - 1)
                {
                    resData.rData["rMessage"] = "Deleted successfully!";
                }
                else
                {
                    resData.rData["rMessage"] = "Delete failed..";
                }
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "Delete Notification Failed: " + ex.Message;
            }
            return resData;
        }
    }
}