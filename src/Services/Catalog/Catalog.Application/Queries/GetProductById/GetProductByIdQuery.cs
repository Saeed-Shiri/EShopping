﻿using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries.GetProductById;
public class GetProductByIdQuery : IRequest<ProductResponse>
{
    public GetProductByIdQuery(string id)
    {
        Id = id;
    }
    public string Id { get; init; }
}
