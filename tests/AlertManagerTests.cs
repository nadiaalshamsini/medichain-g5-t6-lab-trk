using AlertManagerLib;
using Xunit;
namespace AlertManagerTests;

public class AlertManagerTests
{
    private readonly AlertManager _alertManager = new();

    [Fact]
    public void GetAlertResponsibility_WhenStageIsEstlam_ReturnsFnyAlEstlam()
    {
        string stage = "استلام";
        string expected = "فني الاستلام";
        string result = _alertManager.GetAlertResponsibility(stage);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAlertResponsibility_WhenStageIsTawzee_ReturnsFnyAlTawzee()
    {
        string stage = "توزيع";
        string expected = "فني التوزيع";
        string result = _alertManager.GetAlertResponsibility(stage);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAlertResponsibility_WhenStageIsTahleel_ReturnsFnyAlMukhtabar()
    {
        string stage = "تحليل";
        string expected = "فني المختبر";
        string result = _alertManager.GetAlertResponsibility(stage);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAlertResponsibility_WhenStageIsMurajaa_ReturnsAkhsaiAlMukhtabar()
    {
        string stage = "مراجعة";
        string expected = "أخصائي المختبر";
        string result = _alertManager.GetAlertResponsibility(stage);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAlertResponsibility_WhenStageIsAatmadTiby_ReturnsTabeebMukhary()
    {
        string stage = "اعتماد طبي";
        string expected = "الطبيب المخبري";
        string result = _alertManager.GetAlertResponsibility(stage);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAlertResponsibility_WhenStageIsTasleem_ReturnsFnyAlTasleem()
    {
        string stage = "تسليم";
        string expected = "فني التسليم";
        string result = _alertManager.GetAlertResponsibility(stage);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAlertResponsibility_WhenStageIsUnknown_ReturnsGhyrMuhadad()
    {
        string stage = "مرحلة غير موجودة";
        string expected = "غير محدد";
        string result = _alertManager.GetAlertResponsibility(stage);
        Assert.Equal(expected, result);
    }
}
