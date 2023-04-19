using System.ComponentModel.DataAnnotations;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;

namespace lab_medicine_api.Seeders;

public class PatientSeeder
{
    private readonly LabMedicineContext _labMedicineContext;

    public PatientSeeder(LabMedicineContext labMedicineContext)
    {
        _labMedicineContext = labMedicineContext;
    }

    public void Seed(LabMedicineContext context)
    {
        // Verifica se já existem pacientes na base de dados
        if (_labMedicineContext.Patients.Any())
        {
            return; // Dados já foram adicionados
        }

        var patients = new List<PatientModel>
        {
            new PatientModel
            {
                Name = "João Silva",
                Gender = "Masculino",
                BirthDate = new DateTime(1985, 10, 15, 22, 15, 58),
                CPF = "12345678901",
                PhoneNumber = "91986850045",
                EmergencyContact = "91365777069",
                Allergies = new List<string> { "Amendoim", "Aspirina" },
                SpecificCares = new List<string> { "Hipertensão" },
                Insurance = "Amil",
                AttendanceStatus = AttendanceStatus.ATENDIDO,
                AppointmentCount = 2,
                Appointments = new List<AppointmentModel>
                {
                    new AppointmentModel { Description = "Consulta de rotina", DoctorId = 11, PatientId = 1 },
                    new AppointmentModel { Description = "Exame de sangue", DoctorId = 12, PatientId = 1 }
                }
            },
            new PatientModel
            {
                Name = "Maria Santos",
                Gender = "Feminino",
                BirthDate = new DateTime(1990, 05, 23),
                CPF = "23456789012",
                PhoneNumber = "11987654322",
                EmergencyContact = "69992556682",
                Allergies = new List<string> { "Leite", "Penicilina" },
                SpecificCares = new List<string> { "Diabetes" },
                Insurance = "Unimed",
                AttendanceStatus = AttendanceStatus.EM_ATENDIMENTO,
                AppointmentCount = 1,
                Appointments = new List<AppointmentModel> { new AppointmentModel { Description = "Consulta de rotina", DoctorId = 1, PatientId = 2 } }
            },
            new PatientModel
            {
                Name = "Ana Paula Oliveira",
                Gender = "Feminino",
                BirthDate = new DateTime(1982, 06, 12),
                CPF = "34567890123",
                PhoneNumber = "11991234567",
                EmergencyContact = "11987654321",
                Allergies = new List<string> { "Frutos do mar", "Glúten" },
                SpecificCares = new List<string> { "Asma" },
                Insurance = "Bradesco Saúde",
                AttendanceStatus = AttendanceStatus.ATENDIDO,
                AppointmentCount = 3,
                Appointments = new List<AppointmentModel>
                {
                    new AppointmentModel { Description = "Consulta de rotina", DoctorId = 12, PatientId = 3 },
                    new AppointmentModel { Description = "Acompanhamento nutricional", DoctorId = 11, PatientId = 3 },
                    new AppointmentModel { Description = "Consulta de alergia", DoctorId = 11, PatientId = 3 }
                }
            },
            new PatientModel
            {
                Name = "José da Silva",
                Gender = "Masculino",
                BirthDate = new DateTime(1975, 11, 02),
                CPF = "45678901234",
                PhoneNumber = "21998765432",
                EmergencyContact = "21987654321",
                Allergies = new List<string> { "Abacaxi", "Ibuprofeno" },
                SpecificCares = new List<string> { "Pressão alta" },
                Insurance = "SulAmérica Saúde",
                AttendanceStatus = AttendanceStatus.ATENDIDO,
                AppointmentCount = 2,
                Appointments = new List<AppointmentModel>
                {
                    new AppointmentModel { Description = "Consulta de rotina", DoctorId = 12, PatientId = 4 },
                    new AppointmentModel { Description = "Consulta para avaliação cardíaca", DoctorId = 12, PatientId = 4 }
                }
            },
            new PatientModel
            {
                Name = "Ana Souza",
                Gender = "Feminino",
                BirthDate = new DateTime(1995, 3, 5),
                CPF = "34567890123",
                PhoneNumber = "21987654321",
                EmergencyContact = "21976453627",
                Allergies = new List<string> { "Ampicilina", "Abacaxi" },
                SpecificCares = new List<string> { "Asma" },
                Insurance = "Bradesco Saúde",
                AttendanceStatus = AttendanceStatus.AGUARDANDO_ATENDIMENTO,
                AppointmentCount = 1,
                Appointments = new List<AppointmentModel> { new AppointmentModel { Description = "Consulta de rotina", DoctorId = 12, PatientId = 5 } }
            },
            new PatientModel
            {
                Name = "Pedro Oliveira",
                Gender = "Masculino",
                BirthDate = new DateTime(1970, 8, 13),
                CPF = "45678901234",
                PhoneNumber = "31987654321",
                EmergencyContact = "31974563215",
                Allergies = new List<string> { "Frutos do mar", "Cacau" },
                SpecificCares = new List<string> { "Colesterol alto" },
                Insurance = "SulAmérica",
                AttendanceStatus = AttendanceStatus.AGUARDANDO_ATENDIMENTO,
                AppointmentCount = 0,
                Appointments = new List<AppointmentModel>()
            },
            new PatientModel
            {
                Name = "Fernanda Oliveira",
                Gender = "Feminino",
                BirthDate = new DateTime(1995, 04, 25),
                CPF = "56789012345",
                PhoneNumber = "81991234567",
                EmergencyContact = "81987654321",
                Allergies = new List<string> { "Nozes", "Leite" },
                SpecificCares = new List<string> { "Depressão" },
                Insurance = "Golden Cross",
                AttendanceStatus = AttendanceStatus.EM_ATENDIMENTO,
                AppointmentCount = 1,
                Appointments = new List<AppointmentModel> { new AppointmentModel { Description = "Consulta de rotina", DoctorId = 11, PatientId = 7 } }
            },
            new PatientModel
            {
                Name = "Pedro Henrique Souza",
                Gender = "Masculino",
                BirthDate = new DateTime(1980, 12, 05),
                CPF = "67890123456",
                PhoneNumber = "31991234567",
                EmergencyContact = "31987654321",
                Allergies = new List<string> { "Poeira", "Camarão" },
                SpecificCares = new List<string> { "Diabetes" },
                Insurance = "Amil",
                AttendanceStatus = AttendanceStatus.AGUARDANDO_ATENDIMENTO,
                AppointmentCount = 1,
                Appointments = new List<AppointmentModel> { new AppointmentModel { Description = "Consulta de rotina", DoctorId = 12, PatientId = 8 } }
            },
            new PatientModel
            {
                Name = "Sandra Silva",
                Gender = "Feminino",
                BirthDate = new DateTime(1992, 03, 10),
                CPF = "78901234567",
                PhoneNumber = "21991234567",
                EmergencyContact = "21987654321",
                Allergies = new List<string> { "Amendoim", "Aspirina" },
                SpecificCares = new List<string> { "Hipertensão" },
                Insurance = "Unimed",
                AttendanceStatus = AttendanceStatus.ATENDIDO,
                AppointmentCount = 2,
                Appointments = new List<AppointmentModel>
                {
                    new AppointmentModel { Description = "Consulta de rotina", DoctorId = 11, PatientId = 9 },
                    new AppointmentModel { Description = "Exame de sangue", DoctorId = 12, PatientId = 9 }
                }
            },
            new PatientModel
            {
                Name = "Maria Joaquina",
                Gender = "Feminino",
                BirthDate = new DateTime(1997, 03, 21),
                CPF = "78901234567",
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
        
        _labMedicineContext.Persons.AddRange(patients);
        _labMedicineContext.SaveChanges();
        
    }
}