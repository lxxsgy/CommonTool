$(function () {
    $.extend($.fn.datagrid.defaults.editors, {
        text: {
            init: function (container, options) {
                var input = $('<input type="text" class="datagrid-editable-input">').appendTo(container);
                return input;
            },
            destroy: function (target) {
                $(target).remove();
            },
            getValue: function (target) {
                return $(target).val();
            },
            setValue: function (target, value) {
                $(target).val(value);
            },
            resize: function (target, width) {
                $(target)._outerWidth(width);
            }
        }
    });
    var lastRowIndex=0;
     $('#dg').datagrid({

         url: '../handler/MainDemoHandler.ashx',
         method: 'post',
         rownumbers: true,
         checkOnSelect: false,
         selectOnCheck: false,
         pageNumber: 1,
         pageSize: 1,
         pagination: true,
         fitColumns: true,
         remoteSort: true,
         singleSelect: true,
         loadMsg:"正在加载中。。。",
         pageList: [1, 2, 3, 10],
         toolbar: "#td",
         columns: [[
             {
                 field: 'PackageId',
                 title: '包号',
                 sortable: true,
                 width: 100,
                 align: 'center',
                 halign: 'center',
                 order: 'asc',
                 editor: {
                     type: 'text',
                     options: {

                     }
                 }
             },
             {
                field:'Pname',
                title: '包名',
                 sortable: true,
                 width: 100,
                 align: 'center',
                 halign: 'center',
                 order: 'asc',
                 editor: {
                     type: 'text',
                     options: {

                     }
                 }
                
            }, {
                field: 'ProjectId',
                title: '项目ID',
                 sortable: true,
                 width: 100,
                 align: 'center',
                 halign: 'center',
                 order: 'asc',
                 //checkbox:true
                 editor: {
                     type: 'text',
                     options: {

                     }
                 }
             }
             
         ]],
         //onClickRow: function (rowIndex,rowData) {

            
         //        $("#dg").datagrid("endEdit", lastRowIndex);
         //        $("#dg").datagrid("beginEdit", rowIndex);
         //      lastRowIndex = rowIndex;
             
         //},
         //onClickCell: function (rowIndex, field, value) {

            
         //},
         onAfterEdit: function (rowIndex, rowIndex, changes) {

            



         },
         //onCancelEdit: function (rowIndex, rowIndex) {

            
         //},
         //onSelect: function (rowIndex, rowdata) {
         //   // alert(rowIndex);
         //},
         //onUnselect: function (rowIndex,rowdata) {
         //    alert(rowIndex);
         //},
         //onCheck: function (rowIndex, rowData) {
         //    console.log(rowData);
         //},
         //onSelectAll: function (rows) {
           
         //}
        
        
     });
     
     

    
     //obj = {
     //    search: function () {
     //      //  console.log($("#dg").datagrid('getSelections'));
     //        $("#dg").datagrid('checkAll');
     //       // console.log($("#dg").datagrid('getRows'));
     //    }
     //};
    obj = {
        search: function () {
            $("#dg").datagrid('load', {
                packageId: $.trim($('input[name="packageid"]').val()),
                pname: $('input[name="pname"]').val(),
                projectId: $('input[name="projectid"]').val(),
            }
            );
        },
        add: function () {

        },
        edit: function () {

        },
        remove: function () {

        }
    };




   
                    

});

