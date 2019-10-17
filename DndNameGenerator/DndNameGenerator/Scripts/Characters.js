function race(id, name) {
    return {
        id: ko.observable(id),
        name: ko.observable(name),
        characters: ko.observableArray([]),
        isEdit: ko.observable(false)
    };
}
function character(id, name) {
    return {
        id: ko.observable(id),
        name: ko.observable(name)
    };
}