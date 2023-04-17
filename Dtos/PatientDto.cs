using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using lab_medicine_api.Models;

namespace lab_medicine_api.Dtos;

public class PatientDto
{
    [Required(ErrorMessage = "Nome não pode ser vazio!")]
    [MinLength(5, ErrorMessage = "Nome precisa conter no mínimo 5 caracteres.")]
    public string Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Gênero não pode ser vazio!")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Deve ser uma data válida.")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "CPF não pode ser vazio!")]
    [Index(IsUnique = true)]
    public string CPF { get; set; }

    [Required]
    [MinLength(11, ErrorMessage = "Telefone deve conter pelo menos 11 caracteres.")]
    public string PhoneNumber { get; set; }

    [Required]
    [MinLength(11, ErrorMessage = "Contato de emergência deve conter pelo menos 11 caracteres.")]
    public string EmergencyContact { get; set; }

    public List<string>? Allergies { get; set; }

    public List<string>? SpecificCares { get; set; }
    public string? Insurance { get; set; }
}

public class PatchPatientDto
{
    [Required(ErrorMessage = "Status do atendimento é necessário.")] public string AttendanceStatus { get; set; }
}