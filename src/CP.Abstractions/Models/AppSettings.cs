namespace CP.Abstractions.Models
{
    public class AppSettings
    {
        public SettingsObject Settings { get; set; } = new SettingsObject();
        public ConnectionStringsObject ConnectionStrings { get; set; } = new ConnectionStringsObject();
        public SwaggerSettings Swagger { get; set; } = new SwaggerSettings();
        public SerilogSettings Serilog { get; set; } = new SerilogSettings();

        public class SettingsObject
        {
            public bool UseMockForDatabase { get; set; }
            public bool InTestMode { get; set; }
        }

        public class ConnectionStringsObject
        {
            public string ConnectionString { get; set; } = null!;
        }

        public class SwaggerSettings
        {
            public bool Enabled { get; set; }
            public string EndpointUrl { get; set; } = null!;
            public string EndpointName { get; set; } = null!;
            public List<SwaggerDocumentSettings> Documents { get; set; } = new List<SwaggerDocumentSettings>();
        }

        public class SwaggerDocumentSettings
        {
            public string Version { get; set; } = null!;
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
        }


        public class SerilogSinkArgs
        {
            public string? outputTemplate { get; set; }
            public string? path { get; set; }
            public string? rollingInterval { get; set; }
            public string? formatter { get; set; }
        }

        public class SerilogMinimumLevel
        {
            public string Default { get; set; } = null!;
            public SerilogOverride Override { get; set; } = new SerilogOverride();
        }

        public class SerilogOverride
        {
            public string Microsoft { get; set; } = null!;
            public string System { get; set; } = null!;
        }

        public class SerilogSettings
        {
            public List<string> Using { get; set; } = new List<string>();
            public SerilogMinimumLevel MinimumLevel { get; set; } = new SerilogMinimumLevel();
            public List<string> Enrich { get; set; } = new List<string>();
            public List<SerilogWriteTo> WriteTo { get; set; } = new List<SerilogWriteTo>();
        }

        public class SerilogWriteTo
        {
            public string Name { get; set; } = null!;
            public SerilogSinkArgs Args { get; set; } = new SerilogSinkArgs();
        }
    }
}
