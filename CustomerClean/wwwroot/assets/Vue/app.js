var app =
    new Vue({
        el: "#app",
        data: {
            Province: "",
            Provinces: [],
            Citys: [],
            Services:[]
        },
        created: function () {
            this.GetAllProvince();
            this.GetAllServices();
        },
        methods: {

            GetCitys: function (event) {
                var vm = this;
                $.ajax({
                    url: "/City/GetAllCity/" + event,
                    method: "GET",
                }).done(function (data) {
                    vm.Citys = data;
                }).fail(function () {

                });
            },
            GetAllProvince() {
                var vm = this;
                var state = document.getElementById("state").value;
                if (state) {
                    $.ajax({
                        url: "/City/GetAllProvince",
                        method: "GET"

                    }).done(function (data) {
                        vm.Provinces = data;
                    }).fail(function () {

                    });
                    vm.GetCitys(state);
                } else {
                    $.ajax({
                        url: "/City/GetAllProvince",
                        method: "GET"

                    }).done(function (data) {
                        vm.Provinces = data;
                    }).fail(function () {

                    });
                }
               
            },
            GetAllServices() {
                var vm = this;
                $.ajax({
                    url: "/Services/GetAllServices",
                    method: "GET"

                }).done(function (data) {
                    vm.Services = data;
                }).fail(function () {

                });
            }


        }




    });
$('#state').on("change", function () {

    app.GetCitys($(this).val());
    var select = document.getElementById('city')
    select.value = "";
});
