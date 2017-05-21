"use strict";

var viewModel = function () {
    var self = this;

    self.inputChoice = ko.observable(null);
    self.cards = ko.observableArray([]);

    self.initialize = function () {
        $.ajax({
            url: "/Home/GetCards",
            method: "GET",          
            success : function (data, status, jqXHR) {
                self.cards([]);
                $.each(data.cards, function (name, value) {
                    self.cards.push(value);
                });
            }
        });
    };


    var updateCards = function (cardChoice) {

        $.ajax({
            url: "/Home/UpdateCards",
            method: "POST",  
            data: {                
                "inputChoice" : cardChoice          
            }, 
            success : function (data, status, jqXHR) {
                self.cards([]);

                $.each(data.cards, function (name, value) {
                    self.cards.push(value);
                });
            }
        });
    };

    self.shuffleCards = function() {
        updateCards('Shuffle');
    };

    self.sortCards = function() {
        updateCards('Sort');
    };

    return self;
};

var vModel = new viewModel();

ko.applyBindings(vModel);

vModel.initialize();

