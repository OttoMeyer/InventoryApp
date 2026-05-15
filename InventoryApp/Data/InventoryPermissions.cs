using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace InventoryApp.Data;

public class InventoryPermissions
{
    public Guid Id { get; set; }
    
    [ForeignKey("InventoryId")]
    public Inventory Inventory { get; set; }
    
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
    
    public string Permission { get; set; }

}