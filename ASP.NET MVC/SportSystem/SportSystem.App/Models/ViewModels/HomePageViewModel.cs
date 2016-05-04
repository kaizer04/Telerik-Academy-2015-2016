using System.Collections.Generic;

namespace SportSystem.App.Models.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<ConciseMatchViewModel> TopMatches { get; set; }

        public IEnumerable<ConciseTeamViewModel> BestTeams { get; set; }
    }
}