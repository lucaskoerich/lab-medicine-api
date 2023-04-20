using lab_medicine_api.Dtos;
using lab_medicine_api.Enums;
using lab_medicine_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_medicine_api.Controllers;

[ApiController]
[Route("api/medicos")]
public class DoctorController : Controller
{
    private readonly LabMedicineContext _labMedicineContext;

    public DoctorController(LabMedicineContext labMedicineContext)
    {
        _labMedicineContext = labMedicineContext;
    }

    [HttpGet]
    public ActionResult<List<DoctorDto>> GetDoctors([FromQuery] StatusInSystem? status)
    {
        var doctorModelList = _labMedicineContext.Doctors;
        var appointmentsList = _labMedicineContext.Appointments.ToList();

        List<DoctorDto> doctorDtoList = new();

        foreach (var doctor in doctorModelList)
        {
            var doctorDto = new DoctorDto();

            doctorDto.Id = doctor.Id;
            doctorDto.Name = doctor.Name;
            doctorDto.Gender = doctor.Gender;
            doctorDto.BirthDate = doctor.BirthDate;
            doctorDto.CPF = doctor.CPF;
            doctorDto.PhoneNumber = doctor.PhoneNumber;
            doctorDto.EducationalInstitution = doctor.EducationalInstitution;
            doctorDto.CrmUf = doctor.CrmUf;
            doctorDto.ClinicalSpecialization = doctor.ClinicalSpecialization;
            doctorDto.StatusInSystem = doctor.StatusInSystem;
            doctorDto.AppointmentCount = doctor.AppointmentCount;


            var doctorAppointments = appointmentsList.Where(a => a.DoctorModelId == doctor.Id).ToList();

            //gets all appointments and adds them to the appointments list
            doctorDto.Appointments = doctorAppointments.Select(a => new AppointmentModel
            {
                DoctorModelId = a.DoctorModelId, PatientModelId = a.PatientModelId, Description = a.Description, Id = a.Id
            }).ToList();
            doctorDtoList.Add(doctorDto);
        }

        if (status != null)
        {
            doctorDtoList = doctorDtoList.Where(p => p.StatusInSystem == status).ToList();
            return StatusCode(200, doctorDtoList);
        }

        return StatusCode(200, doctorDtoList);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<DoctorDto> GetDoctorByCPF([FromRoute] int id)
    {
        DoctorModel doctorModel = _labMedicineContext.Doctors.Find(id);
        var appointmentsList = _labMedicineContext.Appointments.ToList();

        if (doctorModel == null)
        {
            return StatusCode(404, "Médico não encontrado!");
        }

        var doctorDto = new DoctorDto();

        doctorDto.Id = doctorModel.Id;
        doctorDto.Name = doctorModel.Name;
        doctorDto.Gender = doctorModel.Gender;
        doctorDto.BirthDate = doctorModel.BirthDate;
        doctorDto.CPF = doctorModel.CPF;
        doctorDto.PhoneNumber = doctorModel.PhoneNumber;
        doctorDto.EducationalInstitution = doctorModel.EducationalInstitution;
        doctorDto.CrmUf = doctorModel.CrmUf;
        doctorDto.ClinicalSpecialization = doctorModel.ClinicalSpecialization;
        doctorDto.StatusInSystem = doctorModel.StatusInSystem;
        doctorDto.AppointmentCount = doctorModel.AppointmentCount;

        var doctorAppointments = appointmentsList.Where(a => a.DoctorModelId == doctorDto.Id).ToList();

        //gets all appointments and adds them to the appointments list
        doctorDto.Appointments = doctorAppointments.Select(a => new AppointmentModel
        {
            DoctorModelId = a.DoctorModelId, PatientModelId = a.PatientModelId, Description = a.Description, Id = a.Id
        }).ToList();

        return StatusCode(200, doctorDto);
    }

    [HttpPost]
    public ActionResult<PostDoctorDto> DoctorPost([FromBody] PostDoctorDto postDoctorDto)
    {
        var doctorExists = _labMedicineContext.Persons.Any(d => d.CPF == postDoctorDto.CPF);

        if (doctorExists)
        {
            return StatusCode(409, "Médico já está cadastrado no sistema.");
        }

        DoctorModel doctorModel = new();

        doctorModel.Name = postDoctorDto.Name;
        doctorModel.Gender = postDoctorDto.Gender;
        doctorModel.BirthDate = postDoctorDto.BirthDate;
        doctorModel.CPF = postDoctorDto.CPF;
        doctorModel.PhoneNumber = postDoctorDto.PhoneNumber;
        doctorModel.EducationalInstitution = postDoctorDto.EducationalInstitution;
        doctorModel.CrmUf = postDoctorDto.CrmUf;
        doctorModel.ClinicalSpecialization = postDoctorDto.ClinicalSpecialization;
        doctorModel.StatusInSystem = postDoctorDto.StatusInSystem;

        if (!TryValidateModel(doctorModel))
        {
            return StatusCode(400, "Há campos não preenchidos da forma correta.");
        }

        _labMedicineContext.Add(doctorModel);
        _labMedicineContext.SaveChanges();

        var returnBody = new { identificador = doctorModel.Id, atendimentos = doctorModel.Appointments };

        return StatusCode(201, new { postDoctorDto, returnBody });
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<PostDoctorDto> UpdateDoctor([FromRoute] int id, [FromBody] PostDoctorDto updateDoctorDto)
    {
        DoctorModel doctorModel = _labMedicineContext.Doctors.Find(id);

        if (doctorModel == null)
        {
            return StatusCode(404, "Médico não encontrado.");
        }

        doctorModel.Name = updateDoctorDto.Name;
        doctorModel.Gender = updateDoctorDto.Gender;
        doctorModel.BirthDate = updateDoctorDto.BirthDate;
        doctorModel.CPF = updateDoctorDto.CPF;
        doctorModel.PhoneNumber = updateDoctorDto.PhoneNumber;
        doctorModel.EducationalInstitution = updateDoctorDto.EducationalInstitution;
        doctorModel.CrmUf = updateDoctorDto.CrmUf;
        doctorModel.ClinicalSpecialization = updateDoctorDto.ClinicalSpecialization;
        doctorModel.StatusInSystem = updateDoctorDto.StatusInSystem;

        var cpfExists = _labMedicineContext.Persons.Any(p => p.CPF == updateDoctorDto.CPF);

        if (cpfExists)
        {
            return StatusCode(409, "CPF já está cadastrado no sistema.");
        }

        if (TryValidateModel(updateDoctorDto))
        {
            _labMedicineContext.Attach(doctorModel);
            _labMedicineContext.SaveChanges();

            return StatusCode(200, updateDoctorDto);
        }

        return StatusCode(400, "Há campos não preenchidos da forma correta.");
    }

    [HttpPatch]
    [Route("{id}/status")]
    public ActionResult<PatchDoctorDto> UpdateDoctorStatus([FromRoute] int id, [FromBody] PatchDoctorDto patchDoctorDto)
    {
        DoctorModel doctorModel = _labMedicineContext.Doctors.Find(id);

        if (doctorModel == null)
        {
            return StatusCode(404, "Médico não encontrado.");
        }

        doctorModel.StatusInSystem = patchDoctorDto.StatusInSystem;

        _labMedicineContext.Attach(doctorModel);
        _labMedicineContext.SaveChanges();
        return StatusCode(200, patchDoctorDto);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteDoctor([FromRoute] int id)
    {
        var doctorToRemove = _labMedicineContext.Doctors.Find(id);

        if (doctorToRemove == null)
        {
            return StatusCode(404, "Médico não encontrado.");
        }

        _labMedicineContext.Remove(doctorToRemove);
        _labMedicineContext.SaveChanges();
        return StatusCode(204);
    }
}