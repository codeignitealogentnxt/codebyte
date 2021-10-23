using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel.Enum
{
    public enum Role
    {
        Admin,
        Manager,
    }

    public enum UpdateType
    {
        Challenge = 1,
        Appreciation = 2,
        Update = 3,
        Learning = 4,
        Achievement = 5
    }

    public enum Severity
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    public enum ProjectArea
    {
        Timeline = 1,
        Quality = 2,
        Customer = 3,
        Resources = 4
    }

    public enum Status
    {
        New = 1,
        OnTrack = 2,
        LowRisk = 3,
        MediumRisk = 4,
        HighRisk = 5
    }
}
