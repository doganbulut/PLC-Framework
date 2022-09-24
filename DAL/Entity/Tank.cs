using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace DAL.Entity
{

    [Alias("Tanks")]
    public class Tank : IHasId<int>
    {
        [AutoIncrement]// Creates Auto primary key
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [Index(Unique = true)] // Creates Unique Index
        public string Name { get; set; }
        
        [Required]
        [Default(typeof(int), "0")]
        public int Capacity { get; set; }

        [Required]
        [StringLength(40)]
        [Default(typeof(string), "")]
        public string Metarial { get; set; }

        [Ignore]
        public float Temp { get; set; }

        [References(typeof(Factory))] //Creates Foreign Key
        public int FactoryId { get; set; }
    }
}
