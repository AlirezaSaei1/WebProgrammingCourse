using Microsoft.AspNetCore.Mvc;
using WebApplicationProject.Models;

namespace WebApplicationProject.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Validate user credentials
        if (IsValidUser(username, password))
        {
            return RedirectToAction("Index", "Home");
        }
        
        ViewBag.ErrorMessage = "Invalid username or password.";
        return View();
    }
    
    [HttpGet]
    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Signup(User user)
    {
        // Save the user to the data store or user repository
        if (ModelState.IsValid)
        {
            // Add: userRepository.Add(user);

            // Redirect to login page after successful signup
            return RedirectToAction("Login");
        }

        // If the input is not valid, return the signup view with validation errors
        return View(user);
    }
    
    private bool IsValidUser(string username, string password)
    {
        var is_valid = false;
        
        // Check the user credentials against the stored user data
        // Example: return userRepository.ValidateUser(username, password);
        
        return is_valid;
    }
}