using System;
using Deckr.Web.Models.Home;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Deckr.Web.Session
{
    public interface ISessionWrapper
    {
        void StoreDeckInTempData(DeckModel deckModel, ITempDataDictionary tempData);

        DeckModel GetDeckFromTempData(ITempDataDictionary tempData, Func<DeckModel> generateIfSessionMiss);
    }
}
