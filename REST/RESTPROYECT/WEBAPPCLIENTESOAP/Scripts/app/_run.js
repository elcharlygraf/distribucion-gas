$(function () {
    app.initialize();

    // Activar Knockout
    ko.validation.init({ grouping: { observable: false } });
    ko.applyBindings(app);
});
