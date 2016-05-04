namespace LinkedIn.Web.ViewModels
{
    using LinkedIn.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class UserViewModel
    {
        public static Expression<Func<User, UserViewModel>> ViewModel
        {
            get 
            {
                return x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    Summary = x.Summary,
                    ContactInfo = x.ContactInfo,
                    FullName = x.FullName,
                    AvatarUrl = x.AvatarUrl,
                    Certifications = x.Certifications.AsQueryable().Select(CertificationViewModel.ViewModel),
                    Skills = x.Skills.AsQueryable().Select(SkillViewModel.ViewModel)
                };
            }
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Име")]
        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public IEnumerable<CertificationViewModel> Certifications { get; set; }

        //public static object FromModel(User user)
        //{
        //    return new UserViewModel
        //    {
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        AvatarUrl = user.AvatarUrl,
        //        ContactInfo = user.ContactInfo,
        //        FullName = user.FullName,
        //        Summary = user.Summary
        //    };
        //}

        public IEnumerable<SkillViewModel> Skills { get; set; } 
    }
}