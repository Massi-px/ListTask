/*Création du model TaskItem qui représente une tache de la table task dans ma bdd*/

namespace ListTask.Models;

public class TaskItem
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateTime creation_date { get; set; }
    public Boolean finished { get; set; }
}