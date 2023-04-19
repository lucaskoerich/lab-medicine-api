using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Attributes;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ClinicalSpecialization
{
    [EnumMember(Value = "CLINICO_GERAL")]
    [Display("Clínico Geral")]
    CLINICO_GERAL,
    [EnumMember(Value = "ANESTESISTA")]
    [Display("Anestesista")]
    ANESTESISTA,
    [EnumMember(Value = "DERMATOLOGIA")]
    [Display("Dermatologia")]
    DERMATOLOGIA,
    [EnumMember(Value = "GINECOLOGIA")]
    [Display("Ginecologia")]
    GINECOLOGIA,
    [EnumMember(Value = "NEUROLOGIA")]
    [Display("Neurologia")]
    NEUROLOGIA,
    [EnumMember(Value = "PEDIATRIA")]
    [Display("Pediatria")]
    PEDIATRIA,
    [EnumMember(Value = "PSIQUIATRIA")]
    [Display("Psiquiatria")]
    PSIQUIATRIA,
    [EnumMember(Value = "ORTOPEDIA")]
    [Display("Ortopedia")]
    ORTOPEDIA
}