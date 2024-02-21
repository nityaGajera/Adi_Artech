(function () {
    var myApp = angular.module('app');
    myApp.controller('app.views.product.edit', [
        '$scope', '$uibModalInstance', 'abp.services.app.product', 'id',
        function ($scope, $uibModalInstance, productService, id) {
            var vm = this;
            vm.product = {};

            function init() {
                debugger;
                if (id == undefined) {

                } else {
                    getProductbyid();
                }
            }
            init();

            function getProductbyid() {
                productService.getProductbyid({
                    id: id
                }).then(function (result) {
                    debugger;
                    vm.product = result.data;
                    console.log(vm.product);
                });
            }

            vm.cancel = function () {
                $uibModalInstance.close();
            }
            vm.save = function () {

                productService.updateProduct(vm.product)
                    .then(function () {
                        abp.notify.info(App.localize('SavedSuccessfully'));
                        $uibModalInstance.close();
                    });

            };

        }
    ]);
})();