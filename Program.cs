using System.Text.Json.Serialization;
using lab_medicine_api.Models;
using lab_medicine_api.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

string connectionString = "Server=LUCAS\\SQLEXPRESS;Database=labmedicinebd;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<LabMedicineContext>(o => o.UseSqlServer(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LabMedicineContext>();
    var patientSeeder = new PatientSeeder(context);
    var doctorSeeder = new DoctorSeeder(context);
    var nurseSeeder = new NurseSeeder(context);
    
    patientSeeder.Seed(context);
    doctorSeeder.Seed(context);
    nurseSeeder.Seed(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();