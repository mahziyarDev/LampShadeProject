using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory;

public class Index : PageModel
{
	public ProductCategorySearchModel SearchModel;
    public List<ProductCategoryViewModel> ProductCategories { get; set; }
    
    private readonly IProductCategoryApplication _productCategoryApplication;

    public Index(IProductCategoryApplication productCategoryApplication)
    {
        _productCategoryApplication = productCategoryApplication;
        
    }
    
    public void OnGet(ProductCategorySearchModel searchModel)
    {
        ProductCategories = _productCategoryApplication.Search(searchModel);
    }

	public IActionResult OnGetCreate()
	{
		return Partial("./Create", new CreateProductCategory());
	}

}