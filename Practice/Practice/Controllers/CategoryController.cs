﻿using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
        
    public IActionResult Index()
    {
        IEnumerable<Category>? categoryList = _db.Categories;
        return View(categoryList);
    }
    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }

        if (!ModelState.IsValid) return View(obj);
        _db.Categories?.Add(obj);
        _db.SaveChanges();
        TempData["success"] = "Category created successfully";
        return RedirectToAction("Index");
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if(id==null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories?.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories?.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories?.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Categories?.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Categories?.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
        
    }
}