using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace DAL.Entity
{
    [Alias("Factories")]
    public class Factory : IHasId<int>
    {
        [AutoIncrement]// Creates Auto primary key
        public int Id { get; set; }

        [Alias("FactoryName")]
        [Required]
        [StringLength(40)]
        [Index(Unique = true)] // Creates Unique Index
        public string Name { get; set; }

        [Ignore]
        public IList<Tank> Tanks { get; set; }
    }
}
