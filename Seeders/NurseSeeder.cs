using System.ComponentModel.DataAnnotations;
using lab_medicine_api.Models;

namespace lab_medicine_api.Seeders;

public class NurseSeeder
{
    private readonly LabMedicineContext _labMedicineContext;

    public NurseSeeder(LabMedicineContext labMedicineContext)
    {
        _labMedicineContext = labMedicineContext;
    }

    public void Seed(LabMedicineContext context)
    {
        // Verifica se já existem pacientes na base de dados
        if (_labMedicineContext.Nurses.Any())
        {
            return; // Dados já foram adicionados
        }

        var nurses = new List<NurseModel>
        {
            new NurseModel
            {
                Name = "Julia Silva",
                Gender = "Feminino",
                BirthDate = new DateTime(1990, 5, 20),
                CPF = "73467182089",
                PhoneNumber = "92993448986",
                EducationalInstitution = "Escola de Enfermagem da Universidade de São Paulo",
                CofenUf = "123456/SP"
            },
            new NurseModel
            {
                Name = "Gabriel Santos",
                Gender = "Masculino",
                BirthDate = new DateTime(1985, 8, 15),
                CPF = "98765432109",
                PhoneNumber = "41994623474",
                EducationalInstitution = "Escola de Enfermagem da Universidade Federal do Rio de Janeiro",
                CofenUf = "654321/RJ"
            }

        };
        
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
        
        _labMedicineContext.Persons.AddRange(nurses);
        _labMedicineContext.SaveChanges();

    }
}