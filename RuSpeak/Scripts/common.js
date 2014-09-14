function FunctionName() {
    _this = this;


    //this.showPopup = function (url) {
    //    $.ajax({
    //        type: "GET",
    //        url: url,
    //        success: function (data) {
    //            if ($("#mydialog").length == 0) {
    //                alert("Элемент не найден");
    //            } else {
    //                alert("Элемент найден");
    //                var content = $("#mycont");
    //                content.empty();
    //                content.html(data);
    //                var m = $("#mydialog");
    //                m.modal('show');
    //            }
    //        }
    //    });
    //}

    //this.init = function () {
    //    $("#mylink").click(function () {
    //        //alert("adasd");
    //        _this.showPopup("/User/AjaxLogin");
    //    });
    //}

   
    
}

var functionName = null;
$().ready(function () {
    functionName = new FunctionName();
    functionName.init();
});

