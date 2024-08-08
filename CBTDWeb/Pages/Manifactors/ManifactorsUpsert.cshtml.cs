using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manifactors
{
    public class ManifactorsUpsertModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]  //synchronizes form fields with values in code behind
        public Manufacturer? ObjManifactor { get; set; }

        public ManifactorsUpsertModel(UnitOfWork unitOfWork)  //dependency injection
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)

        {
            ObjManifactor = new Manufacturer();

            //am I in edit mode?
            if (id != 0)
            {
                ObjManifactor = _unitOfWork.Manufacturer.GetById(id);
            }

            if (ObjManifactor == null)  //nothing found in DB
            {
                return NotFound();   //built in page
            }

            //assuming I'm in create mode
            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //if this is a new category
            if (ObjManifactor.Id == 0)
            {
                _unitOfWork.Manufacturer.Add(ObjManifactor);
                TempData["success"] = "Category added Successfully";
            }
            //if category exists
            else
            {
                _unitOfWork.Manufacturer.Update(ObjManifactor);
                TempData["success"] = "Category updated Successfully";
            }
            _unitOfWork.Commit();

            return RedirectToPage("./ManifactorsIndex");
        }


    }
}
