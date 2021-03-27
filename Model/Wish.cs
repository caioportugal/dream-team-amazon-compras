using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amazon.Purchases.Model
{
    public class Wish
    {
        public Wish()
        {
            WishItem = new HashSet<WishItem>();
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<WishItem> WishItem { get; set; }
    }
}
