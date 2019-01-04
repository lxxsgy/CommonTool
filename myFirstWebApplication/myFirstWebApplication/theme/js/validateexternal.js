
// 名称验证
jQuery.validator.addMethod("checkname", function (value, element) {
    var regex = /^[\u4E00-\u9FA5A-Za-z0-9_]+$/;
    return this.optional(element) || regex.test(value);
}, "只能输入数字,下划线,字母和中文");


// 字母和数字的验证
jQuery.validator.addMethod("chrnum", function (value, element) {
    var chrnum = /^([a-zA-Z0-9_]+)$/;
    return this.optional(element) || (chrnum.test(value));
}, "只能输入数字,下划线和字母");

// 中文的验证
jQuery.validator.addMethod("chinese", function (value, element) {
    var chinese = /^[\u4e00-\u9fa5]+$/;
    return this.optional(element) || (chinese.test(value));
}, "只能输入中文");
// 验证文件路径
jQuery.validator.addMethod("checkPath", function (value, element) {
    var chinese = /[a-zA-Z]:(\\([\u4E00-\u9FA5A-Za-z0-9_]+))+|(\/([0-9a-zA-Z]+))+$/;
    return this.optional(element) || (chinese.test(value));
}, "请输入正确的路径");
jQuery.validator.addMethod("mobile", function (value, element) {
    var length = value.length;
    var mobile = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1})|(14[0-9]{1})|(17[0-9]{1}))+\d{8})$/;
    return this.optional(element) || (length == 11 && mobile.test(value));
}, "手机号码格式错误");