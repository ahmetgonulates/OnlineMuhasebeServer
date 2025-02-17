﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain
{
    public interface IContextService
    {
        DbContext CreateDbContextInstance(string companyId);
    }
}
