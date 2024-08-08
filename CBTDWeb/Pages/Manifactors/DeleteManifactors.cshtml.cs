using DataAccess;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manifactors
{
    public class DeleteManifactorsModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]  //synchronizes form fields with values in code behind
        public Manufacturer? objManifactor { get; set; }

        public DeleteManifactorsModel(UnitOfWork unitOfWork)  //dependency injection
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)

        {
            objManifactor = new Manufacturer();

            //am I in edit mode?
            if (id != 0)
            {
                objManifactor = _unitOfWork.Manufacturer.GetById(id);
            }

            if (objManifactor == null)  //nothing found in DB
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
            
            _unitOfWork.Manufacturer.Delete(objManifactor);
            TempData["success"] = "Category Deleted Successfully";
            _unitOfWork.Commit();

            return RedirectToPage("./ManifactorsIndex");
        }

    }
}