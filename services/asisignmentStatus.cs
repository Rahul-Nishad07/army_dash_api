using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class asisignmentStatus
    {
        dbServices ds = new dbServices(); // Assuming this manages database connection

        public async Task<responseData> AsisignmentStatus(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                string status = rData.addInfo["status"].ToString();
                string id = rData.addInfo["id"].ToString();
                
                // Update mission status query
                string updateQuery = "";
                MySqlParameter[] parameters = null;

                switch (status)
                {
                    case "Accept":
                        updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Accepted' WHERE id = @id";
                        break;
                    case "Reject":
                        updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Rejected' WHERE id = @id";
                        break;
                    case "Submit":
                        updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Submitted' WHERE id = @id";
                        break;
                    default:
                        resData.rData["rMessage"] = "Invalid status: " + status;
                        return resData;
                }

                parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@id", id)
                };

                // Execute update SQL query asynchronously
             ds.executeSQL(updateQuery, parameters);

                resData.rData["rMessage"] = "Mission " + status + " successfully";

                // Counting query
                string countQuery = @"
                    SELECT
                        status,
                        COUNT(*) AS count
                    FROM
                        pc_student.Army_Assignment
                    GROUP BY
                        status";

             
                var countingResult =  ds.executeSQL(countQuery, null);

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

// using System;
// using System.Threading.Tasks;
// using MySql.Data.MySqlClient;

// namespace COMMON_PROJECT_STRUCTURE_API.services
// {
//     public class asisignmentStatus
//     {
//         dbServices ds = new dbServices(); 


//         public async Task<responseData> AsisignmentStatus(requestData rData)
//         {
//             responseData resData = new responseData();
//     try
//     {
//         string status = rData.addInfo["status"].ToString();
//         string id = rData.addInfo["id"].ToString();

//         // Update mission status query
//         string updateQuery = "";
//         MySqlParameter[] parameters = null;

//         switch (status)
//         {
//             case "Accept":
//                 updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Accepted' WHERE id = @id";
//                 break;
//             case "Reject":
//                 updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Rejected' WHERE id = @id";
//                 break;
//             case "Submit":
//                 updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Submitted' WHERE id = @id";
//                 break;
//             default:
//                 resData.rData["rMessage"] = "Invalid status: " + status;
//                 return resData;
//         }

//         parameters = new MySqlParameter[]
//         {
//             new MySqlParameter("@id", rData.addInfo["id"]) 
//         };

//         // Execute update SQL query asynchronously
//       ds.executeSQL(updateQuery, parameters);

//         resData.rData["rMessage"] = "Mission " + status + " successfully";

//         // Counting query with INNER JOIN
//         string countQuery = @"
//             SELECT
//                 a.status,
//                 COUNT(*) AS count
//             FROM
//                 pc_student.Army_Assignment a
//             INNER JOIN
//                 pc_student.Army_soldiers s ON a.id = s.id
//             GROUP BY
//                 a.status";

//         // Execute counting query asynchronously and get the result
//         var countingResult =  ds.executeSQL(countQuery, null);

//         resData.CountingResult = countingResult;
//     }
//     catch (Exception ex)
//     {
//         resData.rData["rMessage"] = "An error occurred: " + ex.Message;
//         // Log the exception with stack trace for detailed debugging
//         Console.WriteLine(ex.ToString());
//     }

//     return resData;
// }
//     }
// }