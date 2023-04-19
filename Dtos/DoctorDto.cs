using System.ComponentModel.DataAnnotations;
using lab_medicine_api.Models;


namespace lab_medicine_api.Dtos;

public class DoctorDto : PersonDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Instituição de Ensino da Formação não pode ser vazio!")]
    public string EducationalInstitution { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "CRM/UF não pode ser vazio!")]
    public string CrmUf { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Especilização Clínica não pode ser vazio!")]
    public ClinicalSpecialization ClinicalSpecialization { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Estado no Sistema só pode ser ATIVO ou INATIVO")] public StatusInSystem StatusInSystem { get; set; }
}

public class GetDoctorDto : DoctorDto
{
    public int AppointmentCount { get; set; }

    public ICollection<AppointmentModel> Appointments { get; set; }
}

public class PatchDoctorDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Estado no Sistema só pode ser ATIVO ou INATIVO")] public StatusInSystem StatusInSystem { get; set; }

}