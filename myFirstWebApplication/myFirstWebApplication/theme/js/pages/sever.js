﻿var Sever = {
    rootUrl: "",
    Add: function () {
        this.Edit("create");
        return false;
    },
    Edit: function (cmd, obj) {
        debugger;
        $(obj).parents("tr").eq(0).css("background", "#8B1A1A").css("color", "#fff");
        var customerName = $(obj).attr("SeverName");
        var url = "Pages/Configuration/ManageConfiguration/UpdateSever.aspx?cmd=" + cmd;
        if (cmd == "update") {
            var customerId = $(obj).attr("CustomerID");
            url += "&customerId=" + customerId;
        }
        var title = cmd == 'create' ? '新增服务器信息' : '修改服务器信息 |' + customerName
        this.Dialog(url, title, true);
        return false;
    },
    Delete: function (linBtn) {
        var tips = "确认删除服务器：" + linBtn.getAttribute("CustomerName");
        parent.$.ligerDialog.confirm(tips, "确认删除", function (result) {
            if (result) {
                $(linBtn).next(".delete").click();
            }
        });
        return false;
    },
    Import: function (obj) {
        $(obj).parents("tr").eq(0).css("background", "#8B1A1A").css("color", "#fff");
        var customerId = $(obj).attr("CustomerID"); var customerName = $(obj).attr("CustomerName");
        var url = "Pages/ConfigurationMaintain/Configuration/Project.aspx?customerId=" + customerId + "&import=1";
        this.Dialog(url, "业务信息导入|" + customerName, false);
        return false;
    },
    View: function (obj) {
        var customerId = $(obj).attr("CustomerID");
        var url = "Pages/ConfigurationMaintain/Configuration/Project.aspx?customerId=" + customerId;
        var customerName = $(obj).attr("CustomerName");
        parent.f_addTab(customerId, "业务信息|" + customerName, url);
        // window.location.href = url;
        return false;
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
            $(".ReloadCustomers").click();
        }
    },

    isexists: function (method, param) {
        var exists = false;
        $.ajax({
            url: Customer.rootUrl + '/AjaxHandler.ashx?method=' + method + '&param=' + param,
            type: 'POST',
            dataType: 'text',
            async: false,
            timeout: 1000,
            error: function () { parent.$.ligerDialog.warn('请求数据失败!'); },
            success: function (result) {
                exists = parseInt(result) > 0;
            }
        });
        return exists;
    }
}
$(function () { })
{
    parent.$("#pageloading").hide();
}