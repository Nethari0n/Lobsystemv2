let handler;

window.Connection = {
    initialize: function (interop) {

        handler = function () {
            interop.invokemethodasync("connection.statuschanged", navigator.online);
        }

        window.addeventlistener("online", handler);
        window.addeventlistener("offline", handler);

        handler(navigator.online);
    },
    dispose: function () {

        if (handler != null) {

            window.removeeventlistener("online", handler);
            window.removeeventlistener("offline", handler);
        }
    }
};