using System.ComponentModel.DataAnnotations;

namespace lab_medicine_api.Dtos;

public class NurseDto : PersonDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Instituição de Ensino da Formação não pode ser vazio!")]
    public string EducationalInstitution { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "COFEN/UF não pode ser vazio!")]
    public string CofenUf { get; set; }
}

public class GetNurseDto : GetPersonDto
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Instituição de Ensino da Formação não pode ser vazio!")]
    public string EducationalInstitution { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "COFEN/UF não pode ser vazio!")]
    public string CofenUf { get; set; }
}