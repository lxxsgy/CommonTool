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
     $('#dg').datagrid({

         url: '../handler/MainDemoHandler.ashx?methods=search',
         method: 'post',
         rownumbers: true,
         pageNumber: 1,
         pageSize: 5,
         pagination: true,
         fitColumns: true,
         remoteSort: true,
         singleSelect: true,
         loadMsg:"正在加载中。。。",
         pageList: [5,10,15,20],
         toolbar: "#td",
         idField:'mainid',
         columns: [[
             {
                 field: 'mainid',
                 checkbox: true,
             },
             {
                 field: 'PackageId',
                 title: '包号',
                 sortable: true,
                 width: 100,
                 align: 'center',
                 halign: 'center',
                 order: 'asc',
                 editor: {
                     type: 'numberbox',
                     options: {
                         required: true,
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
                     type: 'numberbox',
                     options: {
                         required:true,
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
                 editor: {
                     type: 'validatebox',
                     options: {
                         required: true,
                     }
                 }
             }
             
         ]],
         
         onAfterEdit: function (rowIndex, rowdata, changes) {
             var insertdata = $('#dg').datagrid("getChanges", "inserted");
             var updatedata = $('#dg').datagrid("getChanges", "updated");
           
             if (insertdata.length > 0) {
                 $.ajax({
                     url: '../handler/MainDemoHandler.ashx?methods=add',
                     type: 'post',
                     data: insertdata[0],
                     success: function (data) {
                         if (data == 1) {
                             obj.EditRow = undefined;
                             $("#save,#remove").hide();
                             //alert("插入成功");
                             $("#dg").datagrid("reload");

                         } else {
                             //alert("插入失败");

                             $("#dg").datagrid("beginEdit", obj.EditRow);

                         }
                     }, error: function () {
                         $("#dg").datagrid("beginEdit", obj.EditRow);
                        

                     }
                 }
                    
                 );
             }

             if (updatedata.length > 0) {
                 $.ajax({
                     url: '../handler/MainDemoHandler.ashx?methods=update',
                     type: 'post',
                     data: updatedata[0],
                     success: function (data) {
                         if (data == 1) {
                             obj.EditRow = undefined;
                             $("#save,#remove").hide();
                             alert("更新成功");
                             $("#dg").datagrid("reload");

                         } else {
                             //alert("插入失败");

                             $("#dg").datagrid("beginEdit", obj.EditRow);

                         }
                     }, error: function () {
                         $("#dg").datagrid("beginEdit", obj.EditRow);


                     }
                 }

                 );
             }

         },
         onCancelEdit:function() {
           
         },
         onBeforeEdit: function (rowindex, rowData) {
           
            // console.log(rowData);
         }

        
        
        
     });

    obj = {
         EditRow:undefined,
        search: function () {
            $("#dg").datagrid('load', {
                packageId: $.trim($('input[name="packageid"]').val()),
                pname: $('input[name="pname"]').val(),
                projectId: $('input[name="projectid"]').val(),
            }
            );
        },
        add: function () {

            if (this.EditRow == undefined) {
                $("#save,#remove").show();
                $('#dg').datagrid('insertRow', {
                    index: 0,   // 索引从0开始
                    row: {
                        //pname: '',
                        //projectid: '',
                        //packageid: ''
                    }
                });

                $('#dg').datagrid('beginEdit', 0);
                this.EditRow = 0;
            }
            
             
        },
        edit: function () {
            var row = $("#dg").datagrid("getSelected");
           
            var rowIndex = $("#dg").datagrid("getRowIndex", row);
            if (this.EditRow == undefined && rowIndex>=0) {
                $('#dg').datagrid("beginEdit", rowIndex);
                this.EditRow = rowIndex;
                $("#save,#remove").show();
            }
           
        },
        remove: function () {

            if (this.EditRow == undefined) {
                var array = [];
                var checkarray = $('#dg').datagrid("getChecked");
                console.log(checkarray);
                $.each(checkarray, function (index, item) {
                    if (item.mainid != null && item.mainid != undefined&& item.mainid !== '') {

                        array.push(item.mainid);
                    }
                });
                //console.log(array.join(','));
                if (array.length > 0) {
                    $.ajax({
                        url: '../handler/MainDemoHandler.ashx?methods=remove',
                        type: 'post',
                        data: {
                            mainid: array.join(','),
                        },
                        success: function (data) {
                            if (data == 1) {
                                obj.EditRow = undefined;
                                $("#save,#remove").hide();
                                alert("删除成功");
                                $("#dg").datagrid("reload");

                            }
                        }, error: function () {
                            //  $("#dg").datagrid("beginEdit", obj.EditRow);


                        }
                    });
                }

            }
           

        },
        save: function () {
            $('#dg').datagrid("acceptChanges");
        },
        redo: function () {
          
            $('#dg').datagrid("rejectChanges");
            this.EditRow = undefined;
            $("#save,#remove").hide();
        }
    };




   
                    

});

