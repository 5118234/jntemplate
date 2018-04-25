﻿//#define VER_EQ_TEST
//#define NVELOCITY_TEST
#define BASE_PAGE_TEST
#define WIN  
#if WIN
using System.IO;
using System.Reflection;
using System;
using JinianNet.JNTemplate.Test.Model;
using System.Diagnostics;
using Xunit;

namespace JinianNet.JNTemplate.Test
{
    /// <summary>
    /// 实际WEB页面模板测试
    /// </summary>
    public class WebPageTests
    {
        const int MAX_RUN_COUNT = 10000;
#if BASE_PAGE_TEST
        [Fact]
        public void TestILVsReflectionPage()
        {

            JinianNet.JNTemplate.TemplateContext ctx = new JinianNet.JNTemplate.TemplateContext();
            ctx.TempData.Push("func", new TemplateMethod());
            SiteInfo site = new SiteInfo();
            site.Copyright = "&copy;2014 - 2015";
            site.Description = "";
            site.Host = "localhost";
            site.KeyWords = "";
            site.Logo = "";
            site.Name = "xxx";
            site.SiteDirectory = "";
            site.Theme = "Blue";
            site.ThemeDirectory = "theme";
            site.Title = "jntemplate测试页";
            site.Url = string.Concat("http://localhost");

            if (!string.IsNullOrEmpty(site.SiteDirectory) && site.SiteDirectory != "/")
            {
                site.Url += "/" + site.SiteDirectory;
            }
            site.ThemeUrl = string.Concat(site.Url, "/", site.ThemeDirectory, "/", site.Theme);
            //ctx.TempData.Push("Model", );
            ctx.TempData.Push("Site", site);

            string basePath = new System.IO.DirectoryInfo(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = basePath + "\\templets\\default";
           // JinianNet.JNTemplate.Dynamic.IDynamicHelpers h;
            Configuration.EngineConfig conf;
 
            string text1 = null, text2 = null;
            string result="";
            Stopwatch s = new Stopwatch();
            s.Start();
            s.Stop();
            ////////////////////////////////////////////////////////////////////////////////////
            //h = new JinianNet.JNTemplate.Dynamic.ILHelpers();
            conf = Configuration.EngineConfig.CreateDefault(); 
            Engine.Configure(conf); 
            s.Restart();

            for (var i = 0; i < MAX_RUN_COUNT; i++)
            {
                JinianNet.JNTemplate.Template t = new JinianNet.JNTemplate.Template(ctx, System.IO.File.ReadAllText(path + "\\questionlist.html"));

                t.Context.CurrentPath = path;
                text1 = t.Render();

            }
            s.Stop();
            result += "\r\n耗时：" + s.ElapsedMilliseconds + "毫秒 - 反射(" + MAX_RUN_COUNT + "次)运行";
            ////////////////////////////////////////////////////////////////////////////////////

            GC.Collect();


            ////////////////////////////////////////////////////////////////////////////////////
            //h = new JinianNet.JNTemplate.Dynamic.ReflectionHelpers();
            conf = Configuration.EngineConfig.CreateDefault();
            conf.CachingProvider = new UserCache(); 
            Engine.Configure(conf);
            s.Restart();
            for (var i = 0; i < MAX_RUN_COUNT; i++)
            {
                JinianNet.JNTemplate.Template t = new JinianNet.JNTemplate.Template(ctx, System.IO.File.ReadAllText(path + "\\questionlist.html"));

                t.Context.CurrentPath = path;
                text2 = t.Render();
                //h.ExcuteMethod(DateTime.Now, "AddDays", new object[] { 30 });
            }
            s.Stop();
            ////////////////////////////////////////////////////////////////////////////////////

            result += "\r\n耗时：" + s.ElapsedMilliseconds + "毫秒 - IL(" + MAX_RUN_COUNT + "次)运行";

            System.IO.File.WriteAllText(basePath + "\\TestResult\\ILVsReflection.txt", result);
            Assert.Equal(text1, text2);

        }


        [Fact]
        public void TestILage()
        {

            JinianNet.JNTemplate.TemplateContext ctx = new JinianNet.JNTemplate.TemplateContext();
            ctx.TempData.Push("func", new TemplateMethod());
            SiteInfo site = new SiteInfo();
            site.Copyright = "&copy;2014 - 2015";
            site.Description = "";
            site.Host = "localhost";
            site.KeyWords = "";
            site.Logo = "";
            site.Name = "xxx";
            site.SiteDirectory = "";
            site.Theme = "Blue";
            site.ThemeDirectory = "theme";
            site.Title = "jntemplate测试页";
            site.Url = string.Concat("http://localhost");

            if (!string.IsNullOrEmpty(site.SiteDirectory) && site.SiteDirectory != "/")
            {
                site.Url += "/" + site.SiteDirectory;
            }
            site.ThemeUrl = string.Concat(site.Url, "/", site.ThemeDirectory, "/", site.Theme);
            //ctx.TempData.Push("Model", );
            ctx.TempData.Push("Site", site);

            string basePath = new System.IO.DirectoryInfo(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = basePath + "\\templets\\default";

            var conf = Configuration.EngineConfig.CreateDefault();
            conf.CachingProvider = new UserCache();
            conf.ExecuteProvider = new ILExecutor();// new TestExecutor();
            Engine.Configure(conf);
            Stopwatch s = new Stopwatch();
            s.Start();
            for (var i = 0; i < MAX_RUN_COUNT; i++)
            {
                JinianNet.JNTemplate.Template t = new JinianNet.JNTemplate.Template(ctx, System.IO.File.ReadAllText(path + "\\questionlist.html"));
                t.Context.CurrentPath = path;
                if (i == MAX_RUN_COUNT - 1)
                {
                    System.IO.File.WriteAllText(basePath + "\\TestResult\\IL.html", t.Render());
                }
                else
                {
                    t.Render();
                }

            }
            s.Stop();
            string result = "\r\n运行耗时：" + s.ElapsedMilliseconds + "毫秒 IL(" + MAX_RUN_COUNT + "次)";
            System.IO.File.AppendAllText(basePath + "\\TestResult\\ILVsReflection.txt", result);

        }
           [Fact]
        public void TestReflectionPage()
        {

            JinianNet.JNTemplate.TemplateContext ctx = new JinianNet.JNTemplate.TemplateContext();
            ctx.TempData.Push("func", new TemplateMethod());
            SiteInfo site = new SiteInfo();
            site.Copyright = "&copy;2014 - 2015";
            site.Description = "";
            site.Host = "localhost";
            site.KeyWords = "";
            site.Logo = "";
            site.Name = "xxx";
            site.SiteDirectory = "";
            site.Theme = "Blue";
            site.ThemeDirectory = "theme";
            site.Title = "jntemplate测试页";
            site.Url = string.Concat("http://localhost");

            if (!string.IsNullOrEmpty(site.SiteDirectory) && site.SiteDirectory != "/")
            {
                site.Url += "/" + site.SiteDirectory;
            }
            site.ThemeUrl = string.Concat(site.Url, "/", site.ThemeDirectory, "/", site.Theme);
            //ctx.TempData.Push("Model", );
            ctx.TempData.Push("Site", site);

            string basePath = new System.IO.DirectoryInfo(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = basePath + "\\templets\\default";

            var conf = Configuration.EngineConfig.CreateDefault();
            Engine.Configure(conf);

            Stopwatch s = new Stopwatch();
            s.Start();
            for (var i = 0; i < MAX_RUN_COUNT; i++)
            {
                JinianNet.JNTemplate.Template t = new JinianNet.JNTemplate.Template(ctx, System.IO.File.ReadAllText(path + "\\questionlist.html"));
                t.Context.CurrentPath = path;
                if (i == MAX_RUN_COUNT - 1)
                {
                    System.IO.File.WriteAllText(basePath + "\\TestResult\\REFLECTION.html", t.Render());
                }
                else
                {
                    t.Render();
                }

            }
            s.Stop();
            string result = "\r\n运行耗时：" + s.ElapsedMilliseconds + "毫秒 反射(" + MAX_RUN_COUNT + "次)";
            System.IO.File.AppendAllText(basePath + "\\TestResult\\ILVsReflection.txt", result);
        }


        [Fact]
        public void TestPage()
        {
            var conf = Configuration.EngineConfig.CreateDefault(); 
            Engine.Configure(conf);

            JinianNet.JNTemplate.TemplateContext ctx = new JinianNet.JNTemplate.TemplateContext();

            ctx.TempData.Push("func", new TemplateMethod());

            SiteInfo site = new SiteInfo();
            site.Copyright = "&copy;2014 - 2015";
            site.Description = "";
            site.Host = "localhost";
            site.KeyWords = "";
            site.Logo = "";
            site.Name = "xxx";
            site.SiteDirectory = "";
            site.Theme = "Blue";
            site.ThemeDirectory = "theme";
            site.Title = "jntemplate测试页";
            site.Url = string.Concat("http://localhost");

            if (!string.IsNullOrEmpty(site.SiteDirectory) && site.SiteDirectory != "/")
            {
                site.Url += "/" + site.SiteDirectory;
            }
            site.ThemeUrl = string.Concat(site.Url, "/", site.ThemeDirectory, "/", site.Theme);
            //ctx.TempData.Push("Model", );
            ctx.TempData.Push("Site", site);

            string basePath = new System.IO.DirectoryInfo(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = basePath + "\\templets\\default";

            JinianNet.JNTemplate.Template t = new JinianNet.JNTemplate.Template(ctx, System.IO.File.ReadAllText(path + "\\questionlist.html"));
            t.Context.CurrentPath = path;

            string result = t.Render();

            //可直接查看项目录下的html/jnt.html 文件效果
            System.IO.File.WriteAllText(basePath + "\\TestResult\\jnt.html", result);

        }
#endif
#if VER_EQ_TEST
        /// <summary>
        /// 多版本比较测试
        /// </summary>
        [Fact]
        public void TestVER_EQ_TESTsion()
        {
            var tm = new TemplateMethod();
            SiteInfo site = new SiteInfo();
            site.Copyright = "&copy;2014 - 2015";
            site.Description = "";
            site.Host = "localhost";
            site.KeyWords = "";
            site.Logo = "";
            site.Name = "xxx";
            site.SiteDirectory = "";
            site.Theme = "Blue";
            site.ThemeDirectory = "theme";
            site.Title = "jntemplate测试页";
            site.Url = string.Concat("http://localhost");
            if (!string.IsNullOrEmpty(site.SiteDirectory) && site.SiteDirectory != "/")
            {
                site.Url += "/" + site.SiteDirectory;
            }
            site.ThemeUrl = string.Concat(site.Url, "/", site.ThemeDirectory, "/", site.Theme);
            string basePath = new System.IO.DirectoryInfo(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = basePath + "\\templets\\default";

            string content = System.IO.File.ReadAllText(path + "\\questionlist.html");

            FileInfo[] assFlies = new DirectoryInfo(basePath + "\\dll").GetFiles("JinianNet.JNTemplate*.dll");
            string result = DateTime.Now.ToString();
            Stopwatch s = new Stopwatch();
            for (int i = 0; i < assFlies.Length; i++)
            {
                Assembly ass = System.Reflection.Assembly.LoadFile(assFlies[i].FullName);
                object ctx = ass.CreateInstance("JinianNet.JNTemplate.TemplateContext");
                object data = ctx.GetType().GetProperty("TempData").GetValue(ctx, null);
                MethodInfo mi = data.GetType().GetMethod("Push");
                mi.Invoke(data, new object[] { "func", tm });
                mi.Invoke(data, new object[] { "Site", site });
                ctx.GetType().GetProperty("CurrentPath").SetValue(ctx, path, null);

                s.Restart();
                for (int j = 0; j < MAX_RUN_COUNT; j++)
                {
                    object t = ass.CreateInstance("JinianNet.JNTemplate.Template"); ;
                    t.GetType().GetProperty("Context").SetValue(t, ctx, null);
                    t.GetType().GetProperty("TemplateContent").SetValue(t, content, null);
                    object r = t.GetType().GetMethod("Render", new Type[0]).Invoke(t, new object[0] { });

                    if (j == MAX_RUN_COUNT-1)
                    {
                        System.IO.File.WriteAllText(basePath + "\\TestResult\\"+ assFlies[i].Name +".html", r.ToString());
                    }
                }
                s.Stop();
                result += "\r\n:耗时：" + s.ElapsedMilliseconds.ToString() + "毫秒 次数:"+ MAX_RUN_COUNT + " 文件:" + assFlies[i].Name + " 版本号：" + ass.GetName().Version;
                System.Threading.Thread.Sleep(200);
            }
            if (System.IO.File.Exists(basePath + "\\TestResult\\TestResult.txt"))
            {
                if (System.IO.File.GetLastWriteTime(basePath + "\\TestResult\\TestResult.txt").Date == DateTime.Now.Date)
                {
                    result = System.IO.File.ReadAllText(basePath + "\\TestResult\\TestResult.txt") + "\r\n" + result;
                }
            }

            System.IO.File.WriteAllText(basePath + "\\TestResult\\TestResult.txt", result);
        }
#endif

#if NVELOCITY_TEST
        [Fact]
        public void TestJuxtaposePage()
        {
            SiteInfo site = new SiteInfo();
            site.Copyright = "&copy;2014 - 2015";
            site.Description = "";
            site.Host = "localhost";
            site.KeyWords = "";
            site.Logo = "";
            site.Name = "xxx";
            site.SiteDirectory = "";
            site.Theme = "Blue";
            site.ThemeDirectory = "theme";
            site.Title = "jntemplate测试页";
            site.Url = string.Concat("http://localhost");

            if (!string.IsNullOrEmpty(site.SiteDirectory) && site.SiteDirectory != "/")
            {
                site.Url += "/" + site.SiteDirectory;
            }
            site.ThemeUrl = string.Concat(site.Url, "/", site.ThemeDirectory, "/", site.Theme);


            string basePath = new System.IO.DirectoryInfo(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            string path = basePath + "\\templets\\nv";


            NVelocity.Context.IContext ctx = new NVelocity.VelocityContext();
            ctx.Put("func", new TemplateMethod());
            ctx.Put("Site", site);



            NVelocity.App.VelocityEngine velocity = new NVelocity.App.VelocityEngine();
            Commons.Collections.ExtendedProperties props = new Commons.Collections.ExtendedProperties();
            props.AddProperty(NVelocity.Runtime.RuntimeConstants.RESOURCE_LOADER, "file");
            props.AddProperty(NVelocity.Runtime.RuntimeConstants.FILE_RESOURCE_LOADER_PATH, path);
            props.AddProperty(NVelocity.Runtime.RuntimeConstants.INPUT_ENCODING, "utf-8");
            props.AddProperty(NVelocity.Runtime.RuntimeConstants.OUTPUT_ENCODING, "utf-8");
            velocity.Init(props);
            NVelocity.Template t = velocity.GetTemplate("questionlist.html");
            string result;
            using (System.IO.StringWriter write = new StringWriter())
            {
                t.Merge(ctx, write);
                result = write.ToString();
            }

            //可直接查看项目录下的html/nv.html 文件效果
            System.IO.File.WriteAllText(basePath + "\\TestResult\\nv.html", result);
        }
#endif
    }
}
#endif