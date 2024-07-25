using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class get_all_assignstatus
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Get_all_assignstatus(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Select all statuses
                var selectQuery = @"SELECT status FROM pc_student.Army_Assignment";
                MySqlParameter[] selectParams = new MySqlParameter[]
                {
                    // You can add parameters if needed
                };
                var selectResult = ds.executeSQL(selectQuery, selectParams);

                List<List<object>> allStatuses = new List<List<object>>();
                if (selectResult != null && selectResult.Count > 0)
                {
                    foreach (var row in selectResult)
                    {
                        List<object> rowData = new List<object>();
                        foreach (var item in row)
                        {
                            rowData.Add(item);
                        }
                        allStatuses.Add(rowData);
                    }
                    resData.rData["rMessage"] = allStatuses;
                }
                else
                {
                    resData.rData["rMessage"] = "No Status";
                }
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
                // Log the exception as needed
            }

            return resData;
        }

        public async Task<responseData> CountStatuses(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Count statuses
                var countQuery = @"
                    SELECT 
                        status,
                        COUNT(*) AS count
                    FROM 
                        pc_student.Army_Assignment
                    GROUP BY 
                        status";
                MySqlParameter[] countParams = new MySqlParameter[]
                {
                    // You can add parameters if needed
                };
                var countResult = ds.executeSQL(countQuery, countParams);

                List<object> statusCounts = new List<object>();
                if (countResult != null && countResult.Count > 0)
                {
                    foreach (var row in countResult)
                    {
                        statusCounts.Add(new
                        {
                            Status = row[0],
                            Count = row[1]
                        });
                    }
                    resData.rData["rMessage"] = statusCounts;
                }
                else
                {
                    resData.rData["rMessage"] = "No Status Counts";
                }
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


// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using MySql.Data.MySqlClient;

// namespace COMMON_PROJECT_STRUCTURE_API.services
// {
//     public class get_all_assignstatus
//     {
//         dbServices ds = new dbServices(); // Assuming this manages database connection

//         public async Task<ResponseData> AssignmentStatus(RequestData rData)
//         {
//             var resData = new ResponseData();

//             try
//             {
//                 string status = rData.AddInfo["status"].ToString();
//                 string id = rData.AddInfo["id"].ToString();

//                 // Update mission status query
//                 string updateQuery = "";
//                 MySqlParameter[] parameters = null;

//                 switch (status)
//                 {
//                     case "Accept":
//                         updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Accepted' WHERE id = @id";
//                         break;
//                     case "Reject":
//                         updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Rejected' WHERE id = @id";
//                         break;
//                     case "Submit":
//                         updateQuery = @"UPDATE pc_student.Army_Assignment SET status = 'Submitted' WHERE id = @id";
//                         break;
//                     default:
//                         resData.RData["rMessage"] = "Invalid status: " + status;
//                         return resData;
//                 }

//                 parameters = new MySqlParameter[]
//                 {
//                     new MySqlParameter("@id", MySqlDbType.Int32) { Value = Convert.ToInt32(id) }
//                 };

//                 // Execute update SQL query asynchronously
//                 object value =  ds.executeSQL(updateQuery, parameters);

//                 resData.RData["rMessage"] = "Mission " + status + " successfully";

//                 // Counting query with INNER JOIN
//                 string countQuery = @"
//                     SELECT
//                         a.status,
//                         COUNT(*) AS count
//                     FROM
//                         pc_student.Army_Assignment a
//                     INNER JOIN
//                         pc_student.Soldiers s ON a.userId = s.Id
//                     GROUP BY
//                         a.status";

//                 // Execute counting query asynchronously and get the result
//                 var countingResult =  ds.ExecuteSQLAsync<List<StatusCount>>(countQuery, null);

//                 resData.CountingResult = await countingResult;
//             }
//             catch (Exception ex)
//             {
//                 resData.RData["rMessage"] = "An error occurred: " + ex.Message;
//                 // Log the exception with stack trace for detailed debugging
//                 Console.WriteLine(ex.ToString());
//             }

//             return resData;
//         }
//     }

//     public class RequestData
//     {
//         public Dictionary<string, object> AddInfo { get; set; }
//     }

//     public class ResponseData
//     {
//         public Dictionary<string, string> RData { get; set; } = new Dictionary<string, string>();
//         public List<StatusCount> CountingResult { get; set; }
//     }

//     public class StatusCount
//     {
//         public string Status { get; set; }
//         public int Count { get; set; }
//     }


// }