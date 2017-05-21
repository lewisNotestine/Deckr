﻿using System;
using System.Collections.Generic;
using Deckr.BLL.Cards;
using Deckr.Web.Extensions;
using Deckr.Web.Models.Home;
using Deckr.Web.Models.Home.InputModels;
using Deckr.Web.Session;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Deckr.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeckr Deckr;
        private readonly ISessionWrapper SessionWrapper;

        public HomeController(IDeckr deckr, ISessionWrapper sessionWrapper)
        {
            Deckr = deckr;
            SessionWrapper = sessionWrapper;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(viewName: "Index");
        }

        [HttpGet]
        public JsonResult GetCards()
        {
            var deck = Deckr.GetDeck();
            var deckModel = deck.GetDeckModel();

            SessionWrapper.StoreDeckInTempData(deckModel, TempData);

            return Json(deckModel);        
		}

        [HttpPost]
        public JsonResult UpdateCards(string inputChoice)
        {
            CardOperation cardOperation;
            if (!Enum.TryParse<CardOperation>(inputChoice, out cardOperation))
            {
                throw new ArgumentException($"{inputChoice} not parsable as card operation");
            }                            

            Deck deck = SessionWrapper.GetDeckFromTempData(TempData, () => Deckr.GetDeck().GetDeckModel()).GetDeck();


            switch (cardOperation)
            {
                case CardOperation.Shuffle:
                    Deckr.ShuffleDeck(deck);
                    break;

                case CardOperation.Sort:
                    Deckr.SortDeck(deck);
                    break;

                default:
                    break;
            }

            var deckModel = deck.GetDeckModel();

            SessionWrapper.StoreDeckInTempData(deckModel, TempData);

            return Json(deckModel);
        }
    }
}
