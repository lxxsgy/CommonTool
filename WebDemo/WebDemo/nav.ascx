<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="nav.ascx.cs" Inherits="WebDemo.nav" %>
<style type="text/css">
       #nav{
           margin:0;
           background:#669900;
           width:100%;
           border-bottom:1px solid #006600;
           border-top:1px solid #006600;
           border-left:none;
           border-right:1px solid #006600;
          font-size:30px;
       }
        #nav ul li{
            float:left;
            margin-right:50px;
        }
       #nav ul{
          list-style:none;
          display:inline-block;
          
       }
</style>
 <div id="nav">
     <ul>
         <li><a href="#">新闻</a></li>
           <li><a href="#">网页</a></li>
           <li><a href="#">音乐</a></li>
           <li><a href="#">贴吧</a></li>
           <li><a href="#">知道</a></li>
         <li id="special"><a href="#">地图</a></li>
     </ul>&nbsp;

 </div>