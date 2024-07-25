using System;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class getall_army_feedback
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Getall_army_feedback(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"select * from pc_student.Army_Feedback";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                     
                };
                var insertResult = ds.executeSQL(insertQuery, insertParams);

                List<List<object>> allclass = new List<List<object>>();
                if(insertResult != null & insertResult.Count>0){
                     foreach(var row in insertResult){
                         List<object> rowData = new List<object>();
                         foreach (var item in row)
                         {
                            rowData.Add(item);
                         }
                         allclass.Add(rowData);
                    }
                resData.rData["rMessage"] = allclass;
                }

                else{
                    resData.rData["rMessage"]="No Feedback....";
                }    
            
            }
               catch (Exception ex)
            {
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
               
            }

            return resData;
        }
    }
}

