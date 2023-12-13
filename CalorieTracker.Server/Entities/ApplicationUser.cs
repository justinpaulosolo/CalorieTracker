using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Entities;

public class ApplicationUser : IdentityUser
{
    public ICollection<Diary> Diaries { get; set; } = new List<Diary>();
    public ICollection<SavedFood> SavedFoods { get; set; } = new List<SavedFood>();
}
