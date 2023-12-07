using Vidly.Core.Validations;

namespace Vidly.Core.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
    }
}
