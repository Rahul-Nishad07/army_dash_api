// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MySql.Data.MySqlClient;
// using System.Text.Json;
// using System.Net;
// using System.Net.Mail;

// namespace COMMON_PROJECT_STRUCTURE_API.services
// {
//    public class acceptButton
// {
//     public  dbServices ds = new dbServices();

//     public async Task<responseData> AcceptButton(requestData rData)
// {
//     responseData resData = new responseData();

//     try
//     {
//         string missionId = rData.addInfo["id"].ToString();
       

//         var updateMissionQuery = @"UPDATE pc_student.Missions SET status = 'Accepted', acceptedByUserId = @userId WHERE missionId = @missionId";

//         using (var connection = new MySqlConnection(connectionString))
//         {
//             await connection.OpenAsync();

//             using (var cmd = new MySqlCommand(updateMissionQuery, connection))
//             {
//                 cmd.Parameters.AddWithValue("@missionId", missionId);
//                 cmd.Parameters.AddWithValue("@userId", userId);

//                 int rowsAffected = await cmd.ExecuteNonQueryAsync();

//                 if (rowsAffected > 0)
//                 {
//                     responseData.rData["success"] = true;
//                     responseData.rData["message"] = "Mission accepted successfully.";
//                 }
//                 else
//                 {
//                     responseData.rData["message"] = "Failed to accept mission.";
//                 }
//             }
//         }
//     }
//     catch (Exception ex)
//     {
//         responseData.rData["message"] = "Exception occurred: " + ex.Message;
//         Console.WriteLine("Exception in AcceptMission: " + ex.Message);
//     }

//     return responseData;
// }

// }
// }