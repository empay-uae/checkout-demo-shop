using System.ComponentModel.DataAnnotations;

namespace Emcredit.Empay.Models.Orders
{
    public class OrderRequestPurchaseUnitPayee
    {
        [Required]
        [MaxLength(16)]
        public string BillerId { get; set; }
    }
}