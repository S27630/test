using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

[Table("Order")]
public class Order
{
    [Key]
    [Column("ID")]
    public int OrderID { get; set; }
    
    [Column("CreatedAt")]
    public DateTime OrderCreatedAt { get; set; }
    
    [Column("FulfilledAt")]
    public DateTime? OrderFulfilledAt { get; set; }
    
    [ForeignKey("Client")]
    [Column("ClientID")]
    public int ClientId { get; set; }
    
    [ForeignKey("Status")]
    [Column("StatusID")]
    public int StatusId { get; set; }
    
    public Client Client { get; set; }
    public Status Status { get; set; }
    public IEnumerable<Product_Order> Product_Order { get; set; }

}