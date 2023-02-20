﻿using Qynon.AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qynon.AdventureWorks.Infrastructure.Data.EfCore
{
    public interface IPistaCorridaDao : ICommand<PistaCorrida>, IQuery<PistaCorrida>
    {
    }
}
