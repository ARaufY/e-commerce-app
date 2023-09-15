using System.Linq.Expressions;
using core.Entities;

namespace core;

public class ProductsWithTypesAndBrandsSpecs : BaseSpecification<Product>
{
    public ProductsWithTypesAndBrandsSpecs()
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }

    public ProductsWithTypesAndBrandsSpecs(int id) : base(x=> x.Id == id)
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}
