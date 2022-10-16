using SupplierPortal.Shared.Models;

namespace SupplierPortal.Server.Data.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSuppliers();
        Task<Supplier> GetSupplier(Guid id);
        Task AddSupplier(Supplier supplier);
        Task DeleteSupplier(Guid id);
        Task UpdateSupplier(Supplier supplier);

    }
}
