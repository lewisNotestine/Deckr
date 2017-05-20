// Write your Javascript code.

"use strict";

var viewModel = function () {
    var self = this;

    self.inputChoice = ko.observable(null);

    self.func = function () {
        console.log("func called");
    };

    return self;
};

ko.applyBindings(new viewModel());

