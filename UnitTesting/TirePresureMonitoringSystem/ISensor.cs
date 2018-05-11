using System;
using System.Collections.Generic;
using System.Text;

namespace TirePresureMonitoringSystem
{
    public interface ISensor
    {
        double PopNextPressurePsiValue();
       
    }
}
