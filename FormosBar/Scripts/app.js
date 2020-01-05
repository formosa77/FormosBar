var ViewModel = function () {
    var self = this;
    self.orders = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observableArray();
    self.order_id = ko.observable();
    self.getSelected = ko.observable();

    self.newItem = {
        OrderId: ko.observable(),
        Name: ko.observable(),
        Price: ko.observable(),
        Quantity: ko.observable(),
        Status: ko.observable()
    }

    //self.selectedColor = ko.computed(function () {
    //    return self.colors()[self.selectedColorId()];
    //});

    var ordersUri = '/api/Orders/';


    self.getOrderDetail = function (order) {
        ajaxHelper(ordersUri + order.id, 'GET').done(function (data) {
            self.detail(data);
            self.order_id(order.id);
        });
    }

    var orderDetailUri = '/api/OrderDetails/';

    self.updateOrderStatus = function (updateRecord, event) {
        updateRecord.status = event.target.value;

        ajaxHelper(orderDetailUri + updateRecord.id, 'PUT', updateRecord).done(function (data) {
            alert("Status Update!");
        });
    }

    self.deleteOrderItem = function (deleteRecord, event) {
        console.log(JSON.stringify(deleteRecord));
        //updateRecord.status = event.target.value;

        ajaxHelper(orderDetailUri + deleteRecord.id, 'DELETE').done(function (data) {
            //alert("Item Deleted!");
            ajaxHelper(ordersUri + deleteRecord.orderId, 'GET').done(function (data) {
                self.detail(data);
                alert("Item Deleted!");
            });
        });
    }

    self.addOrderItem = function (addRecord, event) {
        console.log(self.newItem.Name());
        console.log(self.newItem.Quantity());
        var newOrderItem = {
            OrderId: self.order_id(),
            Name: self.newItem.Name(),
            Price: 0,
            Quantity: self.newItem.Quantity(),
            Status: 3
        }

        ajaxHelper(orderDetailUri, 'POST', newOrderItem).done(function (item) {
            self.detail.push(item);
            alert("Item Added!");
        });
    }

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllOrders() {
        ajaxHelper(ordersUri, 'GET').done(function (data) {
            self.orders(data);
        });
    }

    // Fetch the initial data.
    getAllOrders();
};

ko.applyBindings(new ViewModel());