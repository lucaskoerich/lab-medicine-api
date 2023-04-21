using lab_medicine_api.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace lab_medicine_api.Models;

public class LabMedicineContext : DbContext
{
    public LabMedicineContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<PatientModel> Patients { get; set; }
    public DbSet<DoctorModel> Doctors { get; set; }
    public DbSet<NurseModel> Nurses { get; set; }
    public DbSet<AppointmentModel> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientModel>().HasIndex(p => p.CPF).IsUnique();
        modelBuilder.Entity<DoctorModel>().HasIndex(p => p.CPF).IsUnique();
        modelBuilder.Entity<NurseModel>().HasIndex(p => p.CPF).IsUnique();

        modelBuilder.Entity<AppointmentModel>()
            .HasOne<PatientModel>(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientModelId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AppointmentModel>()
            .HasOne<DoctorModel>(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorModelId)
            .OnDelete(DeleteBehavior.NoAction);

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


        modelBuilder.Entity<PatientModel>().HasData(
            new PatientSeeder().Seed().ToArray()
        );

        modelBuilder.Entity<DoctorModel>().HasData(
            new DoctorSeeder().Seed().ToArray()
        );
        modelBuilder.Entity<AppointmentModel>().HasData(
            new AppointmentSeeder().Seed().ToArray()
        );

        modelBuilder.Entity<NurseModel>().HasData(
            new NurseSeeder().Seed().ToArray()
        );
    }
}