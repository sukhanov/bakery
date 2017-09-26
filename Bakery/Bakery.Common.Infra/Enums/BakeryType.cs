using System.ComponentModel;

namespace Bakery.Common.Infra.Enums
{
    /// <summary>
    /// Тип хлебобулочного изделия
    /// </summary>
    public enum BakeryType
    {
        [Description("Круассан")]
        Croissant,

        [Description("Крендель")]
        Pretzel,

        [Description("Багет")]
        Baguette,

        [Description("Сметанник")]
        SourCream,

        [Description("Батон")]
        Loaf
    }
}