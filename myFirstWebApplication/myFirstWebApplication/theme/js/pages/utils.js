var utils = {
    id: "",
    itemName: "",
    url: "",
    height: 400,
    add: function (obj) {
        this.id = "";
        this.showdialog("add", "添加" + this.itemName, true);
        return false;
    },

    addUrl: function (obj, url) {
        this.id = "";
        this.showdialog("add", this.itemName, true, url);
        return false;
    },

    edit: function (obj) {
        this.id = $(obj).attr("ItemID");
        $(obj).parents("tr").eq(0).css("background", "#8B1A1A").css("color", "#fff");
        this.showdialog("edit", "编辑" + this.itemName + "|" + obj.getAttribute("ItemName"), true);
        return false;
    },

    deleteitem: function (obj) {
        var tips = "确认删除" + this.itemName + "：" + obj.getAttribute("ItemName");
        parent.$.ligerDialog.confirm(tips, "确认删除", function (result) {
            if (result) {
                $(obj).next(".delete").click();
            }
        });
        return false;
    },
    dialog: null,
    showdialog: function (requestType, title, close, url, height, width) {
        if (url == null)
            url = this.url + "?itemid=" + this.id + "&rt=" + requestType + "&r=" + Math.random();
        dialog = parent.$.ligerDialog.open({
            height: height == null ? this.height : height,
            url: url,
            width: width == null ? 500 : width,
            showMax: false,
            showToggle: false,
            showMin: false,
            isResize: false,
            modal: true,
            title: title
        });
        dialog.close = function () {
            parent.$.ligerDialog.close();
            $(".Reload").click();
        }
    },

    isexists: function (method, param) {
        var exists = false;
        $.ajax({
            url: '../../../AjaxHandler.ashx?method=' + method + '&param=' + param,
            type: 'POST',
            dataType: 'ashx',
            async: false,
            timeout: 1000,
            error: function () { parent.$.ligerDialog.warn('请求数据失败!'); },
            success: function (result) {
                exists = parseInt(result) > 0;
            }
        });
        return exists;
    },


}
$(function () { })
{
    parent.$("#pageloading").hide();
}


