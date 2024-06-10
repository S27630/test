using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

[Table("Product")]
public class Product
{
    [Key]
    [Column("ID")]
    public int ProductID { get; set; }
    
    [Column("Name")]
    [MaxLength(50)]
    public string ProductName { get; set; }
    
    [Column("Price", TypeName = "numeric(10,2)")] // corrected syntax
    public double ProductPrice {get; set; }
 
    public IEnumerable<Product_Order> Product_Order { get; set; }

}