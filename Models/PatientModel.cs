using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using lab_medicine_api.Enums;
using lab_medicine_api.Validations;

namespace lab_medicine_api.Models;

[Table("PATIENTS")]
public class PatientModel : PersonModel
{
    [Column("EMERGENCY_CONTACT")]
    [Required(ErrorMessage = "Contato de emergência não pode ser vazio!")]
    [MinLength(11, ErrorMessage = "Contato de emergência deve conter pelo menos 11 caracteres.")]
    public string EmergencyContact { get; set; }

    [Column("ALLERGIES")] public List<string>? Allergies { get; set; } = new();

    [Column("SPECIFIC_CARE")] public List<string>? SpecificCares { get; set; } = new();
    [Column("INSURANCE")] public string? Insurance { get; set; }

    [Column("ATTENDANCE_STATUS")]
    [Required(ErrorMessage = "Status de Atedimento não pode ser vazio!")]
    [JsonConverter(typeof(CustomValidation.AttendanceStatusConverter))]
    public AttendanceStatus AttendanceStatus { get; set; }

    [Column("APPOINTMENT_COUNT"), Required]
    public int AppointmentCount { get; set; }

    [Column("APPOINTMENTS")] public ICollection<AppointmentModel> Appointments { get; set; } = new List<AppointmentModel>();
}