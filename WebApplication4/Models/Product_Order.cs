using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

[Table("Product_Order")]
[PrimaryKey("ProductID", "OrderID")]
public class Product_Order
{
    [ForeignKey("Product")]
    [Column("ProductID")]
    public int ProductID { get; set; }
    
    [ForeignKey("Order")]
    [Column("OrderID")]
    public int OrderID { get; set; }
    
    public Product Product { get; set; }
    
    public Order Order { get; set; }
    
    public int Amount { get; set; }
}