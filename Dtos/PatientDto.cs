using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab_medicine_api.Models;

namespace lab_medicine_api.Dtos;

public class PatientDto : PersonDto
{
    [Required]
    [MinLength(11, ErrorMessage = "Contato de emergência deve conter pelo menos 11 caracteres.")]
    public string EmergencyContact { get; set; }

    public List<string>? Allergies { get; set; }

    public List<string>? SpecificCares { get; set; }
    public string? Insurance { get; set; }

    [Column("ATTENDANCE_STATUS"), Required]
    public AttendanceStatus AttendanceStatus { get; set; }

    [Required] public int AppointmentCount { get; set; }
    
    public ICollection<AppointmentModel> Appointments { get; set; }
}

public class PatchPatientDto
{
    [Required(ErrorMessage = "Status do atendimento é necessário.")]
    public AttendanceStatus AttendanceStatus { get; set; }
}

public class UpdatePatientDto : PersonDto
{
    [Required]
    [MinLength(11, ErrorMessage = "Contato de emergência deve conter pelo menos 11 caracteres.")]
    public string EmergencyContact { get; set; }

    public List<string>? Allergies { get; set; }

    public List<string>? SpecificCares { get; set; }
    public string? Insurance { get; set; }
}

public class PostPatientDto : PersonDto
{
    [Required]
    [MinLength(11, ErrorMessage = "Contato de emergência deve conter pelo menos 11 caracteres.")]
    public string EmergencyContact { get; set; }

    public List<string>? Allergies { get; set; }

    public List<string>? SpecificCares { get; set; }
    public string? Insurance { get; set; }

    [Column("ATTENDANCE_STATUS"), Required]
    public AttendanceStatus AttendanceStatus { get; set; }
}