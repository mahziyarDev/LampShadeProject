using System.Linq.Expressions;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class ProductCategoryRepository : RepositoryBase<long,ProductCategory> ,IProductCategoryRepository
{
    private readonly ShopContext _context;

    public ProductCategoryRepository(ShopContext context) : base(context)
    {
        _context = context;
    }
    public EditProductCategory GetDetails(long id)
    {
        return _context.ProductCategories.Select(x => new EditProductCategory
        {
            Name = x.Name,
            Description = x.Description,
            Keywords = x.Keywords,
            PictureTitle = x.PictureTitle,
            Picture = x.Picture,
            Slug = x.Slug,
            MetaDescription = x.MetaDescription,
            PictureAlt = x.PictureAlt,
            Id = x.Id
        }).FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
    {
        

        var query = _context.ProductCategories
            .Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToString(),
                ProductCount = 10,
            });
        
        if (!string.IsNullOrEmpty(searchModel.Name))
            query =query.Where(x => x.Name.Contains(searchModel.Name));
        

        return query.OrderByDescending(x => x.Id).ToList();
    }
}