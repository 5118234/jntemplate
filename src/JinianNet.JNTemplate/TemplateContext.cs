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
    /// <summary>
    /// Context
    /// </summary>
    public class TemplateContext : ContextBase
    {
        /// <summary>
        /// Context
        /// </summary>
        public TemplateContext()
        {
            this.Charset = System.Text.Encoding.Default;
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

        /// <summary>
        /// ģ����Դ·��
        /// </summary>
        [Obsolete("��ʹ��Resources.Paths �����������")]
        public List<String> Paths
        {
            get { return Resources.Paths; }
            private set
            {
                //if (!Resources.Paths.Contains(value))
                //{
                    Resources.Paths.AddRange(value);
                //}
            }
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