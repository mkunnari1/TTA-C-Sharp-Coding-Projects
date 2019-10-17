function MenuViewModel() {
    var self = this;
    self.menuitems = ko.observableArray([
        { name: 'Race List' },
        { name: 'Character List' }
    ]);
    self.menuClick = function (data, event) {
        if (data.name == "Character List") {
            $('#content').load("/Home/Character", function () { ko.applyBindings(raceViewModel, $('#content')[0]); });
        }
        else if (data.name == "Race List") {
            $('#content').load("/Home/Race", function () {
                ko.applyBindings(raceViewModel, $('#content')[0]);
            });
        }
    };
}

function RaceViewModel() {
    var self = this;
    var saveState = {};
    self.NewRace = {
        id: ko.observable(0),
        name: ko.observable(''),
        isEdit: ko.observable(false)
    };
    self.races
}