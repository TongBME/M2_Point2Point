﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFTAICommunicationLib
{
    public interface IFFTAICommunicationV2DriverInterfaceObserver
    {
        FunctionResult ModelUpdateHandle(FFTAICommunicationV2DriverInterfaceModel model);
    }
}
