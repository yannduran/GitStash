﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitStash.Common
{
    public interface IGitStashProjects
    {
        bool IsDirty { get; }
    }
}
