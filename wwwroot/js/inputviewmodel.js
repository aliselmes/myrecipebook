function inputviewmodel() {
    var self = this;
    self.recipe = ko.observable(new recipe());
    self.status = ko.observable();
    self.addIngredient = function () {
        self.recipe().ingredients.push(new ingredient());
    };
    self.addStep = function () {
        var nextStep = self.recipe().instructions().length + 1;
        self.recipe().instructions.push(new instruction(nextStep));
    };

    self.submit = function () {

        var data = ko.toJS(self.recipe());
        Post("/recipe/submit", data, function (res) {
            var response = JSON.parse(res)
            console.log(response)
            if (response.success) {
                self.status("Recipe added!")
                self.recipe(new recipe());
            }
            else {
                self.status(response.message)
            }
        })
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
    self.author = ko.observable();
    self.dateadded = ko.observable();
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
    xhr.setRequestHeader("Accept", "application/json")

    var xsrfToken = document.querySelector("[name=__RequestVerificationToken]").value;
    xhr.setRequestHeader("XSRF-TOKEN", xsrfToken)
    xhr.onload = function (data) {
        
        callback(this.response);
    }
    xhr.send(JSON.stringify(data));
}
