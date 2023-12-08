using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    public class Rental
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
