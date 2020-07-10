function InputViewModel() {
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
