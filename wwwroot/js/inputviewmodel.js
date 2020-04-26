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

    self.submit = function() {
        var data = {recipe: ko.toJS(self.recipe())}
        Post("/recipe/submit", data, function(response){console.log(response)}) 
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

function Post(url, data, callback) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url)
    xhr.setRequestHeader("Content-Type", "application/json")
    xhr.onload = function(data){
        callback(data);
    }
    xhr.send(JSON.stringify(data));
}
