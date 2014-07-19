/*****************************************************
 * �����ĺ���ϵ JNTemplate
 * ���ߣ����ĳ��� QQ:4585839
 * Mail: i@Jiniannet.com
 * ��ַ��http://www.JiNianNet.com
 *****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using JinianNet.JNTemplate.Parser;

namespace JinianNet.JNTemplate
{
    public class TemplateContext : ContextBase
    {
        public TemplateContext()
        {
            this.Charset = System.Text.Encoding.Default;
            this.Paths = new List<String>();
        }

        private String _currentPath;
        /// <summary>
        /// ��ǰ��Դ·��
        /// </summary>
        public String CurrentPath
        {
            get { return _currentPath; }
            set { _currentPath = value; }
        }

        private Encoding _charset;
        /// <summary>
        /// ��ǰ��Դ����
        /// </summary>
        public Encoding Charset
        {
            get { return _charset; }
            set { _charset = value; }
        }

        //private List<ITagParser> _parser;
        //public List<ITagParser> Parser
        //{
        //    get { return _parser; }
        //    private set { _parser = value; }
        //}

        private List<String> _paths;
        [Obsolete("��ʹ��Resources.Paths �����������")]
        /// <summary>
        /// ģ������·��
        /// </summary>
        public List<String> Paths
        {
            get { return _paths; }
            private set { _paths = value; }
        }
        /// <summary>
        /// ��ָ��TemplateContext����һ�����Ƶ�ʵ��
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static TemplateContext CreateContext(TemplateContext context)
        {
            TemplateContext ctx = (TemplateContext)context.Clone();
            ctx.TempData = new VariableScope(context.TempData);
            return ctx;
        }

    }
}