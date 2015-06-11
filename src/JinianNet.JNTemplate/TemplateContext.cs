/*****************************************************
   Copyright (c) 2013-2015 jiniannet (http://www.jiniannet.com)

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

   Redistributions of source code must retain the above copyright notice
 *****************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using JinianNet.JNTemplate.Parser;
using JinianNet.JNTemplate.Configuration;

namespace JinianNet.JNTemplate
{
    /// <summary>
    /// Context
    /// </summary>
    public class TemplateContext : ICloneable
    {
        private VariableScope variableScope;
        private ITemplateConfiguration config;
        private String currentPath;
        private Encoding charset;
        private Boolean throwErrors;

        /// <summary>
        /// ģ��������
        /// </summary>
        public TemplateContext()
            : this(new DefaultConfiguration())
        {

        }

        /// <summary>
        /// ģ��������
        /// </summary>
        /// <param name="config"></param>
        public TemplateContext(ITemplateConfiguration config)
        {
            this.Charset = System.Text.Encoding.Default;
            this.ThrowExceptions = true;
            this.config = config;
        }

        /// <summary>
        /// ģ������
        /// </summary>
        public VariableScope TempData
        {
            get { return variableScope; }
            set { variableScope = value; }
        }

        /// <summary>
        /// ��ǰ��Դ·��
        /// </summary>
        public String CurrentPath
        {
            get { return currentPath; }
            set { currentPath = value; }
        }

        /// <summary>
        /// ��ǰ��Դ����
        /// </summary>
        public Encoding Charset
        {
            get { return charset; }
            set { charset = value; }
        }

        /// <summary>
        /// ģ����Դ·��
        /// </summary>
        [Obsolete("��ʹ��Config.Paths �����������")]
        public ICollection<String> Paths
        {
            get { return Config.Paths; }
        }

        /// <summary>
        /// �Ƿ��׳��쳣(Ĭ��Ϊtrue)
        /// </summary>
        public Boolean ThrowExceptions
        {
            get { return throwErrors; }
            set { throwErrors = value; }
        }

        /// <summary>
        /// ģ����������
        /// </summary>
        public ITemplateConfiguration Config
        {
            get { return config; }
            set { config = value; }
        }

        //public virtual System.Exception[] AllErrors
        //{
        //    get
        //    {
        //        return null;       //������δʵ��
        //    }
        //}

        ///// <summary>
        ///// ��ȡ��ǰ��һ���쳣��Ϣ
        ///// </summary>
        //public virtual System.Exception Error
        //{
        //    get
        //    {
        //        if (this.AllErrors.Length > 0)
        //        {
        //            return this.AllErrors[0];
        //        }

        //        return null;
        //    }
        //}

        /// <summary>
        /// ���쳣��ӵ���ǰ �쳣�����С�
        /// </summary>
        /// <param name="e">�쳣</param>
        public void AddError(System.Exception e)
        {
            //������δʵ��
        }

        /// <summary>
        /// ��������쳣
        /// </summary>
        public void ClearError()
        {
            //������δʵ��
        }

        /// <summary>
        /// ��ָ��TemplateContext����һ�����Ƶ�ʵ��
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static TemplateContext CreateContext(TemplateContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            TemplateContext ctx = new TemplateContext();
            ctx.TempData = new VariableScope(context.TempData);
            ctx.Charset = context.Charset;
            ctx.CurrentPath = context.CurrentPath;
            ctx.ThrowExceptions = context.ThrowExceptions;
            return ctx;
        }

        #region ICloneable ��Ա
        /// <summary>
        /// ǳ��¡��ǰʵ��
        /// </summary>
        /// <returns></returns>
        public Object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}