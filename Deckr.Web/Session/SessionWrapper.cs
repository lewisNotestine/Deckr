using System;
using Deckr.Web.Models.Home;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Deckr.Web.Session
{
    public class SessionWrapper : ISessionWrapper
    {
        private const string DECK_KEY = "Deck";

        public DeckModel GetDeckFromTempData(ITempDataDictionary tempData, Func<DeckModel> generateIfSessionMissed)
        {
            if (tempData.ContainsKey(DECK_KEY))
			{
                return JsonConvert.DeserializeObject<DeckModel>(tempData[DECK_KEY] as string) as DeckModel;				
			}
			else
			{
                return generateIfSessionMissed();
			}
        }

        public void StoreDeckInTempData(DeckModel deckModel, ITempDataDictionary tempData)
        {
            if (tempData.ContainsKey(DECK_KEY))
            {
                tempData[DECK_KEY] = JsonConvert.SerializeObject(deckModel);
            }
            else
            {
                tempData.Add(DECK_KEY, JsonConvert.SerializeObject(deckModel));
            }
        }
    }
}
