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
    public ActionResult<List<NurseDto>> GetNurses()
    {
        var nurseModelList = _labMedicineContext.Nurses;

        List<NurseDto> nurseDtoList = new();

        foreach (var nurse in nurseModelList)
        {
            NurseDto nurseDto = new();

            nurseDto.Id = nurse.Id;
            nurseDto.Name = nurse.Name;
            nurseDto.Gender = nurse.Gender;
            nurseDto.BirthDate = nurse.BirthDate;
            nurseDto.CPF = nurse.CPF;
            nurseDto.EducationalInstitution = nurse.EducationalInstitution;
            nurseDto.CofenUf = nurse.CofenUf;

            nurseDtoList.Add(nurseDto);
        }

        return Ok(nurseDtoList);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetNurseById([FromRoute] int id)
    {
        NurseModel nurseModel = _labMedicineContext.Nurses.Find(id);

        if (nurseModel == null)
        {
            NotFound("Enfermeiro não encontrado.");
        }

        NurseDto nurseDto = new();

        nurseDto.Id = nurseModel.Id;
        nurseDto.Name = nurseModel.Name;
        nurseDto.Gender = nurseModel.Gender;
        nurseDto.BirthDate = nurseModel.BirthDate;
        nurseDto.CPF = nurseModel.CPF;
        nurseDto.EducationalInstitution = nurseModel.EducationalInstitution;
        nurseDto.CofenUf = nurseModel.CofenUf;

        return Ok(nurseDto);
    }

    [HttpPost]
    public ActionResult<NurseDto> NursePost([FromBody] NurseDto nurseDto)
    {
        var nurseExists = _labMedicineContext.Nurses.Any(n => n.CPF == nurseDto.CPF);

        if (nurseExists)
        {
            return Conflict("Enfermeiro já está cadastrado no sistema.");
        }

        NurseModel nurseModel = new();

        nurseModel.Id = nurseDto.Id;
        nurseModel.Name = nurseDto.Name;
        nurseModel.Gender = nurseDto.Gender;
        nurseModel.BirthDate = nurseDto.BirthDate;
        nurseModel.CPF = nurseDto.CPF;
        nurseModel.EducationalInstitution = nurseDto.EducationalInstitution;
        nurseModel.CofenUf = nurseDto.CofenUf;

        if (TryValidateModel(nurseModel))
        {
            _labMedicineContext.Add(nurseModel);
            _labMedicineContext.SaveChanges();
            return Created(Request.Path, nurseDto);
        }

        return BadRequest("Há campos preenchidos de forma incorreta");
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult UpdateNurse([FromRoute] int id, [FromBody] NurseDto nurseDto)
    {
        NurseModel nurseModel = _labMedicineContext.Nurses.Find(id);

        if (nurseModel == null)
        {
            return NotFound("Enfermeiro não encontrado.");
        }

        nurseModel.Name = nurseDto.Name;
        nurseModel.Gender = nurseDto.Gender;
        nurseModel.BirthDate = nurseDto.BirthDate;
        nurseModel.CPF = nurseDto.CPF;
        nurseModel.EducationalInstitution = nurseDto.EducationalInstitution;
        nurseModel.CofenUf = nurseDto.CofenUf;

        if (TryValidateModel(nurseDto))
        {
            _labMedicineContext.Attach(nurseDto);
            _labMedicineContext.SaveChanges();
            return Ok(nurseDto);
        }

        return BadRequest("Há campos preenchidos de forma incorreta");
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteNurse([FromRoute] int id)
    {
        var nurseToDelete = _labMedicineContext.Nurses.Find(id);

        if (nurseToDelete == null)
        {
            return NotFound("Enfermeiro não encontrado.");
        }

        _labMedicineContext.Remove(nurseToDelete);
        _labMedicineContext.SaveChanges();
        return NoContent();
    }
}