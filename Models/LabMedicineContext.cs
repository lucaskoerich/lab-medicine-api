using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace lab_medicine_api.Models;

public class LabMedicineContext : DbContext
{
    public LabMedicineContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PersonModel> Persons { get; set; }
    public DbSet<PatientModel> Patients { get; set; }
    public DbSet<DoctorModel> Doctors { get; set; }
    public DbSet<NurseModel> Nurses { get; set; }
    public DbSet<AppointmentModel> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientModel>()
            .Property(x => x.Allergies)
            .HasConversion(new ValueConverter<List<string>, string>(
                v => JsonConvert.SerializeObject(v), // convert to string for persistence
                v => JsonConvert.DeserializeObject<List<string>>(v))); // convert to List<String> for use
        
        modelBuilder.Entity<PatientModel>()
            .Property(x => x.SpecificCares)
            .HasConversion(new ValueConverter<List<string>, string>(
                v => JsonConvert.SerializeObject(v), // convert to string for persistence
                v => JsonConvert.DeserializeObject<List<string>>(v))); // convert to List<String> for use
    }
}