using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_medicine_api.Dtos;

public abstract class PersonDto
{
    [Column("ID")][Key] public int Id { get; set; }

    [Column("NAME")]
    [Required(ErrorMessage = "Nome não pode ser vazio!")]
    [MinLength(5, ErrorMessage = "Nome precisa conter no mínimo 5 caracteres.")]
    public string Name { get; set; }
    
    [Column("GENDER")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Gênero não pode ser vazio!")]
    public string Gender { get; set; }

    [Column("BIRTH_DATE")]
    [Required(ErrorMessage = "Deve ser uma data válida.")]
    public DateTime BirthDate { get; set; }

    [Column("CPF")]
    [Required(ErrorMessage = "CPF não pode ser vazio!")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter 11 caracteres e somente números.")]
    [Index(IsUnique = true)]
    public string CPF { get; set; }

    [Column("PHONE_NUMBER")]
    [Required(ErrorMessage = "Telefone não pode ser vazio!")]
    [MinLength(11, ErrorMessage = "Telefone deve conter pelo menos 11 caracteres.")]
    public string PhoneNumber { get; set; }
}