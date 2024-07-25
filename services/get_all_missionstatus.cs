

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class get_all_missionstatus
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Get_all_missionstatus(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Select all statuses
                var selectQuery = @"SELECT status FROM pc_student.Army_mission";
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

        public async Task<responseData> CountStatusesmission(requestData rData)
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
                        pc_student.Army_mission
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


