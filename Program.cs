
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using COMMON_PROJECT_STRUCTURE_API.services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;

WebHost.CreateDefaultBuilder().
ConfigureServices(s =>
{
    IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
     s.AddSingleton<army_soldier>();
     s.AddSingleton<AdminLoginService>();
     s.AddSingleton<army_soldierlogin>();
     s.AddSingleton<army_missionform>();
       s.AddSingleton<getall_army_mission>();
        s.AddSingleton<delete_army_mission>();
         s.AddSingleton<army_trainingform>();
          s.AddSingleton<getall_army_training>();
          s.AddSingleton<army_assignmentform>();
           s.AddSingleton<getall_army_assignment>();
           s.AddSingleton<army_notifications>();
            s.AddSingleton<getall_army_notifications>();
            s.AddSingleton<army_medicalappointment>();
             s.AddSingleton<getall_army_medicalAppointments>();
             s.AddSingleton<army_feedback>();
             s.AddSingleton<getall_army_feedback>();
             s.AddSingleton<getall_army_soldier>();
              s.AddSingleton<getall_solidierbyemail>();
              s.AddSingleton<army_edit_soldier>();
              s.AddSingleton<generate>();
               s.AddSingleton<verify>();
                s.AddSingleton<updatepasswordarmy>();
               
                 s.AddSingleton<get_all_assignstatus>();
                  s.AddSingleton<asisignmentStatus>();

                   s.AddSingleton<get_all_missionstatus>();
                   s.AddSingleton<army_missionstatus>();
                     s.AddSingleton<delete_soldierlist>();
                       s.AddSingleton<delete_missionlist>();
                        s.AddSingleton<delete_assignmentlist>();
                         s.AddSingleton<delete_notification>();

                          s.AddSingleton<delete_medicalappointment>();
                
                 

             


    _ = s.AddAuthorization();
    _ = s.AddControllers();
    _ = s.AddCors();
    _ = s.AddAuthentication("SourceJWT").AddScheme<SourceJwtAuthenticationSchemeOptions, SourceJwtAuthenticationHandler>("SourceJWT", options =>
        {
            options.SecretKey = appsettings["jwt_config:Key"].ToString();
            options.ValidIssuer = appsettings["jwt_config:Issuer"].ToString();
            options.ValidAudience = appsettings["jwt_config:Audience"].ToString();
            options.Subject = appsettings["jwt_config:Subject"].ToString();
        });
}).Configure(app =>
{
    _ = app.UseAuthentication();
    _ = app.UseCors(options =>
            options.WithOrigins("http://localhost:5164", "http://localhost:3000")
            .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
    _ = app.UseRouting();
    _ = app.UseStaticFiles();

    _ = app.UseEndpoints(e =>
    {
          var adminLoginService = e.ServiceProvider.GetRequiredService<AdminLoginService>();
         var army_soldier = e.ServiceProvider.GetRequiredService<army_soldier>();
         var army_soldierlogin = e.ServiceProvider.GetRequiredService<army_soldierlogin>();
          var army_missionform = e.ServiceProvider.GetRequiredService<army_missionform>();
          var getall_army_mission = e.ServiceProvider.GetRequiredService<getall_army_mission>();
          var delete_army_mission = e.ServiceProvider.GetRequiredService<delete_army_mission>();
           var army_trainingform = e.ServiceProvider.GetRequiredService<army_trainingform>();
            var getall_army_training = e.ServiceProvider.GetRequiredService<getall_army_training>();
            var army_assignmentform = e.ServiceProvider.GetRequiredService<army_assignmentform>();
            var getall_army_assignment = e.ServiceProvider.GetRequiredService<getall_army_assignment>();
             var army_notifications = e.ServiceProvider.GetRequiredService<army_notifications>();
             var getall_army_notifications = e.ServiceProvider.GetRequiredService<getall_army_notifications>();
              var army_medicalappointment = e.ServiceProvider.GetRequiredService<army_medicalappointment>();
              var getall_army_medicalAppointments = e.ServiceProvider.GetRequiredService<getall_army_medicalAppointments>();
               var army_feedback = e.ServiceProvider.GetRequiredService<army_feedback>();
                var getall_army_feedback = e.ServiceProvider.GetRequiredService<getall_army_feedback>();
                 var getall_army_soldier = e.ServiceProvider.GetRequiredService<getall_army_soldier>();
                  var getall_solidierbyemail = e.ServiceProvider.GetRequiredService<getall_solidierbyemail>();
                 var army_edit_soldier = e.ServiceProvider.GetRequiredService<army_edit_soldier>();
                 var generate = e.ServiceProvider.GetRequiredService<generate>();
                  var verify = e.ServiceProvider.GetRequiredService<verify>();
                  var army_missionstatus = e.ServiceProvider.GetRequiredService<army_missionstatus>();
                   var updatepasswordarmy = e.ServiceProvider.GetRequiredService<updatepasswordarmy>();
                  
                     var get_all_assignstatus = e.ServiceProvider.GetRequiredService<get_all_assignstatus>();
                      var countStatuses = e.ServiceProvider.GetRequiredService<get_all_assignstatus>();
                      var asisignmentStatus = e.ServiceProvider.GetRequiredService<asisignmentStatus>();


                        var get_all_missionstatus = e.ServiceProvider.GetRequiredService<get_all_missionstatus>();
                          var countStatusesmission = e.ServiceProvider.GetRequiredService<get_all_missionstatus>();
                          var delete_soldierlist = e.ServiceProvider.GetRequiredService<delete_soldierlist>();
                          var delete_missionlist = e.ServiceProvider.GetRequiredService<delete_missionlist>();
                          var delete_assignmentlist = e.ServiceProvider.GetRequiredService<delete_assignmentlist>();
                           var delete_notification = e.ServiceProvider.GetRequiredService<delete_notification>();
                            var delete_medicalappointment = e.ServiceProvider.GetRequiredService<delete_medicalappointment>();
                          

       
 e.MapPost("army_soldier",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_soldier.Army_soldier(rData));
 });


  e.MapPost("army_soldierlogin",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_soldierlogin.Army_soldierlogin(rData));
 });

 
  e.MapPost("army_missionform",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_missionform.Army_missionform(rData));
 });

 

  e.MapPost("getall_army_mission",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getall_army_mission.Getall_army_mission(rData));
 });



  e.MapPost("delete_army_mission",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(delete_army_mission.Delete_army_mission(rData));
 });



 e.MapPost("army_trainingform",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_trainingform.Army_trainingform(rData));
 });


  e.MapPost("getall_army_training",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getall_army_training.Getall_army_training(rData));
 });


