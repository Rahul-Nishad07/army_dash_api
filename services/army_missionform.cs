using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_missionform
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Army_missionform(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Army_mission(missionname,image1,desc1,image2,desc2,status) values(@missionname,@image1,@desc1,@image2,@desc2,@status)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                    new MySqlParameter("@missionname", rData.addInfo["missionname"]),
                    new MySqlParameter("@image1", rData.addInfo["image1"]),
                    new MySqlParameter("@desc1", rData.addInfo["desc1"]),
                    new MySqlParameter("@image2", rData.addInfo["image2"]),
                    new MySqlParameter("@desc2", rData.addInfo["desc2"]),
                    new MySqlParameter("@status", rData.addInfo["status"])
                  
 
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Mission added SuccessFully";
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


