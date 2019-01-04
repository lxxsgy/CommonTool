var Tips = {
    Add: function () {
        this.Edit("create");
        return false;
    },
    Edit: function (cmd, obj) {
        $(obj).parents("tr").eq(0).css("background", "#8B1A1A").css("color", "#fff");
        var url = "Pages/Configuration/WithLibrary/TipsInfo.aspx?cmd=" + cmd;
        if (cmd == "update") {
            var customerId = $(obj).attr("TipsID");
            url += "&TipsId=" + customerId;
        }
        var title = cmd == 'create' ? '添加带库信息' : '修改带库信息'
        this.Dialog(url, title, true);
        return false;
    },
    Delete: function (linBtn) {
        var tips = "确认删除带库：" + linBtn.getAttribute("TipsName");
        parent.$.ligerDialog.confirm(tips, "确认删除", function (result) {
            if (result) {
                $(linBtn).next(".delete").click();
            }
        });
        return false;
    },
    Import: function (obj) {
        var tableName = $(obj).attr("TableName");
        var url = "Pages/Configuration/WithLibrary/TipsImport.aspx?TableName=" + tableName + "&import=1";
        this.Dialog(url, "带库信息导入", false);
        return false;
    },
    View: function (obj) {
        var tableName = $(obj).attr("TableName");
        var url = "TipsImport.aspx?TableName=" + tableName;
        window.location.href = url;
    },

    Dialog: function (url, title, close) {
        var m = parent.$.ligerDialog.open({
            height: 500,
            url: url,
            width: 500,
            showMax: false,
            showToggle: false,
            showMin: false,
            isResize: false,
            modal: true,
            title: title
        });
        m.close = function () {
            parent.$.ligerDialog.close();
            $(".ReloadTips").click();
        }
    }
}
$(function () { })
{
    parent.$("#pageloading").hide();
}