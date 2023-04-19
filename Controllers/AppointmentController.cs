using lab_medicine_api.Dtos;
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
        var doctor = _labMedicineContext.Doctors.Where(d => d.Id == appointmentDto.DoctorId).FirstOrDefault();
        var patient = _labMedicineContext.Patients.Where(p => p.Id == appointmentDto.PatientId).FirstOrDefault();

        if (doctor == null)
        {
            return NotFound("Médico não encontrado.");
        }

        if (doctor.StatusInSystem == StatusInSystem.INATIVO)
        {
            return BadRequest("Médico se encontra inativo no sistema.");
        }

        if (patient == null)
        {
            return NotFound("Paciente não encontrado.");
        }

        appointmentDto.DoctorId = doctor.Id;
        appointmentDto.PatientId = patient.Id;
        
        AppointmentModel appointmentModel = new();
        
        appointmentModel.DoctorId = appointmentDto.DoctorId;
        appointmentModel.PatientId = appointmentDto.PatientId;
        appointmentModel.Description = appointmentDto.Description;
        
        patient.AttendanceStatus = AttendanceStatus.ATENDIDO;

        doctor.AppointmentCount++;
        patient.AppointmentCount++;

        if (TryValidateModel(appointmentModel))
        {
            _labMedicineContext.Add(appointmentModel);
            _labMedicineContext.Attach(doctor);
            _labMedicineContext.Attach(patient);
            _labMedicineContext.SaveChanges();

            return Ok(appointmentDto);
        }

        return BadRequest("Há campos preenchidos de forma incorreta.");
    }
}