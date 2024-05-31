using Microsoft.EntityFrameworkCore;
using Sport.Entites;
using Sport.IRespoitory;
using System;
using System.Collections.Generic;

namespace Sport.Repository
{
    public class GateShapeProductRepository : IGateShapeProductRepository
    {
        private readonly AppDbContext _context;

        public GateShapeProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddProduct(GateShapeProduct product)
        {
            _context.GateShapeProducts.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.GateShapeProducts.Find(id);
            if (product != null)
            {
                _context.GateShapeProducts.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<GateShapeProduct> GetAllProducts()
        {
            return _context.GateShapeProducts;
        }

        public GateShapeProduct GetProductById(int id)
        {
            return _context.GateShapeProducts.Find(id);
        }

        public void UpdateProduct(GateShapeProduct product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
