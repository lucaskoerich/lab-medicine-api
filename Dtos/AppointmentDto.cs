using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_medicine_api.Dtos;

public class AppointmentDto
{
    [ForeignKey("PatientModel")]
    public int PatientId { get; set; }

    [ForeignKey("DoctorModel")]
    public int DoctorId { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Descrição da consulta não pode ser vazia.")]
    public string Description { get; set; }
}