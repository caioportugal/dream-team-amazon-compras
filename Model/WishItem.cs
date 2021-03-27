using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Purchases.Model
{
    public class WishItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("WishId")]
        public int WishId { get; set; }
        public int ProductId { get; set; }

        public virtual Wish Wish { get; set; }
    }
}
