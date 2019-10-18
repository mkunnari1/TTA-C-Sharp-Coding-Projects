function getCurrentDate() {
    var date = new Date();
    var twoDigitMonth = (date.getMonth().length === 1) ? '0' + (date.getMonth() + 1) : (date.getMonth() + 1);
    var currentDate = date.getDate() + "/" + twoDigitMonth + "/" + date.getFullYear();
    return currentDate;
}


function Product(data) {
    var self = this;
    self.ID = (data ? ko.observable(data.ID) : ko.observable());
    self.productName = (data ? ko.observable(data.productName) : ko.observable());
    self.productPrice = (data ? ko.observable(data.productPrice) : ko.observable());
    self.stock = (data ? ko.observable(data.stock) : ko.observable());
    self.companyName = (data ? ko.observable(data.companyName.toUpperCase()) : ko.observable());
    self.addedDate = (data ? ko.observable(data.addedDate) : ko.observable());
    self.isActive = (data ? ko.observable(data.isActive) : ko.observable());
}


function PageViewModel(data) {
    var self = this;
    
    self.products = ko.observableArray();
   
    for (var key in data) {
        self.products.push(new Product(ko.toJS(data[key])));
    }
    
    self.selectedProduct = ko.observable();
    self.newProduct = ko.observable();
    self.selectedProductPointer = null;

    // Function to add new product
    self.addProduct = function () {
        var product = new Product();
        product.ID(self.products().length + 1);
        product.addedDate(getCurrentDate());
        product.isActive(true);
        self.newProduct(ko.toJS(product));
        $('#add-product-modal').modal('show');
    }
    self.addConfirmed = function () {
        self.products.push(new Product(ko.toJS(self.newProduct)));
    }
    // Function to view a product 
    self.viewProduct = function (item) {
        self.selectedProduct(item);
        $('#view-product-modal').modal('show');
    }

    self.editProduct = function (item) {
        self.selectedProductPointer = item;
        self.newProduct(new Product(ko.toJS(item)));
        $('#edit-product-modal').modal('show');
    }
    self.editConfirmed = function (item) {
        self.products.replace(self.selectedProductPointer,
            new Product(ko.toJS(self.newProduct)));
    }
    // Function to delete a product 
    self.deleteProduct = function (item) {
        self.selectedProduct(item);
        self.selectedProductPointer = item;
        $('#delete-product-modal').modal('show');
    }
    self.deleteConfirmed = function () {
        var product = new Product(ko.toJS(self.selectedProduct));
        product.isActive(false);
        self.products.replace(self.selectedProductPointer, product);
    }
    // Function to recover all deleted products
    self.recoverDeletedItems = function () {
        for (var i = 0; i < self.products().length; i++) {
            if (!self.products()[i].isActive()) {
                self.products()[i].isActive(true);
            }
        }
    }
}