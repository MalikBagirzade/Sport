
using Sport.Entites;
using System.Collections.Generic;

namespace Sport.IRespoitory
{
    public interface IGateShapeProductRepository
    {
        IEnumerable<GateShapeProduct> GetAllProducts();
        GateShapeProduct GetProductById(int id);
        void AddProduct(GateShapeProduct product);
        void UpdateProduct(GateShapeProduct product);
        void DeleteProduct(int id);
    }
}
