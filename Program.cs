using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProductDashboard;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MasterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MasterContext")));



//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:5118")
//                          .AllowAnyHeader()
//                                                  .AllowAnyMethod();
//                      });
//});
//builder.Services.AddControllers();
//builder.Services.AddCors(o => o.AddPolicy("MyAllowSpecificOrigins", builder =>
//{
//    builder.AllowAnyOrigin()
//           .AllowAnyMethod()
//           .AllowAnyHeader();
//}));

//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//  options.SerializerSettings.ContractResolver =
//        new CamelCasePropertyNamesContractResolver());

var app = builder.Build();

app.UseCors(c => c.WithOrigins(new string[] { "http://localhost:4200" })
    .AllowAnyMethod()
    .AllowCredentials()
    .AllowAnyHeader());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() == true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();
//app.UseCors(MyAllowSpecificOrigins);

app.Run();
