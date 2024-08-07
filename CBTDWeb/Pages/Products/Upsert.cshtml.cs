using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBTDWeb.Pages.Products;

public class UpsertModel : PageModel
{
    private readonly UnitOfWork _unitOfWork;

    [BindProperty]
    public Product objProduct { get; set; }

    public IEnumerable<SelectListItem> CategoryList { get; set; }
    public IEnumerable<SelectListItem> ManufacturerList { get; set; }

    public UpsertModel(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        objProduct = new Product();
        CategoryList = new List<SelectListItem>();
        ManufacturerList = new List<SelectListItem>();
    }

    public IActionResult OnGet(int? id)
    {
        objProduct = new Product();
        CategoryList = _unitOfWork.Category.GetAll()
            .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }
            );
        ManufacturerList = _unitOfWork.Manufacturer.GetAll()
            .Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.Id.ToString()
                }
            );

        if (id == null || id == 0) //create mode
        {
            return Page();
        }

        //edit mode

        if (id != 0)  //retreive product from DB
        {
            objProduct = _unitOfWork.Product.GetById(id);
        }

        if (objProduct == null) //maybe nothing returned
        {
            return NotFound();
        }
        return Page();
    }


}