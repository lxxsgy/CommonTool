var Field = {
    rootUrl: "",
    getProjectId: function (obj) {
        var project = $(obj).parents(".project").eq(0);
        projectId = project.attr("ProjectID");
        return projectId;
    },
    showDialig: function (obj, requestType, title, height) {
        var projectId = this.getProjectId(obj);
        if (projectId == "") {
            return false;
        }
        var fieldname = $(obj).attr("FieldName");
        var sectionname = $(obj).attr("SectionName");
        var url = encodeURI("Pages/Configuration/ManageConfiguration/FieldInfo.aspx?projectId=" + projectId + "&fieldname=" + fieldname + "&rt=" + requestType + "&section=" + sectionname + "&r=" + Math.random());
        var title = title + "|" + $(obj).attr("Caption");
        this.dialog(url, title, true, height);
    },
    edit: function (obj) {
        $(obj).parents("tr").eq(0).css("background", "#8B1A1A").css("color", "#fff");
        this.showDialig(obj, "edit", "编辑", 570);
        return false;
    },
    selectrule: function (obj) {
        this.showDialig(obj, "rule", "选择规则");
        return false;
    },
    selecttips: function (obj) {
        this.showDialig(obj, "tips", "选择带库");
        return false;

    },

    importFields: function (obj) {
        var projectId = this.getProjectId(obj);
        var url = Field.rootUrl + "/Pages/Configuration/ManageConfiguration/Field.aspx?projectId=" + projectId + "&import=1";
        this.dialog(url, "字段信息导入", false);
        return false;
    },
    dialog: function (url, title, close, height) {
        var m = parent.$.ligerDialog.open({
            height: height == null ? 400 : height,
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
            $(".reloadfields").click();
        }
    }

}

$(function () { })
{
    parent.$("#pageloading").hide();
}