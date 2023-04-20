using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace lab_medicine_api.Models;

[Table("APPOINTMENTS")]
public class AppointmentModel
{
    [Column("ID")] [Key] public int Id { get; set; }

    [Column("ID_PATIENT")]
    [ForeignKey("Patient")]
    public int PatientModelId { get; set; }

    [Column("ID_DOCTOR")]
    [ForeignKey("Doctor")]
    public int DoctorModelId { get; set; }

    [Column("DESCRIPTION")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Descrição da consulta não pode ser vazia.")]
    public string Description { get; set; }

    [JsonIgnore] public PatientModel Patient { get; set; }

    [JsonIgnore] public DoctorModel Doctor { get; set; }
}