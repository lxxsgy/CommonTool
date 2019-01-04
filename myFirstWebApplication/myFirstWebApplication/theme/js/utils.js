var utils = {
    id: "",
    itemName: "",
    url: "",
    height: 400,
    width: 500,
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

    detailInfo: function (name, url) {
        this.showdialog("add", name, true, url);
        return false;
    },

    updateUrl: function (obj, url) {
        this.id = "";
        this.showdialog("add", this.itemName, true, url);
        return false;
    },
    edit: function (obj) {
        this.id = $(obj).attr("ItemID");
        this.showdialog("edit", "编辑" + this.itemName + "|" + obj.getAttribute("ItemName"), true);
        return false;
    },
    deleteitem: function (obj) {
        var tips = "确认删除" + this.itemName + "：" + obj.getAttribute("ItemName");
        $.ligerDialog.confirm(tips, "确认删除", function (result) {
            if (result) {
                $(obj).next(".delete").click();
            }
        });
        return false;
    },
    resetitem: function (obj) {
        var tips = "确认重置";
        $.ligerDialog.confirm(tips, "确认重置", function (result) {
            if (result) {
                $(obj).next(".reset").click();
            }
        });
        return false;
    },
    TurnWhole: function (obj) {
        var tips = "确认转整单" + this.itemName + "：" + obj.getAttribute("ItemName");
        $.ligerDialog.confirm(tips, "确认转整单", function (result) {
            if (result) {
                $(obj).next(".order").click();
            }
        });
        return false;
    },
    dialog: null,
    showdialog: function (requestType, title, close, url) {
        if (url == null)
            url = this.url + "?itemid=" + encodeURI(this.id) + "&rt=" + encodeURI(requestType) + "&r=" + Math.random();
        dialog = parent.$.ligerDialog.open({
            height: this.height,
            url: url,
            width: this.width,
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
    }
}
$(function () { })
{
    parent.$("#pageloading").hide();
}
