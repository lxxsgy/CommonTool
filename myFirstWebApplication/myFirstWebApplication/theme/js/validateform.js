  
   $("form").validate({
       errorPlacement: function (lable, element) {
           $(element).next("span").text(lable.text()).show();
       },
       success: function (lable, element) {
           var id = lable.attr("htmlFor");
           $("#" + id).next("span").hide();
       }
   });
   function btnCallBack() {
       var dialogClose = parent.$(".l-dialog-close");
       if (dialogClose != null && dialogClose != undefined) {
           dialogClose.click();
       }
   }