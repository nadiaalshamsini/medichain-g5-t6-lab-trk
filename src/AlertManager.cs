namespace AlertManagerLib;

public class AlertManager
{
    public string GetAlertResponsibility(string stageName)
    {
        if (stageName == "استلام")
        {
            return "فني الاستلام";
        }
        else if (stageName == "توزيع")
        {
            return "فني التوزيع";
        }
        else if (stageName == "تحليل")
        {
            return "فني المختبر";
        }
        else if (stageName == "مراجعة")
        {
            return "أخصائي المختبر";
        }
        else if (stageName == "اعتماد طبي")
        {
            return "الطبيب المخبري";
        }
        else if (stageName == "تسليم")
        {
            return "فني التسليم";
        }
        else
        {
            return "غير محدد";
        }
    }
}
