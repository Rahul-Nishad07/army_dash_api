using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text.Json;
using System.Net;
using System.Net.Mail;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
   public class verify
{
    public  dbServices ds = new dbServices();
    public async Task<responseData> VerifyOTP(requestData rData)
		{
			responseData resData = new responseData();

			string connectionString = "server=210.210.210.50;user=test_user;password=test*123;port=2020;database=pc_student;";

			try
			{
				
				string otp = rData.addInfo["otp"].ToString();

				// Validate OTP
				var validateOTPQuery = @"SELECT COUNT(*) FROM pc_student.OTP_generate WHERE otp=@otp";
				using (var connection = new MySqlConnection(connectionString))
				{
					await connection.OpenAsync();

					using (var cmd = new MySqlCommand(validateOTPQuery, connection))
					{
						
						cmd.Parameters.AddWithValue("@otp", otp);

						object countObj = await cmd.ExecuteScalarAsync();

						if (countObj != null && countObj != DBNull.Value)
						{
							if (int.TryParse(countObj.ToString(), out int count) && count > 0)
							{
								// Delete used OTP from OTP4_USER table
								var deleteOTPQuery = @"DELETE FROM pc_student.OTP_generate WHERE otp=@otp";
								using (var deleteCmd = new MySqlCommand(deleteOTPQuery, connection))
								{
									
									deleteCmd.Parameters.AddWithValue("@otp", otp);
									await deleteCmd.ExecuteNonQueryAsync();
								}

								resData.rData["success"] = true;
								resData.rData["message"] = "OTP verified successfully.";
							}
							else
							{
								resData.rData["message"] = "Invalid OTP.";
							}
						}
						else
						{
							resData.rData["message"] = "Invalid OTP.";
						}
					}
				}
			}
			catch (Exception ex)
			{
				resData.rData["message"] = "Exception occurred: " + ex.Message;
				Console.WriteLine("Exception in VerifyOTP: " + ex.Message);
			}

			return resData;
		}

    }
}
