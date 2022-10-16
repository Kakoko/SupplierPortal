using Microsoft.EntityFrameworkCore;
using SupplierPortal.Server.Data.Context;
using SupplierPortal.Shared.Models;

namespace SupplierPortal.Server.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SupplierDbContext _supplierDbContext;

        public SupplierRepository(SupplierDbContext supplierDbContext)
        {
            _supplierDbContext = supplierDbContext ?? throw new ArgumentNullException(nameof(supplierDbContext));
        }

        public async Task AddSupplier(Supplier supplier)
        {
            try
            {
                supplier.Id = Guid.NewGuid();
                _supplierDbContext.Suppliers.Add(supplier);
                _supplierDbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Failed to create supplier");
            }
        }

        public async Task DeleteSupplier(Guid id)
        {
            try
            {
                var supplier = await _supplierDbContext.Suppliers.FirstOrDefaultAsync(u => u.Id == id);
                if (supplier != null)
                {
                   _supplierDbContext.Suppliers.Remove(supplier);
                    _supplierDbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("Supplier does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to delete supplier");
            }
        }

        public async Task<Supplier> GetSupplier(Guid id)
        {
            try
            {
                var supplier = await _supplierDbContext.Suppliers.FirstOrDefaultAsync(u => u.Id == id);

                if(supplier != null)
                {
                    return supplier;
                }
                else
                {
                    throw new ArgumentNullException("Supplier does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to get supplier");
            }
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            try
            {
                var suppliers = await _supplierDbContext.Suppliers.ToListAsync();
                return suppliers;
            }
            catch (Exception)
            {

                throw new Exception("Failed to get suppliers");
            }
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            try
            {
                var supplierToEdit = await _supplierDbContext.Suppliers.FirstOrDefaultAsync(u => u.Id == supplier.Id);

                if (supplierToEdit != null)
                {
                    supplierToEdit.Name = supplier.Name;
                    supplierToEdit.Email = supplier.Email;
                    supplierToEdit.Company = supplier.Company;

                    _supplierDbContext.Suppliers.Update(supplierToEdit);
                    _supplierDbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("Supplier does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to update supplier");
            }
        }
    }
}
