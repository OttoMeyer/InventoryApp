using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Data;

public class InventoryPermissionManager
{
    private readonly ApplicationDbContext _dbContext;
    public InventoryPermissionManager(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<string> GetPermissionAsync(Inventory inventory, ClaimsPrincipal user)
    {
        var ownerId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (ownerId == null) return "";
        var perm = await _dbContext.InventoryPermissions
            .Where(p => p.Inventory == inventory && p.User.Id == ownerId)
            .Select(p => p.Permission)
            .FirstOrDefaultAsync();
        return perm ?? "";
    }
}