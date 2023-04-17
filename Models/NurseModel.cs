using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_medicine_api.Models;

[Table("NURSES")]
public class NurseModel : PersonModel
{
    [Column("EDUCATIONAL_INSTITUTION")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Instituição de Ensino da Formação não pode ser vazio!")]
    public string EducationalInstitution { get; set; }

    [Column("COFEN_UF")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "COFEN/UF não pode ser vazio!")]
    public string CofenUf { get; set; }
}