using System.ComponentModel.DataAnnotations;

namespace VidlyNet7.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; } = null!;


    }
}
