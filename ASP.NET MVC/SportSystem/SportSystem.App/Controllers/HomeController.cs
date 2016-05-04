﻿namespace SportSystem.App.Controllers
{
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            var topMatches = this.Data.Matches
                .All()
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .OrderByDescending(m => m.Bets.Count)
                .Take(3);
            var bestTeams = this.Data.Teams
                .All()
                .OrderByDescending(t => t.Votes.Count)
                .Take(3);
            var model = new HomePageViewModel()
            {
                TopMatches = Mapper.Map<IEnumerable<ConciseMatchViewModel>>(topMatches),
                BestTeams = Mapper.Map<IEnumerable<ConciseTeamViewModel>>(bestTeams),
            };

            return this.View(model);
        }
    }
}