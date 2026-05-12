namespace InventoryApp.Data;

public class Inventory
{
    public Guid InventoryID { get; set; }
    public string OwnerID { get; set; }
    public string InventoryName { get; set; }
    public string Description { get; set; }
}