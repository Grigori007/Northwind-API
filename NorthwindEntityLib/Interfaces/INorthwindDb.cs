﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindEntityLib
{
    public interface INorthwindDb
    {
        dynamic EntityId { get; }
    }
}
