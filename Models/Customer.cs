using System.ComponentModel.DataAnnotations;
namespace VidlyNet7.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; } = null!;
        public bool IsSuscribedToNewsLetter { get; set; }
        public DateTime Birthdate { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

    }
}
