using System.ComponentModel.DataAnnotations;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;

namespace lab_medicine_api.Seeders;

public class PatientSeeder
{
    public List<PatientModel> Seed()
    {
        var patients = new List<PatientModel>
        {
            new ()
            {
                Id = 1,
                Name = "João Silva",
                Gender = "Masculino",
                BirthDate = new DateTime(1985, 10, 15, 22, 15, 58),
                CPF = "12874145871",
                PhoneNumber = "91986850045",
                EmergencyContact = "91365777069",
                Allergies = new List<string> { "Amendoim", "Aspirina" },
                SpecificCares = new List<string> { "Hipertensão" },
                Insurance = "Amil",
                AttendanceStatus = AttendanceStatus.ATENDIDO,
                AppointmentCount = 2,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 2,
                Name = "Maria Santos",
                Gender = "Feminino",
                BirthDate = new DateTime(1990, 05, 23),
                CPF = "65587414544",
                PhoneNumber = "11987654322",
                EmergencyContact = "69992556682",
                Allergies = new List<string> { "Leite", "Penicilina" },
                SpecificCares = new List<string> { "Diabetes" },
                Insurance = "Unimed",
                AttendanceStatus = AttendanceStatus.EM_ATENDIMENTO,
                AppointmentCount = 1,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 3,
                Name = "Ana Paula Oliveira",
                Gender = "Feminino",
                BirthDate = new DateTime(1982, 06, 12),
                CPF = "88748739057",
                PhoneNumber = "11991234567",
                EmergencyContact = "11987654321",
                Allergies = new List<string> { "Frutos do mar", "Glúten" },
                SpecificCares = new List<string> { "Asma" },
                Insurance = "Bradesco Saúde",
                AttendanceStatus = AttendanceStatus.ATENDIDO,
                AppointmentCount = 3,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 4,
                Name = "José da Silva",
                Gender = "Masculino",
                BirthDate = new DateTime(1975, 11, 02),
                CPF = "20070117004",
                PhoneNumber = "21998765432",
                EmergencyContact = "21987654321",
                Allergies = new List<string> { "Abacaxi", "Ibuprofeno" },
                SpecificCares = new List<string> { "Pressão alta" },
                Insurance = "SulAmérica Saúde",
                AttendanceStatus = AttendanceStatus.ATENDIDO,
                AppointmentCount = 2,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 5,
                Name = "Ana Souza",
                Gender = "Feminino",
                BirthDate = new DateTime(1995, 3, 5),
                CPF = "94942452023",
                PhoneNumber = "21987654321",
                EmergencyContact = "21976453627",
                Allergies = new List<string> { "Ampicilina", "Abacaxi" },
                SpecificCares = new List<string> { "Asma" },
                Insurance = "Bradesco Saúde",
                AttendanceStatus = AttendanceStatus.AGUARDANDO_ATENDIMENTO,
                AppointmentCount = 1,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 6,
                Name = "Pedro Oliveira",
                Gender = "Masculino",
                BirthDate = new DateTime(1970, 8, 13),
                CPF = "29061208041",
                PhoneNumber = "31987654321",
                EmergencyContact = "31974563215",
                Allergies = new List<string> { "Frutos do mar", "Cacau" },
                SpecificCares = new List<string> { "Colesterol alto" },
                Insurance = "SulAmérica",
                AttendanceStatus = AttendanceStatus.AGUARDANDO_ATENDIMENTO,
                AppointmentCount = 0,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 7,
                Name = "Fernanda Oliveira",
                Gender = "Feminino",
                BirthDate = new DateTime(1995, 04, 25),
                CPF = "54175182047",
                PhoneNumber = "81991234567",
                EmergencyContact = "81987654321",
                Allergies = new List<string> { "Nozes", "Leite" },
                SpecificCares = new List<string> { "Depressão" },
                Insurance = "Golden Cross",
                AttendanceStatus = AttendanceStatus.EM_ATENDIMENTO,
                AppointmentCount = 1,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 8,
                Name = "Pedro Henrique Souza",
                Gender = "Masculino",
                BirthDate = new DateTime(1980, 12, 05),
                CPF = "44849054005",
                PhoneNumber = "31991234567",
                EmergencyContact = "31987654321",
                Allergies = new List<string> { "Poeira", "Camarão" },
                SpecificCares = new List<string> { "Diabetes" },
                Insurance = "Amil",
                AttendanceStatus = AttendanceStatus.AGUARDANDO_ATENDIMENTO,
                AppointmentCount = 1,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 9,
                Name = "Sandra Silva",
                Gender = "Feminino",
                BirthDate = new DateTime(1992, 03, 10),
                CPF = "87427425014",
                PhoneNumber = "21991234567",
                EmergencyContact = "21987654321",
                Allergies = new List<string> { "Amendoim", "Aspirina" },
                SpecificCares = new List<string> { "Hipertensão" },
                Insurance = "Unimed",
                AttendanceStatus = AttendanceStatus.ATENDIDO,
                AppointmentCount = 2,
                Appointments = new List<AppointmentModel>()
            },
            new ()
            {
                Id = 10,
                Name = "Maria Joaquina",
                Gender = "Feminino",
                BirthDate = new DateTime(1997, 03, 21),
                CPF = "98257694088",
                PhoneNumber = "31987654321",
                EmergencyContact = "31998765432",
                Allergies = new List<string> { "Amendoim", "Lactose" },
                SpecificCares = new List<string> { "Asma" },
                Insurance = "Golden Cross",
                AttendanceStatus = AttendanceStatus.AGUARDANDO_ATENDIMENTO,
                AppointmentCount = 0,
                Appointments = new List<AppointmentModel>()
            }
        };
        
        //verifica se cada objeto da lista é válido antes de mandar pro bd
        foreach (var patient in patients)
        {
            var validationContext = new ValidationContext(patient);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(patient, validationContext, validationResults, true))
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }

                throw new Exception("Há dados preenchidos de forma incorreta!");
            }
        }

        return patients;
    }
}