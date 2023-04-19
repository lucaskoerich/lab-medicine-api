using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_medicine_api.Dtos;

public class AppointmentDto
{
    [ForeignKey("PatientModel")]
    public string CpfPatient { get; set; }

    [ForeignKey("DoctorModel")]
    public string CpfDoctor { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Descrição da consulta não pode ser vazia.")]
    public string Description { get; set; }
}