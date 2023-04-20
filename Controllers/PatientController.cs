using lab_medicine_api.Dtos;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;
using Microsoft.AspNetCore.Mvc;

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

            patientDto.Id = patient.Id;
            patientDto.Name = patient.Name;
            patientDto.CPF = patient.CPF;
            patientDto.Gender = patient.Gender;
            patientDto.PhoneNumber = patient.PhoneNumber;
            patientDto.BirthDate = patient.BirthDate;
            patientDto.EmergencyContact = patient.EmergencyContact;
            patientDto.Allergies = patient.Allergies;
            patientDto.SpecificCares = patient.SpecificCares;
            patientDto.Insurance = patient.Insurance;
            patientDto.AttendanceStatus = patient.AttendanceStatus;
            patientDto.AppointmentCount = patient.AppointmentCount;

            var patientAppointments = appointmentsList.Where(a => a.PatientModelId == patient.Id).ToList();

            //gets all appointments and adds them to the appointments list
            patientDto.Appointments = patientAppointments.Select(a => new AppointmentModel
            {
                DoctorModelId = a.DoctorModelId, PatientModelId = a.PatientModelId, Description = a.Description, Id = a.Id
            }).ToList();

            patientDtoList.Add(patientDto);
        }

        if (status == null)
        {
            return StatusCode(200, patientDtoList);
        }

        patientDtoList = patientDtoList.Where(p => p.AttendanceStatus == status).ToList();
        return StatusCode(200, patientDtoList);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<PatientDto> GetPatientByID([FromRoute] int id)
    {
        PatientModel patientModel = _labMedicineContext.Patients.Where(P => P.Id == id).FirstOrDefault();
        var appointmentsList = _labMedicineContext.Appointments.ToList();

        if (patientModel == null)
        {
            return StatusCode(404, "Paciente não encontrado!");
        }

        var patientDto = new PatientDto();

        patientDto.Id = patientModel.Id;
        patientDto.Name = patientModel.Name;
        patientDto.CPF = patientModel.CPF;
        patientDto.Gender = patientModel.Gender;
        patientDto.PhoneNumber = patientModel.PhoneNumber;
        patientDto.BirthDate = patientModel.BirthDate;
        patientDto.EmergencyContact = patientModel.EmergencyContact;
        patientDto.Allergies = patientModel.Allergies;
        patientDto.SpecificCares = patientModel.SpecificCares;
        patientDto.Insurance = patientModel.Insurance;
        patientDto.AttendanceStatus = patientModel.AttendanceStatus;
        patientDto.AppointmentCount = patientModel.AppointmentCount;

        var patientAppointments = appointmentsList.Where(a => a.PatientModelId == patientDto.Id).ToList();

        //gets all appointments and adds them to the appointments list
        patientDto.Appointments = patientAppointments.Select(a => new AppointmentModel()
        {
            DoctorModelId = a.DoctorModelId, PatientModelId = a.PatientModelId, Description = a.Description, Id = a.Id
        }).ToList();

        return StatusCode(200, patientDto);
    }

    [HttpPost]
    public ActionResult<PostPatientDto> PostPatient([FromBody] PostPatientDto postPatientDto)
    {
        var patientExists = _labMedicineContext.Persons.Any(p => p.CPF == postPatientDto.CPF);

        if (patientExists)
        {
            return StatusCode(409, "CPF já cadastrado no sistema.");
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

        if (!TryValidateModel(patientModel))
        {
            return StatusCode(400, "Há campos preenchidos de forma incorreta.");
        }

        _labMedicineContext.Add(patientModel);
        _labMedicineContext.SaveChanges();

        var returnBody = new { identificador = patientModel.Id, atendimentos = patientModel.Appointments };

        return StatusCode(201, new { postPatientDto, returnBody });
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<UpdatePatientDto> UpdatePatient([FromRoute] int id, [FromBody] UpdatePatientDto updatePatientDto)
    {
        PatientModel patientModel = _labMedicineContext.Patients.Find(id);

        if (patientModel == null)
        {
            return StatusCode(404, "Paciente não encontrado.");
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

        var cpfExists = _labMedicineContext.Persons.Any(p => p.CPF == updatePatientDto.CPF);

        if (cpfExists)
        {
            return StatusCode(409, "CPF já está cadastrado no sistema.");
        }

        if (TryValidateModel(updatePatientDto))
        {
            _labMedicineContext.Attach(patientModel);
            _labMedicineContext.SaveChanges();
            return StatusCode(200, updatePatientDto);
        }

        return StatusCode(400, "Há campos preenchidos de forma incorreta.");
    }

    [HttpPatch]
    [Route("{id}/status")]
    public ActionResult<PatchPatientDto> UpdateAttendanceStatus([FromRoute] int id, [FromBody] PatchPatientDto patchPatientDto)
    {
        PatientModel patientModel = _labMedicineContext.Patients.Find(id);

        if (patientModel == null)
        {
            return StatusCode(404, "Paciente não encontrado.");
        }

        patientModel.AttendanceStatus = patchPatientDto.AttendanceStatus;

        _labMedicineContext.Attach(patientModel);
        _labMedicineContext.SaveChanges();
        return StatusCode(200, patchPatientDto);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeletePatient([FromRoute] int id)
    {
        var patientToRemove = _labMedicineContext.Patients.Find(id);

        if (patientToRemove == null)
        {
            return StatusCode(404, "Paciente não encontrado.");
        }

        _labMedicineContext.Remove(patientToRemove);
        _labMedicineContext.SaveChanges();
        return StatusCode(204);
    }
}