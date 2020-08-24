﻿using Microsoft.Extensions.Configuration;

namespace Settings
{
    public class CommonSettings
    {
        private readonly IConfiguration Configuration;
        
        public CommonSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetJwtSecret()
        {
            return Configuration["JWT:Key"];
        }
    }
}