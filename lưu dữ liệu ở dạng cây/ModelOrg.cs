using System;

namespace MyApp
{
    public class ModelOrg
    {
        public long Id { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

        public long? ParentId { get; set; }
    }
}