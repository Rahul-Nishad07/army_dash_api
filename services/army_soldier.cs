using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_soldier
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Army_soldier(requestData rData)
        {
            responseData resData = new responseData();

            try
               
               {

                var query = @"SELECT * FROM pc_student.Army_soldiers where email=@email";
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
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Already Soldier registered";
                }

                else {

                var insertQuery = @"insert into pc_student.Army_soldiers(username,email,phone,password,image,dob,rank,address,unit,degree) values(@username,@email,@phone,@password,@image,@dob,@rank,@address,@unit,@degree)";
                MySqlParameter[] insertParams = new MySqlParameter[]
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

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Registration Successfulll";
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