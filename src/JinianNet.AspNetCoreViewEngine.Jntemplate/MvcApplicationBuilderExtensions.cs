﻿using JinianNet.AspNetCoreViewEngine.Jntemplate.Configuration;
using JinianNet.JNTemplate;
using JinianNet.JNTemplate.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace JinianNet.AspNetCoreViewEngine.Jntemplate
{
    /// <summary>
    /// 
    /// </summary>
    public static class MvcApplicationBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param> 
        /// <param name="configureEngine">A setup action that configures the <see cref="JntemplateConfig"/>.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseJntemplate(this IApplicationBuilder app, Action<JntemplateConfig> configureEngine = null)
        {
            var conf = new JntemplateConfig();
            conf.Data = new VariableScope(null, TypeDetect.Standard);
            configureEngine?.Invoke(conf);
            if (conf.Data != null && conf.Data.Count > 0)
            {
                Engine.Configure(conf, conf.Data);
            }
            else
            {
                Engine.Configure(conf);
            }
            if (string.IsNullOrWhiteSpace(conf.ContentRootPath))
            {
                conf.ContentRootPath = System.IO.Directory.GetCurrentDirectory();
            }
            Engine.Current.AppendResourcePath(conf.ContentRootPath);
            return app;
        }
    }
}
