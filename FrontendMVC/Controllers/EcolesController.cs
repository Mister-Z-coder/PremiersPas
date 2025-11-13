using FrontendMVC.Models.Filters;
using FrontendMVC.Models.ViewModels;
using FrontendMVC.Models.Wrappers;
using FrontendMVC.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC.Controllers
{
    public class EcolesController : Controller
    {
        private readonly IEcoleApiService _ecoleApiService;
        private readonly IWebHostEnvironment _env;
        public EcolesController(IEcoleApiService ecoleApiService, IWebHostEnvironment env)
        {
            _ecoleApiService = ecoleApiService;
            _env = env;
        }

        //GET : /Ecoles
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var filter = new PaginationFilter(page, pageSize);

            PagedResponse<List<EcoleViewModel>> result;

            if (!string.IsNullOrEmpty(search))
                result = await _ecoleApiService.GetBySearchStringAsync(search, filter);
            else
                result = await _ecoleApiService.GetAllAsync(filter);

            //Pour eviter des erreurs null
            if (result.Data == null)
                return View(new List<EcoleViewModel>());

            

            ViewBag.CurrentPage = result.PageNumber;
            ViewBag.PageSize = result.PageSize;
            ViewBag.FirstPage = result.FirstPage;
            ViewBag.LastPage = result.LastPage;
            ViewBag.NextPage = result.NextPage;
            ViewBag.PreviousPage = result.PreviousPage;
            ViewBag.TotalPages = result.TotalPages;

            ViewData["CurrentFilter"] = search;

            return View(result.Data);
        }
        

        //GET : /Ecoles/Details/5
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var result = await _ecoleApiService.GetByIdAsync(id);
            if (result.Data == null)
                return NotFound();
            return View(result.Data);
        }

        //GET : /Ecoles/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST : /Ecoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EcoleViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //Gestion de la photo
            if(model.PhotoFile != null)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "ecoles");
                
                //Le créer s'il n'existe pas
                if (!Directory.Exists(uploadDir))
                    Directory.CreateDirectory(uploadDir);

                //Generer le nom du fichier
                string fileName = Guid.NewGuid() + Path.GetExtension(model.PhotoFile.FileName);
                string filePath = Path.Combine(uploadDir, fileName);

                //Enregistrement du fichier sur le serveur
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.PhotoFile.CopyToAsync(stream);
                }

                model.PhotoEcoleUrl = "/ecoles/" + fileName;
            }
            
            var result = await _ecoleApiService.AddAsync(model);

            if(result.Success)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", result.Message ?? "Erreur lors de la création.");
            return View(model);
        }

        //GET : Ecoles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _ecoleApiService.GetByIdAsync(id);
            if (result.Data == null)
                return NotFound();
            return View(result.Data);
        }

        //POST : Ecoles/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,EcoleViewModel model)
        {


            if (!ModelState.IsValid)
                return View(model);
            //Gestion de la photo
            if (model.PhotoFile != null)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "ecoles");
                //Le créer s'il n'existe pas
                if (!Directory.Exists(uploadDir))
                    Directory.CreateDirectory(uploadDir);

                //Generer le nom du fichier
                string fileName = Guid.NewGuid() + Path.GetExtension(model.PhotoFile.FileName);
                string filePath = Path.Combine(uploadDir, fileName);

                //Enregistrement du fichier sur le serveur
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.PhotoFile.CopyToAsync(stream);
                }
                model.PhotoEcoleUrl = "/ecoles/" + fileName;
            }
            else
            {
                // **Aucune nouvelle photo** => récupérer l'ancienne URL depuis la base
                var existing = await _ecoleApiService.GetByIdAsync(id);
                if (existing.Success && existing.Data != null)
                {
                    model.PhotoEcoleUrl = existing.Data.PhotoEcoleUrl;
                }
            }
            var result = await _ecoleApiService.UpdateAsync(id, model);
            if (result.Success)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", result.Message ?? "Erreur lors de la modification.");
            return View(model);
        }

        //GET : /Ecoles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ecoleApiService.GetByIdAsync(id);
            if (result.Data == null)
                return NotFound();

            return View(result.Data);
        }

        //POST : /Ecoles/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ecoleApiService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
