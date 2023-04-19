using lab_medicine_api.Dtos;
using lab_medicine_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab_medicine_api.Controllers;

[ApiController]
[Route("api/pacientes")]
public class PatientController : Controller
{
    private readonly LabMedicineContext _labMedicineContext;

    public PatientController(LabMedicineContext labMedicineContext)
    {
        _labMedicineContext = labMedicineContext;
    }

    [HttpGet]
    public ActionResult<List<PatientDto>> GetPatient([FromQuery] AttendanceStatus? status)
    {
        var patientModelList = _labMedicineContext.Patients;
        var appointmentsList = _labMedicineContext.Appointments.ToList();

        List<PatientDto> patientDtoList = new();

        foreach (var patient in patientModelList)
        {
            var patientDto = new PatientDto();
            
            patientDto.Name = patient.Name;
            patientDto.CPF = patient.CPF;
            patientDto.Gender = patient.Gender;
            patientDto.PhoneNumber = patient.PhoneNumber;
            patientDto.EmergencyContact = patient.EmergencyContact;
            patientDto.Allergies = patient.Allergies;
            patientDto.SpecificCares = patient.SpecificCares;
            patientDto.Insurance = patient.Insurance;
            patientDto.AttendanceStatus = patient.AttendanceStatus;
            patientDto.AppointmentCount = patient.AppointmentCount;

            var patientAppointments = appointmentsList.Where(a => a.IdPatient == patient.CPF).ToList();

            patientDto.Appointments = patientAppointments.Select(a => new AppointmentModel
            {
                IdDoctor = a.IdDoctor, IdPatient = a.IdPatient, Description = a.Description, Id = a.Id
            }).ToList();

            patientDtoList.Add(patientDto);
        }

        if (status != null)
        {
            patientDtoList = patientDtoList.Where(p => p.AttendanceStatus == status).ToList();
            return Ok(patientDtoList);
        }

        return Ok(patientDtoList);
    }

    [HttpGet]
    [Route("{cpf}")]
    public ActionResult GetPatientByCPF([FromRoute] string cpf)
    {
        PatientModel patientModel = _labMedicineContext.Patients.Where(P => P.CPF == cpf).FirstOrDefault();
        var appointmentsList = _labMedicineContext.Appointments.ToList();

        if (patientModel == null)
        {
            return NotFound("Paciente não encontrado!");
        }

        var patientDto = new PatientDto();
        
        patientDto.Name = patientModel.Name;
        patientDto.CPF = patientModel.CPF;
        patientDto.Gender = patientModel.Gender;
        patientDto.PhoneNumber = patientModel.PhoneNumber;
        patientDto.EmergencyContact = patientModel.EmergencyContact;
        patientDto.Allergies = patientModel.Allergies;
        patientDto.SpecificCares = patientModel.SpecificCares;
        patientDto.Insurance = patientModel.Insurance;
        patientDto.AttendanceStatus = patientModel.AttendanceStatus;
        patientDto.AppointmentCount = patientModel.AppointmentCount;
        
        var patientAppointments = appointmentsList.Where(a => a.IdPatient == patientDto.CPF).ToList();

        patientDto.Appointments = patientAppointments.Select(a => new AppointmentModel
        {
            IdDoctor = a.IdDoctor, IdPatient = a.IdPatient, Description = a.Description, Id = a.Id
        }).ToList();

        return Ok(patientDto);
    }


    [HttpPost]
    public ActionResult PostPatient([FromBody] PostPatientDto postPatientDto)
    {
        var patientExists = _labMedicineContext.Patients.Any(p => p.CPF == postPatientDto.CPF);

        if (patientExists)
        {
            return Conflict("CPF já cadastrado no sistema.");
        }

        PatientModel patientModel = new();

        patientModel.Name = postPatientDto.Name;
        patientModel.Gender = postPatientDto.Gender;
        patientModel.BirthDate = postPatientDto.BirthDate;
        patientModel.CPF = postPatientDto.CPF;
        patientModel.PhoneNumber = postPatientDto.PhoneNumber;
        patientModel.EmergencyContact = postPatientDto.EmergencyContact;
        patientModel.Allergies = postPatientDto.Allergies;
        patientModel.SpecificCares = postPatientDto.SpecificCares;
        patientModel.Insurance = postPatientDto.Insurance;
        patientModel.AttendanceStatus = AttendanceStatus.AGUARDANDO_ATENDIMENTO;


        if (TryValidateModel(patientModel))
        {
            _labMedicineContext.Add(patientModel);
            _labMedicineContext.SaveChanges();

            return Created(Request.Path, postPatientDto);
        }

        return BadRequest("Há campos preenchidos de forma incorreta.");
    }


    [HttpPut]
    [Route("{cpf}")]
    public ActionResult UpdatePatient([FromRoute] string cpf, [FromBody] UpdatePatientDto updatePatientDto)
    {
        PatientModel patientModel = _labMedicineContext.Patients.Where(p => p.CPF == cpf).FirstOrDefault();

        if (patientModel == null)
        {
            return NotFound("Paciente não encontrado.");
        }

        patientModel.Name = updatePatientDto.Name;
        patientModel.Gender = updatePatientDto.Gender;
        patientModel.BirthDate = updatePatientDto.BirthDate;
        patientModel.CPF = updatePatientDto.CPF;
        patientModel.PhoneNumber = updatePatientDto.PhoneNumber;
        patientModel.EmergencyContact = updatePatientDto.EmergencyContact;
        patientModel.Allergies = updatePatientDto.Allergies;
        patientModel.SpecificCares = updatePatientDto.SpecificCares;
        patientModel.Insurance = updatePatientDto.Insurance;

        if (TryValidateModel(updatePatientDto))
        {
            _labMedicineContext.Attach(updatePatientDto);
            _labMedicineContext.SaveChanges();
            return Ok(updatePatientDto);
        }

        return BadRequest("Há campos preenchidos de forma incorreta.");
    }


    [HttpPatch]
    [Route("{CPF}/status")]
    public ActionResult UpdateAttendanceStatus([FromRoute] string CPF, [FromBody] PatchPatientDto patchPatientDto)
    {
        PatientModel patientModel = _labMedicineContext.Patients.Where(p => p.CPF == CPF).FirstOrDefault();

        if (patientModel != null)
        {
            patientModel.AttendanceStatus = patchPatientDto.AttendanceStatus;

            _labMedicineContext.Attach(patientModel);
            _labMedicineContext.SaveChanges();
            return Ok(patchPatientDto);
        }

        return NotFound("Paciente não encontrado.");
    }

    [HttpDelete]
    [Route("{cpf}")]
    public ActionResult DeletePatient([FromRoute] string cpf)
    {
        var patientToRemove = _labMedicineContext.Patients.Where(p => p.CPF == cpf).FirstOrDefault();

        if (patientToRemove == null)
        {
            return NotFound("Paciente não encontrado.");
        }

        _labMedicineContext.Remove(patientToRemove);
        _labMedicineContext.SaveChanges();
        return NoContent();
    }
}