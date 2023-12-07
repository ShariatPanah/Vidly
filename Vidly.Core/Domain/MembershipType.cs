using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Core.Domain
{
    public class MembershipType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Sign Up Fee")]
        public short SignUpFee { get; set; }

        [Required]
        [Display(Name = "Duration In Months")]
        public byte DurationInMonths { get; set; }

        [Required]
        [Display(Name = "Discount Rate")]
        public byte DiscountRate { get; set; }


        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}
