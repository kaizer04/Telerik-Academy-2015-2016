namespace ForumSystem.Web.ViewModels.Home
{
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using System.Collections.Generic;

    public class IndexBlogPostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<IndexBlogPostTagViewModel> Tags { get; set; }

        public string Url => $"/questions/{this.Id}/{this.Title.ToLower().Replace(" ", "-")}";
    }
}