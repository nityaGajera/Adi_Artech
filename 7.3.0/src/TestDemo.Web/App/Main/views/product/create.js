(function () {
    angular.module('app').controller('app.views.product.create', [
        '$scope', '$uibModalInstance', '$http', 'abp.services.app.product',
        function ($scope, $uibModalInstance,$http, productService) {
            var vm = this;
            vm.saving = false;
            vm.loading = false;
            var maxsize = 2048000;
            vm.product = {};

            vm.save = function () {
                productService.createProduct(vm.product).then(function () {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();

                }).finally(function () {
                    vm.saving = false;
                });
            };
            vm.uploadFile = function (file) {

                vm.saving = true;
                var files = $('#filetoupload')[0].files[0];
                //console.log(files);
                if ($('#filetoupload')[0].files.length == 0) {

                    abp.notify.error(App.localize('pleaseuploaddoc'));

                    return;
                }

                var uploadUrl = "../FileUpload/UploadDocumentAttachments";
                var fd = new FormData();
                fd.append('file', $('#filetoupload')[0].files[0]);

                $http.post(uploadUrl, fd, {
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                }).then(function (data, status) {
                    console.log(data);
                    if (data.statusText == "OK") {

                        vm.product.attachment = data.data.Result.fileName;
                        //vm.saveAs();
                        //console.log(data);
                    }


                    else {
                        alert("somethingsiswrong");
                    }

                }).finally(function () {
                    vm.saving = false;
                    vm.saveAs();

                })


            };
            vm.saveAs = function () {
                vm.loading = true;
                vm.saving = true;

                productService.ProductExsistence(vm.product).then(function (result) {
                    if (!result.data) {
                        productService.createProduct(vm.product).then(function (result) {
                            vm.product = result.data;
                            abp.notify.success(App.localize('ProductSavedSuccessfully'));

                            $uibModalInstance.close();
                            vm.getAll();

                        }).finally(function () {
                            vm.saving = false;
                        });
                    }
                    else {
                        abp.notify.error(App.localize('Product already Exist '));
                        vm.loading = false;
                    }
                });
            };
            vm.save = function () {
                vm.loading = true;
                var files = $('#filetoupload')[0].files[0];


                if ($('#filetoupload')[0].files.length != 0) {
                    vm.product.attachment = files.name;
                    var ext = vm.product.attachment.split('.').pop();
                    if (ext == 'pdf' || ext == 'jpg' || ext == 'jpeg' || ext == 'doc' || ext == 'docx' || ext == 'txt' || ext == 'xls' || ext == 'xlsx') {
                        //var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
                        //var i = parseInt(Math.floor(Math.log(files.size) / Math.log(1024)));
                        //var sz = Math.round(files.size / Math.pow(1024, i), 2) + ' ' + sizes[i];
                        if (files.size <= maxsize) {
                            vm.uploadFile();
                        }
                        else {
                            abp.notify.error(App.localize('FilesizeexceedsmaximumlimitMB'));
                        }
                    }

                    else {
                        abp.notify.error(App.localize('pleaseuploadcorrectfile'));

                        // return;
                    }

                }
                else {
                    abp.notify.error(App.localize('pleaseuploaddoc'));
                    //return;
                    vm.loading = false;
                }
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