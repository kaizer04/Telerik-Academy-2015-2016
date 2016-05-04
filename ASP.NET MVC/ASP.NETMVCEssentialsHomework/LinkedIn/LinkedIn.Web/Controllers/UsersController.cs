namespace LinkedIn.Web.Controllers
{
    using System.Data.Entity;
    using LinkedIn.Data;
    using System.Web.Mvc;
    using System.Linq;
    using LinkedIn.Web.ViewModels;
    using LinkedIn.Models; 


    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ILinkedInData data) 
            : base(data)
        {
        }

        public ActionResult Index(string username)
        {
            //var user = this.Data.Users
            //    .All()
            //    .FirstOrDefault(x => x.UserName == username);
            var user = this.Data.Users
               .All()
               .Include(x => x.Certifications)
               .Include(x => x.Skills)
               .Include("Skills.Skill")
               .Include("Skills.Skill.User")
               .Where(x => x.UserName == username)
               .Select(UserViewModel.ViewModel)
               .FirstOrDefault();

            if (user == null)
            {
                return this.HttpNotFound("User does not exist!");
            }

            //var userViewModel = UserViewModel.FromModel(user);

            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndorseUserForSkill(int id)
        {
            var hasExistingEndorcement =
                this.Data.Endorcements
                .All()
                .Any(x => x.UserId == this.UserProfile.Id && x.UserSkillId == id);
            if (!hasExistingEndorcement)
            {
                this.Data.Endorcements.Add(new Endorcement 
                {
                    UserId = this.UserProfile.Id,
                    UserSkillId = id
                });
                this.Data.SaveChanges();
            }

            var endorcements =
                this.Data.Endorcements
                .All()
                .Where(x => x.UserSkillId == id);
            var endorcementsCount = endorcements.Count();
            var endorcers = endorcements.Select(x => x.User.UserName).ToList();

            return this.Content(string.Format("{0} ({1})", endorcementsCount, string.Join(", ", endorcers)));
        }
    }
}