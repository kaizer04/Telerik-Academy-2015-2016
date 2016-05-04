namespace LinkedIn.Web.ViewModels
{
    using LinkedIn.Models;
    using System;
    using System.Linq.Expressions;

    public class CertificationViewModel
    {
        public static Expression<Func<Certification, CertificationViewModel>> ViewModel
        {
            get
            {
                return x => new CertificationViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Url = x.Url
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string LicenseNumber { get; set; }

        public string Url { get; set; }

        public DateTime TakenDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
