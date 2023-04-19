using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_medicine_api.Models;

[Table("APPOINTMENTS")]
public class AppointmentModel
{
    [Column("ID")] [Key] public int Id { get; set; }

    [Column("ID_PATIENT")]
    [ForeignKey("PatientModel")]
    public string IdPatient { get; set; }

    [Column("ID_DOCTOR")]
    [ForeignKey("DoctorModel")]
    public string IdDoctor { get; set; }

    [Column("DESCRIPTION")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Descrição da consulta não pode ser vazia.")]
    public string Description { get; set; }
}