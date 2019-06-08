using System.Configuration;

namespace Deck
{
    public class AppSettings : ConfigurationSection
    {
        /// <summary>
        /// Выбор способа перетасовки из конфигурационного файла
        /// </summary>
        [ConfigurationProperty("MixerType", DefaultValue = "1", IsRequired = true)]
        public int MixerType
        {
            get { return (int)this["MixerType"]; }
            set { this["MixerType"] = value; }
        }
    }
}



