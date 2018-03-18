﻿using System;
using System.Linq;
using YUTPLAT.Models;

namespace YUTPLAT.Repositories.Interface
{
    public interface IIndicadorAutomaticoRepository : IDisposable
    {
        IQueryable<IndicadorAutomatico> Todos();        
    }
}