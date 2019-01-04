 $(function () {
     $('#dg').datagrid({

         url: '../handler/MainDemoHandler.ashx',
         //url:'dataGrid.json',
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
                 editor: {
                     type: 'text',
                     options: {

                         required:true
                     }

                 }
             },
             {
                field:'Pname',
                title: '包名',
                 sortable: true,
                 width: 100,
                 editor: {
                     type: 'text',
                     options: {

                         required: true
                     }

                 }
               
            }, {
                field: 'ProjectId',
                title: '项目ID',
                 sortable: true,
                 width: 100,
                editor: {
                     type: 'text',
                     options: {

                         required: true
                     }

                 }
             },
         ]] 
        
     });
     
     

    
     obj = {
         search: function () {
             $("#dg").datagrid('load', {
                 packageId: $.trim($('input[name="packageid"]').val()),
                 pname: $('input[name="pname"]').val(),
                 projectId: $('input[name="projectid"]').val(),
             }
             );
         }
     };
   
                    

});

