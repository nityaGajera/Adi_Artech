(function () {
    angular.module('app').controller('app.views.product.create', [
        '$scope', '$uibModalInstance', 'abp.services.app.product',
        function ($scope, $uibModalInstance, productService) {
            var vm = this;
            vm.product = {};

            vm.save = function () {
                productService.createProduct(vm.product).then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();

                }).finally(function () {
                    vm.saving = false;
                });
            };
            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
            function init() {
            }
            init();
        }
    ]);
})();