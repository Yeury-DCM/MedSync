
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MedSync.Core.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Pendiente de consulta" )]
        PendingConsultation,

        [Display(Name = "Pendiente de resultado")]
        PendigResult,
        Pending,
        Completed
    }

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString())!;
            DisplayAttribute attribute = field!.GetCustomAttribute<DisplayAttribute>()!;

            return attribute != null ? attribute.Name : value.ToString();
        }
    }
}
