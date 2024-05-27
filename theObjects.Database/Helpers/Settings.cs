using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace theObjects.Database.Helpers
{
    internal static class Settings
    {
        public static string ConnectionString
        {
            get 
            {
                try
                {
                    IConfigurationBuilder builder = new ConfigurationBuilder();
                    builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

                    var root = builder.Build();
                    var connectionString = root.GetConnectionString("DefaultConnection");

                    return string.IsNullOrEmpty(connectionString) ? "" : connectionString;
                }
                catch (Exception)
                {
                    return string.Empty;
                }                
            }
        }
    }
}
