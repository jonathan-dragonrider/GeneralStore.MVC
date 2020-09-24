using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    // Defined as a Customer purchasing a Product
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        [Display(Name = "Purchase Quantity")]
        public int PurchaseQty { get; set; }

        [Required]
        [Display(Name = "Transaction Date")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}