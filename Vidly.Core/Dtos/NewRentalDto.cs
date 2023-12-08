namespace Vidly.Core.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public IList<int> MovieIds { get; set; }
    }
}
