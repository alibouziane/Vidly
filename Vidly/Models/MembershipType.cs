using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Ajax.Utilities;

namespace Vidly.Models
{
    public class MembershipType
    {
        public Byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}