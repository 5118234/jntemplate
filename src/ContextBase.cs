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
    public class ContextBase
    {
        private VariableScope variableScope;
        public VariableScope TempData
        {
            get { return variableScope;}
            set { variableScope = value; }
        }

        public ContextBase()
        {
            variableScope = new VariableScope();
        }
    }
}
