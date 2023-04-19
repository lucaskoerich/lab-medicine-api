using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Attributes;

namespace lab_medicine_api.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AttendanceStatus
{
    [EnumMember(Value = "AGUARDANDO_ATENDIMENTO")]
    [Display("Aguardando Atendimento")]
    AGUARDANDO_ATENDIMENTO,
    
    [EnumMember(Value = "EM_ATENDIMENTO")]
    [Display("Em Atendimento")]
    EM_ATENDIMENTO,
    
    [EnumMember(Value = "ATENDIDO")]
    [Display("Atendido")]
    ATENDIDO,
    
    [EnumMember(Value = "NAO_ATENDIDO")]
    [Display("Não Atendido")]
    NAO_ATENDIDO
}