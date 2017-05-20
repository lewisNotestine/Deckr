﻿using System;
using System.Collections.Generic;
using Deckr.Extensions;
using Deckr.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace Deckr.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeckr Deckr;

        public HomeController(IDeckr deckr)
        {
            Deckr = deckr;
        }

        public IActionResult Index()
        {
            var deck = Deckr.GetDeck();

            var cardList = new List<CardModel>();
            foreach (var card in deck.Cards)
            {
                cardList.Add(new CardModel(card.Suit.ToString(), card.Suit.GetDescription(), card.Rank.ToString(), card.Rank.GetDescription()));
            }

            return View(viewName: "Index", model: new IndexModel(cardList));
        }
    }
}
