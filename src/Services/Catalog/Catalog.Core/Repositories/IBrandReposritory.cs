﻿using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IBrandReposritory
{
    Task<IEnumerable<ProductBrand>> GetAllBrands();
}