using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;
using lab_medicine_api.Validations;

namespace lab_medicine_api.Dtos;

public class DoctorDto : GetPersonDto
{
    public string EducationalInstitution { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CRM/UF não pode ser vazio!")]
    public string CrmUf { get; set; }

    public ClinicalSpecialization ClinicalSpecialization { get; set; }

    public StatusInSystem StatusInSystem { get; set; }

    public int AppointmentCount { get; set; }

    public ICollection<AppointmentModel> Appointments { get; set; }
}

public class PatchDoctorDto
{
    [JsonConverter(typeof(CustomValidation.StatusInSystemConverter))]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Estado no Sistema só pode ser ATIVO ou INATIVO")]
    public StatusInSystem StatusInSystem { get; set; }
}

public class PostDoctorDto : PersonDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Instituição de Ensino da Formação não pode ser vazio!")]
    public string EducationalInstitution { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CRM/UF não pode ser vazio!")]
    public string CrmUf { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Especilização Clínica não pode ser vazio!")]
    [JsonConverter(typeof(CustomValidation.ClinicalSpecializationConverter))]
    public ClinicalSpecialization ClinicalSpecialization { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Estado no Sistema só pode ser ATIVO ou INATIVO")]
    [JsonConverter(typeof(CustomValidation.StatusInSystemConverter))]
    public StatusInSystem StatusInSystem { get; set; }
}