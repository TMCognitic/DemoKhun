using DemoKhun.Models.Client.Entities;
using DemoKhun.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoKhun.Models.Client.Repositories
{
    public class EntityRepository : IEntityRepository<Entity>
    {
        public IEnumerable<Entity> Get()
        {
            yield return new Entity("Entity 1 : Lorem ipsum,");
            yield return new Entity("Entity 2 : dolor sit amet,");
            yield return new Entity("Entity 3 : consectetur adipiscing elit.");
            yield return new Entity("Entity 4 : Vivamus pretium porttitor congue.");
        }
    }
}