e.MapPost("army_assignmentform",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_assignmentform.Army_assignmentform(rData));
 });

 
e.MapPost("getall_army_assignment",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getall_army_assignment.Getall_army_assignment(rData));
 });


e.MapPost("army_notifications",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_notifications.Army_notifications(rData));
 });



e.MapPost("getall_army_notifications",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getall_army_notifications.Getall_army_notifications(rData));
 });


 
e.MapPost("army_medicalappointment",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_medicalappointment.Army_medicalappointment(rData));
 });



  
e.MapPost("getall_army_medicalAppointments",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getall_army_medicalAppointments.Getall_army_medicalAppointments(rData));
 });



 e.MapPost("army_feedback",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_feedback.Army_feedback(rData));
 });
 

 
 e.MapPost("getall_army_feedback",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getall_army_feedback.Getall_army_feedback(rData));
 });
 

  e.MapPost("getall_army_soldier",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getall_army_soldier.Getall_army_soldier(rData));
 });




   e.MapPost("getall_solidierbyemail",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(getall_solidierbyemail.Getall_solidierbyemail(rData));
 });


  e.MapPost("army_edit_soldier",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(army_edit_soldier.Army_edit_soldier(rData));
 });

 e.MapPost("generate",
                 [AllowAnonymous] async (HttpContext http) =>
 {
   var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
   requestData rData = JsonSerializer.Deserialize<requestData>(body);
   if (rData.eventID == "1001") // update
     await http.Response.WriteAsJsonAsync(generate.Generate(rData));
 });



  e.MapPost("verify",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(verify.VerifyOTP(rData));
});


