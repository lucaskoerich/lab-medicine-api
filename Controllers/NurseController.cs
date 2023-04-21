using lab_medicine_api.Dtos;
using lab_medicine_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_medicine_api.Controllers;

[ApiController]
[Route("api/enfermeiros")]
public class NurseController : Controller
{
    private readonly LabMedicineContext _labMedicineContext;

    public NurseController(LabMedicineContext labMedicineContext)
    {
        _labMedicineContext = labMedicineContext;
    }

    [HttpGet]
    public ActionResult<List<GetNurseDto>> GetNurses()
    {
        var nurseModelList = _labMedicineContext.Nurses;

        List<GetNurseDto> nurseDtoList = new();

        foreach (var nurse in nurseModelList)
        {
            GetNurseDto nurseDto = new();

            nurseDto.Id = nurse.Id;
            nurseDto.Name = nurse.Name;
            nurseDto.Gender = nurse.Gender;
            nurseDto.BirthDate = nurse.BirthDate;
            nurseDto.CPF = nurse.CPF;
            nurseDto.PhoneNumber = nurse.PhoneNumber;
            nurseDto.EducationalInstitution = nurse.EducationalInstitution;
            nurseDto.CofenUf = nurse.CofenUf;

            nurseDtoList.Add(nurseDto);
        }

        return StatusCode(200, nurseDtoList);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<GetNurseDto> GetNurseById([FromRoute] int id)
    {
        NurseModel nurseModel = _labMedicineContext.Nurses.Find(id);

        if (nurseModel == null)
        {
            StatusCode(404, "Enfermeiro não encontrado.");
        }

        GetNurseDto nurseDto = new();

        nurseDto.Id = nurseModel.Id;
        nurseDto.Name = nurseModel.Name;
        nurseDto.Gender = nurseModel.Gender;
        nurseDto.BirthDate = nurseModel.BirthDate;
        nurseDto.CPF = nurseModel.CPF;
        nurseDto.PhoneNumber = nurseModel.PhoneNumber;
        nurseDto.EducationalInstitution = nurseModel.EducationalInstitution;
        nurseDto.CofenUf = nurseModel.CofenUf;

        return StatusCode(200, nurseDto);
    }

    [HttpPost]
    public ActionResult<NurseDto> NursePost([FromBody] NurseDto nurseDto)
    {
        var nurseExists = _labMedicineContext.Nurses.Any(n => n.CPF == nurseDto.CPF);

        if (nurseExists)
        {
            return StatusCode(409, "Enfermeiro já está cadastrado no sistema.");
        }

        NurseModel nurseModel = new();

        nurseModel.Name = nurseDto.Name;
        nurseModel.Gender = nurseDto.Gender;
        nurseModel.BirthDate = nurseDto.BirthDate;
        nurseModel.PhoneNumber = nurseDto.PhoneNumber;
        nurseModel.CPF = nurseDto.CPF;
        nurseModel.EducationalInstitution = nurseDto.EducationalInstitution;
        nurseModel.CofenUf = nurseDto.CofenUf;

        if (TryValidateModel(nurseModel))
        {
            _labMedicineContext.Add(nurseModel);
            _labMedicineContext.SaveChanges();

            var identificador = nurseModel.Id;
            return StatusCode(201, new { nurseDto, identificador });
        }

        return StatusCode(400, "Há campos preenchidos de forma incorreta");
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<NurseDto> UpdateNurse([FromRoute] int id, [FromBody] NurseDto nurseDto)
    {
        NurseModel nurseModel = _labMedicineContext.Nurses.Find(id);

        if (nurseModel == null)
        {
            return StatusCode(404, "Enfermeiro não encontrado.");
        }

        nurseModel.Name = nurseDto.Name;
        nurseModel.Gender = nurseDto.Gender;
        nurseModel.BirthDate = nurseDto.BirthDate;
        nurseModel.CPF = nurseDto.CPF;
        nurseModel.PhoneNumber = nurseDto.PhoneNumber;
        nurseModel.EducationalInstitution = nurseDto.EducationalInstitution;
        nurseModel.CofenUf = nurseDto.CofenUf;

        var cpfExists = _labMedicineContext.Nurses.Any(p => p.CPF == nurseDto.CPF);

        if (cpfExists)
        {
            return StatusCode(409, "CPF já está cadastrado no sistema.");
        }

        if (TryValidateModel(nurseDto))
        {
            _labMedicineContext.Attach(nurseModel);
            _labMedicineContext.SaveChanges();
            return StatusCode(200, nurseDto);
        }

        return StatusCode(400, "Há campos preenchidos de forma incorreta");
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteNurse([FromRoute] int id)
    {
        var nurseToDelete = _labMedicineContext.Nurses.Find(id);

        if (nurseToDelete == null)
        {
            return StatusCode(404, "Enfermeiro não encontrado.");
        }

        _labMedicineContext.Remove(nurseToDelete);
        _labMedicineContext.SaveChanges();
        return StatusCode(204);
    }
}