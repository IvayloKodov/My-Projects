namespace CameraBazaar.Web.Common.Enums
{
    using System.ComponentModel;

    public enum LightMeteringType
    {
        Spot = 0,
        [Description("Center-Weighted")]
        CenterWeighted = 1,
        Evaluative = 2
    }
}