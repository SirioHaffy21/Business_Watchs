using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Business_Watch.Localization
{
    public static class Business_WatchLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(Business_WatchConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(Business_WatchLocalizationConfigurer).GetAssembly(),
                        "Business_Watch.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
