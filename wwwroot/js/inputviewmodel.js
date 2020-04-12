function inputviewmodel() {
    var self = this;
    self.recipe = ko.observable(new recipe());
    self.addIngredient = function() {
        self.recipe().ingredients.push(new ingredient());
    };
    self.addStep = function() {
        var nextStep = self.recipe().instructions().length +1;
        self.recipe().instructions.push(new instruction(nextStep));
    };
}

function recipe() {
    var self = this;
    self.id = ko.observable();
    self.name = ko.observable();
    self.ingredients = ko.observableArray([new ingredient()]);
    self.instructions = ko.observableArray([new instruction()]);
    self.authorsnotes = ko.observable();
    self.imgupload = ko.observable();
}

ko.applyBindings(new inputviewmodel());

function ingredient() {
    var self = this;
    self.id = ko.observable();
    self.name = ko.observable();
    self.amount = ko.observable();
    self.units = ko.observable();
}

function instruction(step) {
    var self = this;
    self.id = ko.observable();
    self.stepnumber = ko.observable(step || 1);
    self.text = ko.observable();
}
