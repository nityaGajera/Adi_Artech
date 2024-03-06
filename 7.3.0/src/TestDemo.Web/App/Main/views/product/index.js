(function () {
    angular.module('app').controller('app.views.product.index', [
        '$scope', '$timeout', '$uibModal', 'abp.services.app.product',
        function ($scope, $timeout, $uibModal, productService) {
            var vm = this;
            vm.product = [];
            function getproduct() {
                productService.getProductData()
                    .then(function (result) {
                        vm.product = result.data;
                    });
            }
            vm.permissions = {
                productcreate: abp.auth.hasPermission('Pages.Product.Create'),
                productupdate: abp.auth.hasPermission('Pages.Product.Update'),
                productdelete: abp.auth.hasPermission('Pages.Product.Delete'),
            }

            vm.productcreatepermission = function () {
                if (vm.permissions.productcreate) {
                    return true;
                } else {
                    return false;
                }
            }

            vm.productupdatepermission = function () {
                if (vm.permissions.productupdate) {
                    return true;
                } else {
                    return false;
                }
            }
            vm.productdeletepermission = function () {
                if (vm.permissions.productdelete) {
                    return true;
                } else {
                    return false;
                }
            }

            vm.openproductcreate = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/product/create.cshtml',
                    controller: 'app.views.product.create as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {

                    $.AdminBSB.input.activate();

                });

                modalInstance.result.then(function () {
                    getproduct();
                });

            };
            vm.openproductEdit = function (product) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/product/edit.cshtml',
                    controller: 'app.views.product.edit as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return product.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $timeout(function () {
                        $.AdminBSB.input.activate();
                    }, 0);
                });

                modalInstance.result.then(function () {
                    getproduct();
                });
            };
            vm.deletedata = function (item) {
                debugger;

                abp.message.confirm(
                    "delete test '" + item.name + "'?",
                    "delete?",
                    function (result) {
                        if (result) {

                            productService.deleteProduct({ id: item.id })
                                .then(function () {
                                    abp.notify.info("deleted product is: " + item.name);
                                    getproduct();
                                });
                        }
                    });
            };

            function init() {
                getproduct();
            }
            init();
        }
    ]);
})();