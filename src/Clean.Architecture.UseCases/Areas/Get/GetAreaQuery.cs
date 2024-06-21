using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Areas.Get;
public record GetAreaQuery(int areaId) : IQuery<Result<AreaDTO>>
{
}
