﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.Dtos;

namespace Market.Application.Interfaces
{
    public interface ICategoryService : IApplicationService<CategoryReadDto, ProductWriteDto>
    {
    }
}
