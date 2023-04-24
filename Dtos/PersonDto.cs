using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_medicine_api.Dtos;

public abstract class PersonDto
{
    [Required(ErrorMessage = "Nome não pode ser vazio!")]
    [MinLength(5, ErrorMessage = "Nome precisa conter no mínimo 5 caracteres.")]
    public string Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Gênero não pode ser vazio!")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Deve ser uma data válida.")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "CPF não pode ser vazio!")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter apenas 11 dígitos numéricos.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "Telefone não pode ser vazio!")]
    [MinLength(11, ErrorMessage = "Telefone deve conter pelo menos 11 caracteres.")]
    public string PhoneNumber { get; set; }
}

public class GetPersonDto : PersonDto
{
    [Key] public int Id { get; set; }
}