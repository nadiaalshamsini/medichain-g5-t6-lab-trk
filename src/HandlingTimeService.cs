 public static string CalculateHandlingTime(int startTime, int endTime, string sampleType)
    {
        int duration = endTime - startTime;

        if (sampleType == "urgent")
        {
            if (duration > 2) return "Delayed: Urgent sample too long";
            else return "On Time: Urgent sample OK";
        }
        else if (sampleType == "normal")
        {
            if (duration > 5) return "Delayed: Normal sample too long";
            else return "On Time: Normal sample OK";
        }
        else
        {
            return "Error: Unknown type";
        }
    }
