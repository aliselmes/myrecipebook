function RecipesViewModel() {
    var self = this
    self.recipes = ko.observableArray()
    self.filter = ko.observable()
    self.filteredRecipes = ko.computed(function(){
        if (!self.filter()) {
            return self.recipes()
        }
        return self.recipes().filter(x=>{
            return x.name().toLowerCase().includes(self.filter().toLowerCase())
        })
    })






    self.load = function () {
        Get('/recipe/GetAll', function (response) {
            var recipes = JSON.parse(response).map(x=> new recipe(x))
            console.log(recipes)
            self.recipes(recipes)
        })
    }
    self.load();
}

function recipe(data) {
    var self = this
    self.id = ko.observable(data.id)
    self.name = ko.observable(data.name)
    self.dateAdded = ko.observable(data.dateAdded)
    self.author = ko.observable(data.author)
    self.instructions = ko.observable(data.instructions)
    self.ingredients = ko.observable(data.ingredients)
}

ko.applyBindings(new RecipesViewModel());