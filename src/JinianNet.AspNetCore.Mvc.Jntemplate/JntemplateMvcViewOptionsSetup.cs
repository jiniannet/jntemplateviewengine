﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using JinianNet.JNTemplate;
using JinianNet.JNTemplate.Configuration;

namespace JinianNet.AspNetCore.Mvc.Jntemplate
{
    public class JntemplateMvcViewOptionsSetup : IConfigureOptions<MvcViewOptions>
    {
        private readonly IJntemplateViewEngine _viewEngine;

        public JntemplateMvcViewOptionsSetup(IJntemplateViewEngine viewEngine)
        {
            _viewEngine = viewEngine ?? 
                throw new ArgumentNullException(nameof(viewEngine));
        }

        public void Configure(MvcViewOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            //获取默认配置
            var conf = EngineConfig.CreateDefault();
            //初始化配置
            Engine.Configure(conf);
            options.ViewEngines.Insert(0,_viewEngine);
        }
    }
}
