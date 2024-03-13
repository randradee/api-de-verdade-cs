using System.ComponentModel;

namespace api_de_verdade.Domain.Models.Enums
{
    public enum EUnitOfMeasurement : byte
    {
        [Description("UN")]
        Unity,

        [Description("MG")]
        Milligram,

        [Description("G")]
        Gram,

        [Description("KG")]
        Kilogram,

        [Description("L")]
        Liter
    }
}
