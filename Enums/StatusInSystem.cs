using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Attributes;

namespace lab_medicine_api.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusInSystem
{
    [EnumMember(Value = "ATIVO")]
    [Display("Ativo")]
    ATIVO,
    [EnumMember(Value = "INATIVO")]
    [Display("Inativo")]
    INATIVO
}