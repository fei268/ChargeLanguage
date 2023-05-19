using System;
using System.Collections.Specialized;
using System.Configuration;

namespace WindowsFormsApp1
{
    class Class1
    {
        public string chr { get; set; }
        /// <summary>
        /// 多语言选择，通过配置文件设置
        /// </summary>
        /// <param name="frmName"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public string Chargs(string frmName, string controlName)
        {
            if (chr==null)
            {
                try
                {
                    chr = ConfigurationManager.AppSettings["chargelang"];
                }
                catch (Exception ex)
                {
                    return "配置文件有错 "+ex.Message;
                }
            }
            
            string reStr = "";
            try
            {
                var res = (NameValueCollection)ConfigurationManager.GetSection("lang_" + chr.ToUpper() + "_" + frmName);
                
                if (res == null) { return controlName; } 
                if (res[controlName] == null)
                {
                    reStr = controlName;
                }
                else
                {
                    reStr = res[controlName];
                }
            }
            catch
            {
                reStr = controlName;
            }
            return reStr;
        }

    }
}
