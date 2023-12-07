using System.ComponentModel.DataAnnotations;
using Vidly.Core.Validations;

namespace Vidly.Core.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Subscribed to Newsletter")]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }
    }
}
