using System.ComponentModel.DataAnnotations;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;

namespace lab_medicine_api.Seeders;

public class DoctorSeeder
{
    public List<DoctorModel> Seed()
    {
        var doctors = new List<DoctorModel>
        {
            new ()
            {
                Id = 11,
                Name = "Carlos Silva Antunes",
                Gender = "Masculino",
                BirthDate = new DateTime(1980, 1, 1),
                CPF = "60544567099",
                PhoneNumber = "71997437590",
                EducationalInstitution = "Universidade de São Paulo",
                CrmUf = "87458/SC",
                ClinicalSpecialization = ClinicalSpecialization.CLINICO_GERAL,
                StatusInSystem = StatusInSystem.ATIVO,
                AppointmentCount = 5
            },
            new ()
            {
                Id = 12,
                Name = "Maria Souza",
                Gender = "Feminino",
                BirthDate = new DateTime(1985, 5, 10),
                CPF = "26534267063",
                PhoneNumber = "27997538253",
                EducationalInstitution = "Universidade Federal do Rio de Janeiro",
                CrmUf = "14785/SC",
                ClinicalSpecialization = ClinicalSpecialization.PSIQUIATRIA,
                StatusInSystem = StatusInSystem.ATIVO,
                AppointmentCount = 10
            }
        };

        //verifica se cada objeto da lista é válido antes de mandar pro bd
        foreach (var doctor in doctors)
        {
            var validationContext = new ValidationContext(doctor);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(doctor, validationContext, validationResults, true))
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }

                throw new Exception("Há dados preenchidos de forma incorreta!");
            }
        }

        return doctors;
    }
}