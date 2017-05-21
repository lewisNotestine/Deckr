using System;
using Deckr.Web.Models.Home;
using Deckr.Web.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Deckr.Web.Session
{
    public class SessionWrapper : ISessionWrapper
    {
        public DeckModel GetDeckFromTempData(ITempDataDictionary tempData, Func<DeckModel> generateIfSessionMissed)
        {
			if (tempData.ContainsKey("Deck"))
			{
				return JsonConvert.DeserializeObject<DeckModel>(tempData["Deck"] as string) as DeckModel;				
			}
			else
			{
                return generateIfSessionMissed();
			}
        }

        public void StoreDeckInTempData(DeckModel deckModel, ITempDataDictionary tempData)
        {
            if (tempData.ContainsKey("Deck"))
            {
                tempData["Deck"] = JsonConvert.SerializeObject(deckModel);
            }
            else
            {
                tempData.Add("Deck", JsonConvert.SerializeObject(deckModel));
            }
        }
    }
}
