/********************************************************************************
 Copyright (c) jiniannet (http://www.jiniannet.com). All rights reserved.
 Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
 ********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using JinianNet.JNTemplate.Configuration;

namespace JinianNet.JNTemplate
{
    /// <summary>
    /// ����ʱ
    /// </summary>
    public class Runtiome
    {
        private static JinianNet.JNTemplate.Caching.ICache cache;
        private static JinianNet.JNTemplate.Parser.TagTypeResolver resolver;
        private static Char tagFlag;
        private static String tagPrefix;
        private static String tagSuffix;
        private static Boolean runing;

        private Runtiome()
        {

        }

        static Runtiome()
        {
            //Configure(new Config());
            runing = false;
        }

        internal static void Configure(ITemplateConfig config)
        {
            if (!runing)
            {
                cache = config.CachingProvider;
                //resolver = config.Resolver;
                tagFlag = config.TagFlag;
                tagSuffix = config.TagSuffix;
                tagPrefix = config.TagPrefix;
            }
        }

        /// <summary>
        /// ��ԴĿ¼
        /// </summary>
        /// <returns></returns>
        public static String[] ResourceDirectories()
        {
            return null;
        }

        /// <summary>
        /// ��д��ǩ���
        /// </summary>
        public static Char TagFlag
        {
            get { return tagFlag; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public static JinianNet.JNTemplate.Caching.ICache Cache
        {
            get { return cache; }
        }

        /// <summary>
        /// ��ǩ���ͽ�����
        /// </summary>
        public static Parser.ITagTypeResolver TagResolver
        {
            get { return resolver; }
        }


        /// <summary>
        /// ������ǩǰ׺
        /// </summary>
        public static string TagPrefix
        {
            get { return tagPrefix; }
        }

        /// <summary>
        /// ������ǩ��׺
        /// </summary>
        public static string TagSuffix
        {
            get { return tagSuffix; }
        }
    }

}