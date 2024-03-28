(function () {
    var myApp = angular.module('app');
    myApp.controller('app.views.product.edit', [
        '$scope', '$http', '$uibModalInstance', 'abp.services.app.product', 'id',
        function ($scope, $http , $uibModalInstance, productService, id,) {
            var vm = this;
            vm.loading = false;
            vm.saving = false;
            vm.product = {};
            function init() {
                if (id == undefined) {

                } else {
                    productExsistenceById();
                }
            }
            init();

            function productExsistenceById() {
                productService.productExsistenceById({
                    id: id
                }).then(function (result) {
                    vm.product = result.data;
                    console.log(vm.product);
                });
            }
            vm.uploadFile = function (file) {
                vm.saving = true;
                if ($('#filetoupload')[0].files.length != 0) {
                    var files = $('#filetoupload')[0].files[0];
                    if ($('#filetoupload')[0].files.length == 0) {

                        abp.notify.error(App.localize('pleaseuploaddoc'));
                        return;
                    }
                    var uploadUrl = "../FileUpload/UploadProductAttachments";
                    var fd = new FormData();
                    fd.append('file', $('#filetoupload')[0].files[0]);
                }
                else {
                    var uploadUrl = "../FileUpload/UploadProductAttachments";
                    var fd = new FormData();
                    fd.append('file', vm.product.attachment);
                }
                $http.post(uploadUrl, fd, {
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                }).then(function (data, status) {
                    if (data.statusText == "OK") {
                        vm.product.attachment = data.data.Result.fileName;
                        //vm.saveAs();
                        //console.log(data);
                    }

                                        

                    else {
                        alert("somethings iswrong");
                    }

                }).finally(function () {
                    vm.saving = false;
                    vm.saveAs();
                })
                //$scope.imagePath = 'D:/SourcetreeProjs/Adi_Artech/7.3.0/src/TestDemo.Web/UserFiles/Products/painting 2.jpeg';

                $scope.saveChanges = function () {
                    console.log("Image path saved:", $scope.imagePath);
                };

            };
         

            function init() {

                productService.getProductbyid({
                    id: id
                }).then(function (result) {
                    vm.product = result.data;
                    console.log(vm.product);
                });


            }


            vm.saveAs = function () {
                vm.loading = true;
                vm.saving = true;
                productService.productExsistenceById(vm.product).then(function (result) {
                    if (!result.data) {
                        productService.updateProduct(vm.product)
                            .then(function () {
                                abp.notify.success(App.localize('ProductSavedSuccessfully'));
                                $uibModalInstance.close();

                            });
                    }

                    else {
                        abp.notify.error(App.localize('product already Exist '));
                        vm.loading = false;
                    }
                }).finally(function () {
                    vm.saving = false;
                });
            };

            vm.save = function () {
                vm.loading = true;

                if ($('#filetoupload')[0].files.length != 0) {
                    var files = $('#filetoupload')[0].files[0];
                    vm.product.attachment = files.name;
                    var ext = vm.product.attachment.split('.').pop();


                    if (ext == 'pdf' || ext == 'jpg' || ext == 'jpeg' || ext == 'doc' || ext == 'docx' || ext == 'txt' || ext == 'xls' || ext == 'xlsx') {

                        vm.uploadFile();


                    }

                    else {
                        abp.notify.error(App.localize('pleaseuploadcorrectfile'));
                        //return;
                        vm.loading = false;
                    }
                }
                else {
                    //abp.notify.error(App.localize('pleaseuploadproduct'));
                    //return;
                    vm.product.attachment = vm.product.attachment;
                    vm.uploadFile();
                }
            }
            function init() {
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
                    vm.product = result.data;
                    console.log(vm.product);
                    $scope.imagePath = "";
                    $scope.imagePath = '~/UserFiles/Products/jeans.jpeg';
                    console.log(imagePath);
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