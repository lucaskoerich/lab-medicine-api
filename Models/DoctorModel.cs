using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using lab_medicine_api.Enums;
using lab_medicine_api.Validations;

namespace lab_medicine_api.Models;

[Table("DOCTORS")]
public class DoctorModel : PersonModel
{
    [Column("EDUCATIONAL_INSTITUTION")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Instituição de Ensino da Formação não pode ser vazio!")]
    public string EducationalInstitution { get; set; }

    [Column("CRM_UF")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "CRM/UF não pode ser vazio!")]
    public string CrmUf { get; set; }

    [Column("CLINICAL_SPECIALIZATION")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Especilização Clínica não pode ser vazio!")]
    [JsonConverter(typeof(CustomValidation.ClinicalSpecializationConverter))]
    public ClinicalSpecialization ClinicalSpecialization { get; set; }
    
    [Column("STATUS_IN_SYSTEM")]
    [Required(AllowEmptyStrings = false)]
    [JsonConverter(typeof(CustomValidation.StatusInSystemConverter))]
    public StatusInSystem StatusInSystem { get; set; }

    [Column("APPOINTMENT_COUNT")]
    [Required]
    public int AppointmentCount { get; set; }

    [Column("APPOINTMENTS")] public ICollection<AppointmentModel> Appointments { get; set; } = new List<AppointmentModel>();
}