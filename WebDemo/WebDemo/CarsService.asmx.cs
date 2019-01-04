using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Xml;

[System.Web.Script.Services.ScriptService]
public class CarsService : System.Web.Services.WebService
{
    private static XmlDocument _document;
    private static Regex _inputValidationRegex;
    private static object _lock = new object();

    public CarsService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /// <summary>
    /// 属性--获取xml数据。
    /// </summary>
    public static XmlDocument Document
    {
        get
        {
            lock (_lock)
            {
                if (_document == null)
                {
                    _document = new XmlDocument();
                    _document.Load(HttpContext.Current.Server.MapPath("~/App_Data/CascadingDropDownDemo.xml"));
                }
            }

            return _document;
        }
    }

    /// <summary>
    /// 属性--做什么用啊?-返回xml文件的层次
    /// </summary>
    public static string[] Hierarchy
    {
        get { return new string[] { "project" }; }
    }

    /// <summary>
    /// 属性--产生regex对象
    /// </summary>
    public static Regex InputValidationRegex
    {
        get
        {
            lock (_lock)
            {
                if (null == _inputValidationRegex)
                {
                    _inputValidationRegex = new Regex("^[0-9a-zA-Z //(//)]*$");
                }
            }

            return _inputValidationRegex;
        }
    }

    /// <summary>
    /// web服务帮助方法--用从数据源返回所需的数据。
    /// </summary>
    /// <param name="knownCategoryValues">就是选中的项，格式"分类名:值;分类名:值;",如"Make:Acura;","Make:Acura;Model:RL;"</param>
    /// <param name="category">总是级联dropdownlist中点击的下一个dropdownlist的分类名如"Model"</param>
    /// <returns></returns>
    [WebMethod]
    public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownContents(string knownCategoryValues, string category)
    {
        StringDictionary knownCategoryValuesDictionary = AjaxControlToolkit.CascadingDropDown.
            ParseKnownCategoryValuesString(knownCategoryValues);//记录的是已经选择的dropdownlist的选中项的名值对,可以是多个。
        //转换为特定的格式而已,把字符串形式转换为StringDictionary类型。

        return AjaxControlToolkit.CascadingDropDown.QuerySimpleCascadingDropDownDocument(
            Document, Hierarchy, knownCategoryValuesDictionary, category);//获取的下一项dropdownlist的内容。
        //从xml文档中获取指定的内容。
    }
    }
