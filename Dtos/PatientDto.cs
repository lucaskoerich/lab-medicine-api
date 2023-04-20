using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;
using lab_medicine_api.Validations;

namespace lab_medicine_api.Dtos;

public class PatientDto : GetPersonDto
{
    public string EmergencyContact { get; set; }
    public List<string>? Allergies { get; set; }
    public List<string>? SpecificCares { get; set; }
    public string? Insurance { get; set; }
    public AttendanceStatus AttendanceStatus { get; set; }
    public int AppointmentCount { get; set; }
    public ICollection<AppointmentModel> Appointments { get; set; }
}

public class PatchPatientDto
{
    [Required(ErrorMessage = "Status de Atendimento não pode ser vazio!")]
    [JsonConverter(typeof(CustomValidation.AttendanceStatusConverter))]
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
    
    [Required(ErrorMessage = "Status de Atendimento não pode ser vazio!")]
    [JsonConverter(typeof(CustomValidation.AttendanceStatusConverter))]
    public AttendanceStatus AttendanceStatus { get; set; }
}