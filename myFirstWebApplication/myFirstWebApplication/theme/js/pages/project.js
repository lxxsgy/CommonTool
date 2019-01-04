var Project = {
    Add: function (customerId) {
        var url = "Pages/Configuration/ManageConfiguration/EditProject.aspx?cmd=create&customerId=" + customerId;
        var title = '添加业务信息';
        this.Dialog(url, title, true);
        return false;
    },
    rootUrl: "",
    Edit: function (cmd, obj) {
        $(obj).parents("tr").eq(0).css("background", "#8B1A1A").css("color", "#fff");
        var url = "Pages/Configuration/ManageConfiguration/EditProject.aspx?cmd=" + cmd;
        if (cmd == "update") {
            var projectId = $(obj).attr("ProjectID");
            url += "&projectId=" + projectId;
        }
        var title = '修改业务信息';
        this.Dialog(url, title, true);
        return false;
    },
    Delete: function (linBtn) {
        var tips = "确认删除业务：" + linBtn.getAttribute("ProjectName");
        parent.$.ligerDialog.confirm(tips, "确认删除", function (result) {
            if (result) {
                if (Project.isexists("fields", $(linBtn).attr("ProjectID"))) {
                    parent.$.ligerDialog.error("该业务已有字段信息导入,不能删除。");
                }
                else {
                    $(linBtn).next(".delete").click();
                }
            }
        });
        return false;
    },
    Import: function (obj) {
        parent.$.ligerDialog.confirm("字段信息导入成功后,该业务不可删除,是否确定要导入?", "确认导入", function (result) {
            if (result) {
                var projectId = $(obj).attr("ProjectID");
                var url = "Pages/Configuration/ManageConfiguration/Field.aspx?projectId=" + projectId + "&import=1";
                Project.Dialog(url, "字段信息导入", false);
            }
        });
        return false;
    },
    View: function (obj) {
        var projectId = $(obj).attr("ProjectID");
        var url = "Pages/Configuration/ManageConfiguration/Field.aspx?projectId=" + projectId;
        var projectName = $(obj).attr("ProjectName");
        parent.f_addTab(projectId, "字段管理|" + projectName, url);
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
            $(".ReloadProjects").click();
        }
    },
    isexists: function (method, param) {
        var exists = false;
        $.ajax({
            url: Project.rootUrl + '/AjaxHandler.ashx?method=' + method + '&param=' + param,
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