using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    // GET: Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // TODO: Save the user to the database
            // For example: Add the user to an identity store or custom database

            TempData["Message"] = "Registration successful!";
            return RedirectToAction("Index", "Home");
        }

        // If we got this far, something failed; redisplay the form
        return View(model);
    }
}
