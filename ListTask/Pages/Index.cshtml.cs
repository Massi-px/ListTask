// IndexModel.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ListTask.Models;
using RazorAppDbContext.Data;
using System.Linq;

public class IndexModel : PageModel
{
    private readonly AppDbContext _dbContext;

    public IndexModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        Tasks = new List<TaskItem>();
    }

    [BindProperty]
    public List<TaskItem> Tasks { get; set; }

    [BindProperty]
    public int TaskId { get; set; }

    public void OnGet()
    {
        Tasks = _dbContext.Task.ToList();
    }

    public IActionResult OnPost()
    {
        // Récupérer la tâche à partir de l'ID soumis
        var taskToUpdate = _dbContext.Task.FirstOrDefault(t => t.id == TaskId);
        if (taskToUpdate == null)
        {
            // Tâche non trouvée, rediriger vers la page d'erreur ou effectuer un traitement approprié
            return RedirectToPage("/Error");
        }

        // Mettre à jour les propriétés de la tâche avec les valeurs soumises depuis le formulaire
        taskToUpdate.name = Request.Form["taskName"];
        taskToUpdate.description = Request.Form["taskDescription"];
        taskToUpdate.finished = bool.Parse(Request.Form["taskStatus"]);

        // Enregistrer les modifications dans la base de données
        _dbContext.SaveChanges();

        // Rediriger vers la même page (Index.cshtml) après la mise à jour
        return RedirectToPage("/Index");
    }
}