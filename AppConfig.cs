namespace WEB_API
{
    public class AppConfig
    {
        private static IConfiguration _iconfiguration;
        static AppConfig()
        {
            GetAppSettingsFile();
        }
        public static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional:false, reloadOnChange:true);
            _iconfiguration = builder.Build();
            
        }
        public static string GetConnectionString()
        {
            var connectionString = _iconfiguration["ConnectionString"];
            return connectionString;
        }

    }
}