e.MapPost("updatepasswordarmy",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(updatepasswordarmy.Updatepasswordarmy(rData));
});



e.MapPost("army_missionstatus",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(army_missionstatus.Army_missionstatus(rData));
});




e.MapPost("get_all_missionstatus",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(get_all_missionstatus.Get_all_missionstatus(rData));
});
 

 
e.MapPost("countStatusesmission",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(get_all_missionstatus.CountStatusesmission(rData));
});
 



 e.MapPost("get_all_assignstatus",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(get_all_assignstatus.Get_all_assignstatus(rData));
});


e.MapPost("countStatuses",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(get_all_assignstatus.CountStatuses(rData));
});


e.MapPost("asisignmentStatus",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(asisignmentStatus.AsisignmentStatus(rData));
});



e.MapPost("delete_soldierlist",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_soldierlist.Delete_soldierlist(rData));
});

e.MapPost("delete_missionlist",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_missionlist.Delete_missionlist(rData));
});



e.MapPost("delete_assignmentlist",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_assignmentlist.Delete_assignmentlist(rData));
});

e.MapPost("delete_notification",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_notification.Delete_notification(rData));
});


e.MapPost("delete_medicalappointment",
[AllowAnonymous] async (HttpContext http) =>
{
var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
requestData rData = JsonSerializer.Deserialize<requestData>(body);
if (rData.eventID == "1001") // update
await http.Response.WriteAsJsonAsync(delete_medicalappointment.Delete_medicalappointment(rData));
});




 
 e.MapPost("admin/login",
         async context =>
         {
           try
           {
             var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
             var loginRequest = JsonSerializer.Deserialize<LoginRequest>(body);
             var token = await adminLoginService.Authenticate(loginRequest.Username, loginRequest.Password);

             if (token == null)
             {
               context.Response.StatusCode = StatusCodes.Status401Unauthorized;
               await context.Response.WriteAsync("Invalid credentials.");
               return;
             }

             await context.Response.WriteAsJsonAsync(new { token });
           }
           catch (Exception ex)
           {
             context.Response.StatusCode = StatusCodes.Status500InternalServerError;
             await context.Response.WriteAsync($"An error occurred: {ex.Message}");
           }
         });


    e.MapPost("admin/logout",
         async context =>
         {
           await context.Response.WriteAsync("Logged out successfully.");
         });

    IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    e.MapGet("/dbstring",
     async c =>
     {
       dbServices dspoly = new();
       await c.Response.WriteAsJsonAsync("{'mongoDatabase':" + appsettings["mongodb:connStr"] + "," + " " + "MYSQLDatabase" + " =>" + appsettings["db:connStrPrimary"]);
     });






        _ = e.MapGet("/bing",
          async c => await c.Response.WriteAsJsonAsync("{'Name':'Anish','Age':'26','Project':'COMMON_PROJECT_STRUCTURE_API'}"));
    });
}).Build().Run();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
public record requestData
{
    internal int userId;

    [Required]
  public string eventID { get; set; }
  [Required]
  public IDictionary<string, object> addInfo { get; set; }
    public object AddInfo { get; internal set; }

}

public record responseData
{
  public responseData()
  {
    eventID = "";
    rStatus = 0;
    rData = new Dictionary<string, object>();
  }
  [Required]
  public int rStatus { get; set; } = 0;
  public string eventID { get; set; }
  public IDictionary<string, object> addInfo { get; set; }
  public IDictionary<string, object> rData { get; set; }
    public List<List<object[]>> CountingResult { get; internal set; }

}

public class LoginRequest
{
  public string Username { get; set; }
  public string Password { get; set; }
  // Other properties related to login request
}