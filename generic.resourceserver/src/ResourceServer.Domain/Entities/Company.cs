using System;
using System.Collections.Generic;
using ResourceServer.SharedKernel;

namespace ResourceServer.BoundedContext.Entities
{
    public class Company : Entity<Guid>
    {
        public Company(Guid id) : base(id)
        {
        }

        public string Name { get; set; }

        public List<string> Teams { get; set; }
    }
}
