using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class army_medicalappointment
    {
        dbServices ds = new dbServices();

        public async Task<responseData> Army_medicalappointment(requestData rData)
        {
            responseData resData = new responseData();

            try
            {
                // Insert new subscription
                var insertQuery = @"insert into pc_student.Army_medicalAppointment(purpose,name,dob,contact,email,height,weight,bloodPressure) values(@purpose,@name,@dob,@contact,@email,@height,@weight,@bloodPressure)";
                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                    new MySqlParameter("@purpose", rData.addInfo["purpose"]),
                    new MySqlParameter("@name", rData.addInfo["name"]),
                    new MySqlParameter("@dob", rData.addInfo["dob"]),
                    new MySqlParameter("@contact", rData.addInfo["contact"]),
                     new MySqlParameter("@email", rData.addInfo["email"]),
                    new MySqlParameter("@height", rData.addInfo["height"]),
                    new MySqlParameter("@weight", rData.addInfo["weight"]),
                    new MySqlParameter("@bloodPressure", rData.addInfo["bloodPressure"])
 
 
                };

                var insertResult = ds.executeSQL(insertQuery, insertParams);

                resData.rData["rMessage"] = "Your Appointment is Submitted Successfully....";
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