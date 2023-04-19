using lab_medicine_api.Dtos;
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
    public ActionResult<List<GetDoctorDto>> GetDoctors([FromQuery] StatusInSystem? status)
    {
        var doctorModelList = _labMedicineContext.Doctors;
        var appointmentsList = _labMedicineContext.Appointments.ToList();

        List<GetDoctorDto> doctorDtoList = new();

        foreach (var doctor in doctorModelList)
        {
            var getDoctorDto = new GetDoctorDto();

            getDoctorDto.Id = doctor.Id;
            getDoctorDto.Name = doctor.Name;
            getDoctorDto.Gender = doctor.Gender;
            getDoctorDto.BirthDate = doctor.BirthDate;
            getDoctorDto.CPF = doctor.CPF;
            getDoctorDto.PhoneNumber = doctor.PhoneNumber;
            getDoctorDto.EducationalInstitution = doctor.EducationalInstitution;
            getDoctorDto.CrmUf = doctor.CrmUf;
            getDoctorDto.ClinicalSpecialization = doctor.ClinicalSpecialization;
            getDoctorDto.StatusInSystem = doctor.StatusInSystem;
            getDoctorDto.AppointmentCount = doctor.AppointmentCount;


            var doctorAppointments = appointmentsList.Where(a => a.DoctorId == doctor.Id).ToList();

            getDoctorDto.Appointments = doctorAppointments.Select(a => new AppointmentModel
            {
                DoctorId = a.DoctorId, PatientId = a.PatientId, Description = a.Description, Id = a.Id
            }).ToList();
            doctorDtoList.Add(getDoctorDto);
        }

        // todo: error treatment

        if (status != null)
        {
            doctorDtoList = doctorDtoList.Where(p => p.StatusInSystem == status).ToList();
            return Ok(doctorDtoList);
        }

        return Ok(doctorDtoList);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<GetDoctorDto> GetDoctorByCPF([FromRoute] int id)
    {
        DoctorModel doctorModel = _labMedicineContext.Doctors.Find(id);
        var appointmentsList = _labMedicineContext.Appointments.ToList();

        if (doctorModel == null)
        {
            return NotFound("Médico não encontrado!");
        }

        var getDoctorDto = new GetDoctorDto();

        getDoctorDto.Id = doctorModel.Id;
        getDoctorDto.Name = doctorModel.Name;
        getDoctorDto.Gender = doctorModel.Gender;
        getDoctorDto.BirthDate = doctorModel.BirthDate;
        getDoctorDto.CPF = doctorModel.CPF;
        getDoctorDto.PhoneNumber = doctorModel.PhoneNumber;
        getDoctorDto.EducationalInstitution = doctorModel.EducationalInstitution;
        getDoctorDto.CrmUf = doctorModel.CrmUf;
        getDoctorDto.ClinicalSpecialization = doctorModel.ClinicalSpecialization;
        getDoctorDto.StatusInSystem = doctorModel.StatusInSystem;
        getDoctorDto.AppointmentCount = doctorModel.AppointmentCount;

        var doctorAppointments = appointmentsList.Where(a => a.DoctorId == getDoctorDto.Id).ToList();

        getDoctorDto.Appointments = doctorAppointments.Select(a => new AppointmentModel
        {
            DoctorId = a.DoctorId, PatientId = a.PatientId, Description = a.Description, Id = a.Id
        }).ToList();

        return Ok(getDoctorDto);
    }


    [HttpPost]
    public ActionResult<DoctorDto> DoctorPost([FromBody] DoctorDto doctorDto)
    {
        var doctorExists = _labMedicineContext.Doctors.Any(d => d.CPF == doctorDto.CPF);

        if (doctorExists)
        {
            return Conflict("Médico já está cadastrado no sistema.");
        }

        DoctorModel doctorModel = new();
        
        doctorModel.Name = doctorDto.Name;
        doctorModel.Gender = doctorDto.Gender;
        doctorModel.BirthDate = doctorDto.BirthDate;
        doctorModel.CPF = doctorDto.CPF;
        doctorModel.PhoneNumber = doctorDto.PhoneNumber;
        doctorModel.EducationalInstitution = doctorDto.EducationalInstitution;
        doctorModel.CrmUf = doctorDto.CrmUf;
        doctorModel.ClinicalSpecialization = doctorDto.ClinicalSpecialization;
        doctorModel.StatusInSystem = doctorDto.StatusInSystem;

        if (TryValidateModel(doctorModel))
        {
            _labMedicineContext.Add(doctorModel);
            _labMedicineContext.SaveChanges();

            return Created(Request.Path, doctorDto);
        }

        return BadRequest("Há campos não preenchidos da forma correta.");
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<DoctorDto> UpdateDoctor([FromRoute] int id, [FromBody] DoctorDto doctorDto)
    {
        DoctorModel doctorModel = _labMedicineContext.Doctors.Find(id);

        if (doctorModel == null)
        {
            return NotFound("Médico não encontrado.");
        }

        doctorModel.Name = doctorDto.Name;
        doctorModel.Gender = doctorDto.Gender;
        doctorModel.BirthDate = doctorDto.BirthDate;
        doctorModel.CPF = doctorDto.CPF;
        doctorModel.PhoneNumber = doctorDto.PhoneNumber;
        doctorModel.EducationalInstitution = doctorDto.EducationalInstitution;
        doctorModel.CrmUf = doctorDto.CrmUf;
        doctorModel.ClinicalSpecialization = doctorDto.ClinicalSpecialization;
        doctorModel.StatusInSystem = doctorDto.StatusInSystem;

        if (TryValidateModel(doctorDto))
        {
            _labMedicineContext.Attach(doctorModel);
            _labMedicineContext.SaveChanges();

            return Ok(doctorDto);
        }

        return BadRequest("Há campos não preenchidos da forma correta.");
    }

    [HttpPatch]
    [Route("{id}/status")]
    public ActionResult<PatchDoctorDto> UpdateDoctorStatus([FromRoute] int id, [FromBody] PatchDoctorDto patchDoctorDto)
    {
        DoctorModel doctorModel = _labMedicineContext.Doctors.Find(id);

        if (doctorModel == null)
        {
            return NotFound("Médico não encontrado.");
        }

        doctorModel.StatusInSystem = patchDoctorDto.StatusInSystem;

        _labMedicineContext.Attach(doctorModel);
        _labMedicineContext.SaveChanges();
        return Ok(patchDoctorDto);
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteDoctor([FromRoute] int id)
    {
        var doctorToRemove = _labMedicineContext.Doctors.Find(id);
        
        if (doctorToRemove == null)
        {
            return NotFound("Médico não encontrado.");
        }

        _labMedicineContext.Remove(doctorToRemove);
        _labMedicineContext.SaveChanges();
        return NoContent();
    }
}