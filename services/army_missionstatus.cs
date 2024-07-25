using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_missionstatus
    {
        dbServices ds = new dbServices(); // Assuming this manages database connection

        public async Task<responseData> Army_missionstatus(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                string status = rData.addInfo["status"].ToString();
                string id = rData.addInfo["id"].ToString();
            
                string query = "";
                MySqlParameter[] parameters = null;

                switch (status)
                {
                    case "Accept":
                        query = @"UPDATE pc_student.Army_mission SET status = 'Accepted' WHERE id = @id";
                        break;
                    case "Reject":
                        query = @"UPDATE pc_student.Army_mission SET status = 'Rejected' WHERE id = @id";
                        break;
                    case "Submit":
                        query = @"UPDATE pc_student.Army_mission SET status = 'Submitted' WHERE id = @id";
                        break;
                    default:
                        resData.rData["rMessage"] = "Invalid status: " + status;
                        return resData;
                }

                parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@id", id)
                };

                // Execute SQL query asynchronously
                 ds.executeSQL(query, parameters); // Assuming executeSQLAsync is asynchronous

                resData.rData["rMessage"] = "Mission " + status + " successfully";
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
                // Log the exception with stack trace for detailed debugging
                Console.WriteLine(ex.ToString());
            }

            return resData;
        }
    }
}
