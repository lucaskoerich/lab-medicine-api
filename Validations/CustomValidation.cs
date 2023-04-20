using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using lab_medicine_api.Enums;

namespace lab_medicine_api.Validations;

public class CustomValidation
{
    public sealed class AttendanceStatusConverter : JsonConverter<AttendanceStatus>
    {
        public override AttendanceStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            
            //verifica se a string inserida é uma enum válida
            var value = reader.GetString();
            if (!Enum.TryParse<AttendanceStatus>(value, out var result))
            {
                throw new JsonException($"O status informado é inválido. Os valores válidos para Status de Atendimento são: " +
                                        string.Join(", ", Enum.GetNames(typeof(AttendanceStatus))));
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, AttendanceStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public sealed class StatusInSystemConverter : JsonConverter<StatusInSystem>
    {
        public override StatusInSystem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            
            //verifica se a string inserida é uma enum válida
            var value = reader.GetString();
            if (!Enum.TryParse<StatusInSystem>(value, out var result))
            {
                throw new JsonException($"O estado informado é inválido. Os valores válidos para Estado no Sistema são: ATIVO ou INATIVO ");
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, StatusInSystem value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    public sealed class ClinicalSpecializationConverter : JsonConverter<ClinicalSpecialization>
    {
        public override ClinicalSpecialization Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            
            //verifica se a string inserida é uma enum válida
            var value = reader.GetString();
            if (!Enum.TryParse<ClinicalSpecialization>(value, out var result))
            {
                throw new JsonException($"A especialização informada é inválida. Os valores válidos Especialização Clínica são: " +
                                        string.Join(", ", Enum.GetNames(typeof(ClinicalSpecialization))));
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, ClinicalSpecialization value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
    
}