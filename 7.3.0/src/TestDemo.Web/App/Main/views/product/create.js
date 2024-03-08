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
                    abp.notify.info(App.localize('Saved Successfully'));
                    $uibModalInstance.close();

                }).finally(function () {
                    debugger;
                    vm.saving = false;
                });
            };
            vm.getAll = function () {
                vm.loading = true;
                // debugger;
                productService.GetProductData($.extend({}, vm.requestParams)).then(function (result) {
                    //  debugger;
                    vm.product = result.data.items;
                    vm.userGridOptions.totalItems = result.data.totalCount;
                    vm.userGridOptions.data = result.data.items;
                    if (result.data.totalCount == 0) {
                        //vm.norecord = true;
                        abp.notify.info(app.localize('No Record Found'));
                    }
                    else { vm.norecord = false; }
                }).finally(function () {
                    vm.loading = false;
                });

            }
            vm.uploadFile = function (file) {

                vm.saving = true;
                var files = $('#filetoupload')[0].files[0];
                /*//console.log(files);*/
                if ($('#filetoupload')[0].files.length == 0) {

                    abp.notify.error(App.localize('please upload doc'));

                    return;
                }

                var uploadUrl = "../FileUpload/UploadProductAttachments";
                debugger;
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
                        alert("somethings is wrong");
                    }

                }).finally(function () {
                    vm.saving = false;
                    vm.saveAs();

                })


            };
            vm.saveAs = function () {
                debugger;
                vm.loading = true;
                vm.saving = true;
                        productService.createProduct(vm.product).then(function (result) {
                            vm.product = result.data;
                            abp.notify.success(App.localize('Product Saved Successfully'));

                            $uibModalInstance.close();
                            vm.getAll();

                        }).finally(function () {
                            vm.saving = false;
                        });
            };
            vm.save = function () {
                debugger;
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
                            abp.notify.error(App.localize('File size exceeds maximum limit MB'));
                        }
                    }

                    else {
                        abp.notify.error(App.localize('please upload correct file'));

                        // return;
                    }

                }
                else {
                    abp.notify.error(App.localize('please upload doc'));
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