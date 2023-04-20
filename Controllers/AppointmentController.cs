using lab_medicine_api.Dtos;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_medicine_api.Controllers;

[ApiController]
[Route("api/atendimentos")]
public class AppointmentController : Controller
{
    private readonly LabMedicineContext _labMedicineContext;

    public AppointmentController(LabMedicineContext labMedicineContext)
    {
        _labMedicineContext = labMedicineContext;
    }

    [HttpPut]
    public ActionResult<AppointmentDto> NewAppointment([FromBody] AppointmentDto appointmentDto)
    {
        var doctor = _labMedicineContext.Doctors.Where(d => d.Id == appointmentDto.DoctorModelId).FirstOrDefault();
        var patient = _labMedicineContext.Patients.Where(p => p.Id == appointmentDto.PatientModelId).FirstOrDefault();

        if (doctor == null)
        {
            return StatusCode(404, "Médico não encontrado.");
        }

        if (doctor.StatusInSystem == StatusInSystem.INATIVO)
        {
            return StatusCode(400, "Médico se encontra inativo no sistema.");
        }

        if (patient == null)
        {
            return StatusCode(404, "Paciente não encontrado.");
        }

        appointmentDto.DoctorModelId = doctor.Id;
        appointmentDto.PatientModelId = patient.Id;

        AppointmentModel appointmentModel = new();

        appointmentModel.DoctorModelId = appointmentDto.DoctorModelId;
        appointmentModel.PatientModelId = appointmentDto.PatientModelId;
        appointmentModel.Description = appointmentDto.Description;

        patient.AttendanceStatus = AttendanceStatus.ATENDIDO;

        doctor.AppointmentCount++;
        patient.AppointmentCount++;


        _labMedicineContext.Add(appointmentModel);
        _labMedicineContext.Attach(doctor);
        _labMedicineContext.Attach(patient);
        _labMedicineContext.SaveChanges();

        return StatusCode(200, appointmentDto);
    }
}