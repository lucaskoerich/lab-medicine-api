using System.ComponentModel.DataAnnotations;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;

namespace lab_medicine_api.Seeders;

public class DoctorSeeder
{
    private readonly LabMedicineContext _labMedicineContext;

    public DoctorSeeder(LabMedicineContext labMedicineContext)
    {
        _labMedicineContext = labMedicineContext;
    }

    public void Seed(LabMedicineContext context)
    {
        // Verifica se já existem pacientes na base de dados
        if (_labMedicineContext.Doctors.Any())
        {
            return; // Dados já foram adicionados
        }

        var doctors = new List<DoctorModel>
        {
            new DoctorModel
            {
                Name = "Carlos Silva Antunes",
                Gender = "Masculino",
                BirthDate = new DateTime(1980, 1, 1),
                CPF = "12345678901",
                PhoneNumber = "71997437590",
                EducationalInstitution = "Universidade de São Paulo",
                CrmUf = "87458/SC",
                ClinicalSpecialization = ClinicalSpecialization.CLINICO_GERAL,
                StatusInSystem = StatusInSystem.ATIVO,
                AppointmentCount = 5
            },
            new DoctorModel
            {
                Name = "Maria Souza",
                Gender = "Feminino",
                BirthDate = new DateTime(1985, 5, 10),
                CPF = "98765432101",
                PhoneNumber = "27997538253",
                EducationalInstitution = "Universidade Federal do Rio de Janeiro",
                CrmUf = "14785/SC",
                ClinicalSpecialization = ClinicalSpecialization.PSIQUIATRIA,
                StatusInSystem = StatusInSystem.ATIVO,
                AppointmentCount = 10
            }
        };
        
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
        
        _labMedicineContext.Doctors.AddRange(doctors);
        _labMedicineContext.SaveChanges();
    }
    
}