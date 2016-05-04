namespace LinkedIn.Web.ViewModels
{
    using System.Linq;
    using LinkedIn.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class SkillViewModel
    {
        public static Expression<Func<UserSkill, SkillViewModel>> ViewModel
        { 
            get 
            {
                return x => new SkillViewModel 
                {
                    Id = x.Id,
                    Name = x.Skill.Name,
                    EndorcementsCount = x.Endorcements.Count,
                    Endorcers = x.Endorcements.Select(e => e.User.UserName)
                };
            } 
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Endorcers { get; set; }
        
        public int EndorcementsCount { get; set; }
    }
}
