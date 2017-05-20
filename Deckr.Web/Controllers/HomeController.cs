﻿using System;
using System.Collections.Generic;
using Deckr.Extensions;
using Deckr.Web.Models.Home;
using Deckr.Web.Models.Home.InputModels;
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

        [HttpGet]
        public ViewResult Index()
        {
            var deck = Deckr.GetDeck();

            var cardList = new List<CardModel>();
            foreach (var card in deck.Cards)
            {
                cardList.Add(new CardModel(card.Suit.ToString(), card.Suit.GetDescription(), card.Rank.ToString(), card.Rank.GetDescription()));
            }

            return View(viewName: "Index", model: new IndexModel(cardList));
        }

        [HttpPost]
        public ViewResult Index(string inputChoice)
        {
            var deck = Deckr.GetDeck();
            InputChoice choice = (InputChoice) Enum.Parse(typeof(InputChoice), inputChoice);
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

			var cardList = new List<CardModel>();
			foreach (var card in deck.Cards)
			{
				cardList.Add(new CardModel(card.Suit.ToString(), card.Suit.GetDescription(), card.Rank.ToString(), card.Rank.GetDescription()));
			}


			return View(viewName: "Index", model: new IndexModel(cardList));
        }
    }
}
