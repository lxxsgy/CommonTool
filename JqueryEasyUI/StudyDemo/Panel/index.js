$(function(){

 $.messager.confirm('Confirm','Are you sure you want to delete record?',function(r){
    if (r){
        alert('ok');
    }
});});