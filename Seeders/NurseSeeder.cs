using System.ComponentModel.DataAnnotations;
using lab_medicine_api.Models;

namespace lab_medicine_api.Seeders;

public class NurseSeeder
{
    public List<NurseModel> Seed()
    {
        var nurses = new List<NurseModel>
        {
            new ()
            {
                Id = 1,
                Name = "Julia Silva",
                Gender = "Feminino",
                BirthDate = new DateTime(1990, 5, 20),
                CPF = "89924802020",
                PhoneNumber = "92993448986",
                EducationalInstitution = "Escola de Enfermagem da Universidade de São Paulo",
                CofenUf = "123456/SP"
            },
            new ()
            {
                Id = 2,
                Name = "Gabriel Santos",
                Gender = "Masculino",
                BirthDate = new DateTime(1985, 8, 15),
                CPF = "61385125020",
                PhoneNumber = "41994623474",
                EducationalInstitution = "Escola de Enfermagem da Universidade Federal do Rio de Janeiro",
                CofenUf = "654321/RJ"
            }
        };

        //verifica se cada objeto da lista é válido antes de mandar pro bd
        foreach (var nurse in nurses)
        {
            var validationContext = new ValidationContext(nurse);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(nurse, validationContext, validationResults, true))
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }

                throw new Exception("Há dados preenchidos de forma incorreta!");
            }
        }

        return nurses;
    }
}