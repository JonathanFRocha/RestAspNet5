using System.ComponentModel.DataAnnotations.Schema;

namespace RestPerson.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
