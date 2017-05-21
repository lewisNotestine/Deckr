﻿using System;
using System.Collections.Generic;
using Deckr.BLL.Cards;
using Deckr.Web.Extensions;
using Deckr.Web.Models.Home;
using Deckr.Web.Models.Home.InputModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Deckr.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeckr Deckr;

        public HomeController(IDeckr deckr)
        {
            Deckr = deckr;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(viewName: "Index");
        }

        [HttpGet]
        public JsonResult GetCards()
        {
            try
            {
                var deck = Deckr.GetDeck();
                var deckModel = deck.GetDeckModel();

                if (TempData.ContainsKey("Deck"))
                {
                    TempData["Deck"] = JsonConvert.SerializeObject(deckModel);
                }
                else
                {
                    TempData.Add("Deck", JsonConvert.SerializeObject(deckModel));
                }

                return Json(deckModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        [HttpPost]
        public JsonResult UpdateCards(string inputChoice)
        {            
            Deck deck;

            if (TempData.ContainsKey("Deck"))
            {
                var existingDeckModel = JsonConvert.DeserializeObject<DeckModel>(TempData["Deck"] as string) as DeckModel;
                deck = existingDeckModel.GetDeck();
            }
            else
            {
                deck = Deckr.GetDeck();
            }

            InputChoice choice = (InputChoice)Enum.Parse(typeof(InputChoice), inputChoice);

            switch (choice)
            {
                case InputChoice.Shuffle:
                    Deckr.ShuffleDeck(deck);
                    break;

                case InputChoice.Sort:
                    Deckr.SortDeck(deck);
                    break;

                default:
                    break;
            }

            var deckModel = deck.GetDeckModel();

			if (TempData.ContainsKey("Deck"))
			{
                TempData["Deck"] = JsonConvert.SerializeObject(deckModel);
			}
			else
			{
                TempData.Add("Deck", JsonConvert.SerializeObject(deckModel));
			}


            return Json(deckModel);
        }
    }
}
