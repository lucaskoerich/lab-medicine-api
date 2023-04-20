using lab_medicine_api.Models;

namespace lab_medicine_api.Seeders;

public class AppointmentSeeder
{
    public List<AppointmentModel> Seed()
    {
        var appointments = new List<AppointmentModel>
        {
            new () { Description = "Consulta de rotina", DoctorModelId = 11, PatientModelId = 1, Id = 1 },
            new () { Description = "Exame de sangue", DoctorModelId = 12, PatientModelId = 1, Id = 2 },
            new () { Description = "Consulta de rotina", DoctorModelId = 11, PatientModelId = 2, Id = 3 },
            new () { Description = "Consulta de rotina", DoctorModelId = 12, PatientModelId = 3, Id = 4 },
            new () { Description = "Acompanhamento nutricional", DoctorModelId = 11, PatientModelId = 3, Id = 5 },
            new () { Description = "Consulta de alergia", DoctorModelId = 11, PatientModelId = 3, Id = 6 },
            new () { Description = "Consulta de rotina", DoctorModelId = 12, PatientModelId = 4, Id = 7 },
            new () { Description = "Consulta para avaliação cardíaca", DoctorModelId = 12, PatientModelId = 4, Id = 8 },
            new () { Description = "Consulta de rotina", DoctorModelId = 12, PatientModelId = 5, Id = 9 },
            new () { Description = "Consulta de rotina", DoctorModelId = 11, PatientModelId = 7, Id = 10 },
            new () { Description = "Consulta de rotina", DoctorModelId = 12, PatientModelId = 8, Id = 11 },
            new () { Description = "Consulta de rotina", DoctorModelId = 11, PatientModelId = 9, Id = 12 },
            new () { Description = "Exame de sangue", DoctorModelId = 12, PatientModelId = 9, Id = 13 }
        };

        return appointments;
    }
}