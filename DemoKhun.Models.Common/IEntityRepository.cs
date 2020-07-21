using System;
using System.Collections.Generic;

namespace DemoKhun.Models.Common
{
    public interface IEntityRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
    }
}
