/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;

namespace JinianNet.JNTemplate.Node
{
    /// <summary>
    /// LOAD标签
    /// </summary>
    public class LoadTag : BlockTag
    {
        private Tag _path;
        /// <summary>
        /// 路径
        /// </summary>
        public Tag Path
        {
            get { return this._path; }
            set { this._path = value; }
        }
        /// <summary>
        /// 解析标签
        /// </summary>
        /// <param name="context">上下文</param>
        public override Object Parse(TemplateContext context)
        {
            Object path = this._path.Parse(context);
            LoadResource(path, context);
            return base.Parse(context);
        }
        /// <summary>
        /// 解析标签
        /// </summary>
        /// <param name="context">上下文</param>
        /// <param name="write">write</param>
        public override void Parse(TemplateContext context, TextWriter write)
        {
            Object path = this._path.Parse(context);
            LoadResource(path, context);
            base.Parse(context, write);
        }

        private void LoadResource(Object path, TemplateContext context)
        {
            if (path != null)
            {
                string[] paths = null;
                if (!string.IsNullOrEmpty(context.CurrentPath))
                {
                    paths = new[] { context.CurrentPath };
                }
                ResourceInfo info = Engine.Runtime.Load(path.ToString(), context.Charset, paths);
                if (info != null)
                {
                    TemplateContent = info.Content;
                }

            }
        }
    }
}