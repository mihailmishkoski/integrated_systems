using System.ComponentModel.DataAnnotations;

namespace EshopAdminApplication.Web.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Rating { get; set; }
        public virtual EShopApplicationUser? CreatedBy { get; set; }
        public virtual ICollection<TicketInShoppingCart>? ProductsInShoppingCart { get; set; }
        public ICollection<TicketInOrder>? ProductInOrders { get; set; }
    }
}
