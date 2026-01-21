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
    public class ElevesController : Controller
    {
        private readonly IEleveApiService _elevesApiService;
        private readonly IWebHostEnvironment _env;
        public ElevesController(IEleveApiService elevesApiService, IWebHostEnvironment env)
        {
            _elevesApiService = elevesApiService;
            _env = env;
        }

        //GET : /Eleves
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, string search = "")
        {
            var filter = new PaginationFilter(page, pageSize);

            PagedResponse<List<EleveViewModel>> result=  await _elevesApiService.GetAllAsync(search, filter);
            

            //Pour eviter des erreurs null
            if (result.Data == null)
                return View(new List<EleveViewModel>());

            

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
        

        //GET : /Eleves/Details/5
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var result = await _elevesApiService.GetByIdAsync(id);
            if (result.Data == null)
                return NotFound();
            return View(result.Data);
        }

        //GET : /Eleves/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST : /Eleves/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EleveViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Gestion de la photo
            if (model.PhotoFile != null)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "eleves");
                if (!Directory.Exists(uploadDir))
                    Directory.CreateDirectory(uploadDir);

                string fileName = Guid.NewGuid() + Path.GetExtension(model.PhotoFile.FileName);
                string filePath = Path.Combine(uploadDir, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.PhotoFile.CopyToAsync(stream);
                }

                model.PhotoEleveUrl = "/eleves/" + fileName;
            }

            var result = await _elevesApiService.AddAsync(model);

            if (!result.Success)
            {
                // S’il y a des erreurs provenant du backend
                if (result.Errors != null && result.Errors.Any())
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        // clé vide "" pour erreur globale
                        ModelState.AddModelError(errorMessage,result.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.Message ?? "Erreur lors de la création.");
                }

                // Retourne la vue avec ModelState rempli pour afficher les erreurs
                return View(model);
            }

            // Si succès
            return RedirectToAction(nameof(Index));
        }

        //GET : Eleves/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _elevesApiService.GetByIdAsync(id);
            if (result.Data == null)
                return NotFound();
            return View(result.Data);
        }

        //POST : Eleves/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,EleveViewModel model)
        {


            if (!ModelState.IsValid)
                return View(model);
            //Gestion de la photo
            if (model.PhotoFile != null)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "eleves");
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
                model.PhotoEleveUrl = "/eleves/" + fileName;
            }
            else
            {
                // **Aucune nouvelle photo** => récupérer l'ancienne URL depuis la base
                var existing = await _elevesApiService.GetByIdAsync(id);
                if (existing.Success && existing.Data != null)
                {
                    model.PhotoEleveUrl = existing.Data.PhotoEleveUrl;
                }
            }
            var result = await _elevesApiService.UpdateAsync(id, model);
            if (result.Success)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", result.Message ?? "Erreur lors de la modification.");
            return View(model);
        }

        //GET : /Eleves/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _elevesApiService.GetByIdAsync(id);
            if (result.Data == null)
                return NotFound();

            return View(result.Data);
        }

        //POST : /Eleves/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _elevesApiService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
