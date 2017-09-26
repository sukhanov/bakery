using System.ComponentModel;

namespace Bakery.Common.Infra.Enums
{
    /// <summary>
    /// Тип хлебобулочного изделия
    /// </summary>
    public enum BakeryType
    {
        [Description("Круассан")]
        [DisplayName("Круассан")]
        Croissant,

        [Description("Крендель")]
        [DisplayName("Крендель")]
        Pretzel,

        [Description("Багет")]
        [DisplayName("Багет")]
        Baguette,

        [Description("Сметанник")]
        [DisplayName("Сметанник")]
        SourCream,

        [Description("Батон")]
        [DisplayName("Батон")]
        Loaf
    }
}