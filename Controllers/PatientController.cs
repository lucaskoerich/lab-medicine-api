using lab_medicine_api.Dtos;
using lab_medicine_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab_medicine_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : Controller
{
    private readonly LabMedicineContext _labMedicineContext;

    public PatientController(LabMedicineContext labMedicineContext)
    {
        _labMedicineContext = labMedicineContext;
    }
    
    //TODO: FOREACH FOR ALLERGIES AND SPEC CARES LIST

    [HttpGet]
    public ActionResult<List<PatientDto>> GetPatient([FromQuery] string? status)
    {
        var listPatientModel = _labMedicineContext.Patients.Include(p => p.Appointments);

        List<PatientDto> listPatientDto = new();

        if (!string.IsNullOrEmpty(status))
        {
            foreach (var patient in listPatientModel)
            {
                if (patient.AttendanceStatus == status)
                {
                    var patientDto = new PatientDto();
                    patientDto.Name = patient.Name;
                    patientDto.CPF = patient.CPF;
                    patientDto.Gender = patient.Gender;
                    patientDto.PhoneNumber = patient.PhoneNumber;
                    patientDto.EmergencyContact = patient.EmergencyContact;
                    patientDto.Allergies = patientDto.Allergies;
                    patientDto.SpecificCares = patient.SpecificCares;
                    patientDto.Insurance = patient.Insurance;

                    listPatientDto.Add(patientDto);
                }
            }

            return Ok(listPatientDto);
        }

        foreach (var patient in listPatientModel)
        {
            var patientDto = new PatientDto();
            patientDto.Name = patient.Name;
            patientDto.CPF = patient.CPF;
            patientDto.Gender = patient.Gender;
            patientDto.PhoneNumber = patient.PhoneNumber;
            patientDto.EmergencyContact = patient.EmergencyContact;
            patientDto.Allergies = patientDto.Allergies;
            patientDto.SpecificCares = patient.SpecificCares;
            patientDto.Insurance = patient.Insurance;

            listPatientDto.Add(patientDto);
        }

        return Ok(listPatientDto);
    }


    [HttpPost]
    public ActionResult PostPatient([FromBody] PatientDto patientDto)
    {
        var patientExists = _labMedicineContext.Patients.Any(p => p.CPF == patientDto.CPF);

        if (patientExists)
        {
            return Conflict("CPF já cadastrado no sistema.");
        }

        PatientModel patientModel = new();

        patientModel.Name = patientDto.Name;
        patientModel.Gender = patientDto.Gender;
        patientModel.BirthDate = patientDto.BirthDate;
        patientModel.CPF = patientDto.CPF;
        patientModel.PhoneNumber = patientDto.PhoneNumber;
        patientModel.EmergencyContact = patientDto.EmergencyContact;
        patientModel.Allergies = patientDto.Allergies;
        patientModel.SpecificCares = patientDto.SpecificCares;
        patientModel.Insurance = patientDto.Insurance;
        patientModel.AttendanceStatus = "AGUARDANDO_ATENDIMENTO";

        if (TryValidateModel(patientModel))
        {
            _labMedicineContext.Add(patientModel);
            _labMedicineContext.SaveChanges();

            return Created(Request.Path, patientDto);
        }

        return BadRequest("Há campos não preenchidos da forma correta.");
    }

    [HttpPut]
    public ActionResult PutPatient([FromBody] PatientDto patientDto)
    {
        PatientModel patientModel = _labMedicineContext.Patients.Where(p => p.CPF == patientDto.CPF).FirstOrDefault();

        if (patientModel != null)
        {
            patientModel.Name = patientDto.Name;
            patientModel.Gender = patientDto.Gender;
            patientModel.BirthDate = patientDto.BirthDate;
            patientModel.CPF = patientDto.CPF;
            patientModel.PhoneNumber = patientDto.PhoneNumber;
            patientModel.EmergencyContact = patientDto.EmergencyContact;
            patientModel.Allergies = patientDto.Allergies;
            patientModel.SpecificCares = patientDto.SpecificCares;
            patientModel.Insurance = patientDto.Insurance;

            _labMedicineContext.Update(patientDto);
            _labMedicineContext.SaveChanges();
            return Ok(patientDto);
        }

        return NotFound("Paciente não encontrado.");
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
}