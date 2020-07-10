function recipe() {
    var self = this;
    self.id = ko.observable();
    self.name = ko.observable();
    self.ingredients = ko.observableArray([new ingredient()]);
    self.instructions = ko.observableArray([new instruction()]);
    self.authorsnotes = ko.observable();
    self.imgupload = ko.observable();
    self.author = ko.observable();
    self.dateadded = ko.observable();
}

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