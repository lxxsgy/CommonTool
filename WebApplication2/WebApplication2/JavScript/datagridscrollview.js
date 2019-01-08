$(function () {
   
    //$('#dg').datagrid({

    //    url: '../handler/MainDemoHandler.ashx?methods=search',
    //   // method: 'post',
    //    rownumbers: true,
    //    // pagination: true,
    //   // fitColumns: true,
    //   // remoteSort: true,
    //    singleSelect: true,
    //    loadMsg: "正在加载中。。。",
    //    //  pageList: [5,10,15,20],
    //   // toolbar: "#td",
    //    //view: 'scrollview',
    //    autoRowHeight: false,
    //    pageSize: 50,
    //    columns: [[
    //        {
    //            field: 'mainid',
    //            checkbox: true,
    //        },
    //        {
    //            field: 'PackageId',
    //            title: '包号',
    //            width: 100,
    //            align: 'center',
    //            halign: 'center',
               
    //        },
    //        {
    //            field: 'Pname',
    //            title: '包名',
    //            width: 100,
    //            align: 'center',
    //            halign: 'center',
               
    //        }, {
    //            field: 'ProjectId',
    //            title: '项目ID',
    //            width: 100,
    //            align: 'center',
    //            halign: 'center',
              
    //        }

    //    ]],



   // });

    $('#dg').datagrid({
        view: detailview,
        detailFormatter: function (index, row) {
            return '<div class="ddv" style="padding:5px 0"></div>';
        },
        onExpandRow: function (index, row) {
            var ddv = $(this).datagrid('getRowDetail', index).find('div.ddv');
            ddv.panel({
                border: false,
                cache: false,
                href: '../handler/MainDemoHandler.ashx?methods=search&mainid=' + row.mainid,
                onLoad: function () {
                    $('#dg').datagrid('fixDetailRowHeight', index);
                }
            });
            $('#dg').datagrid('fixDetailRowHeight', index);
        }
    });




   
                    

});

