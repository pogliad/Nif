using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Nif.Extensions;

namespace Nif.Utilities
{
    public static class TransliterationUtility
    {
        public static string Transliterate<T>(string source) where T : ITransliterationDictionary
        {
            Contract.Requires<ArgumentNullException>(source.IsNotNullOrEmpty());

            var dictionary = (T)Activator.CreateInstance(typeof(T));

            return dictionary.Items.Aggregate(source, (current, key) => current.Replace(key.Key, key.Value));
        }
    }

    public interface ITransliterationDictionary
    {
        IDictionary<string, string> Items { get; }
    }

    /// <summary>
    /// Система транслитерации Госдепартамента США
    /// </summary>
    public class BsiRuUs : ITransliterationDictionary
    {
        private readonly IDictionary<string, string> _items;

        public IDictionary<string, string> Items { get { return _items; } }

        public BsiRuUs()
        {
            _items = new Dictionary<string, string>
            {
                {"а", "a"},
                {"б", "b"},
                {"в", "v"},
                {"г", "g"},
                {"д", "d"},
                {"е", "e"},
                {"ё", "e"},
                {"ж", "zh"},
                {"з", "z"},
                {"и", "i"},
                {"й", "y"},
                {"к", "k"},
                {"л", "l"},
                {"м", "m"},
                {"н", "n"},
                {"о", "o"},
                {"п", "p"},
                {"р", "r"},
                {"с", "s"},
                {"т", "t"},
                {"у", "u"},
                {"ф", "f"},
                {"х", "kh"},
                {"ц", "ts"},
                {"ч", "ch"},
                {"ш", "sh"},
                {"щ", "shch"},
                {"ъ", ""},
                {"ы", "y"},
                {"ь", ""},
                {"э", "e"},
                {"ю", "yu"},
                {"я", "ya"},           
                               
                {"А", "A"},
                {"Б", "B"},
                {"В", "V"},
                {"Г", "G"},
                {"Д", "D"},
                {"Е", "E"},
                {"Ё", "E"},
                {"Ж", "ZH"},
                {"З", "Z"},
                {"И", "I"},
                {"Й", "Y"},
                {"К", "K"},
                {"Л", "L"},
                {"М", "M"},
                {"Н", "N"},
                {"О", "O"},
                {"П", "P"},
                {"Р", "R"},
                {"С", "S"},
                {"Т", "T"},
                {"У", "U"},
                {"Ф", "F"},
                {"Х", "KH"},
                {"Ц", "TS"},
                {"Ч", "CH"},
                {"Ш", "SH"},
                {"Щ", "SHCH"},
                {"Ъ", ""},
                {"Ы", "Y"},
                {"Ь", ""},
                {"Э", "E"},
                {"Ю", "YU"},
                {"Я", "YA"}
            };
        }
    }

    /// <summary>
    /// Паспортний (КМУ 2010)
    /// </summary>
    public class Kmu2010UaUs : ITransliterationDictionary
    {
        private readonly IDictionary<string, string> _items;

        public IDictionary<string, string> Items { get { return _items; } }

        public Kmu2010UaUs()
        {
            _items = new Dictionary<string, string>
            {
                {"а", "a"},
                {"б", "b"},
                {"в", "v"},
                {"г", "h"},
                {"ґ", "g"},
                {"д", "d"},
                {"е", "e"},
                {"є", "ie"},
                {"ж", "zh"},
                {"з", "z"},
                {"и", "y"},
                {"і", "i"},
                {"ї", "i"},
                {"й", "i"},
                {"к", "k"},
                {"л", "l"},
                {"м", "m"},
                {"н", "n"},
                {"о", "o"},
                {"п", "p"},
                {"р", "r"},
                {"с", "s"},
                {"т", "t"},
                {"у", "u"},
                {"ф", "f"},
                {"х", "kh"},
                {"ц", "ts"},
                {"ч", "ch"},
                {"ш", "sh"},
                {"щ", "shch"},
                {"ь", ""},
                {"ю", "iu"},
                {"я", "ia"},

                {"А", "A"},
                {"Б", "B"},
                {"В", "V"},
                {"Г", "H"},
                {"Ґ", "G"},
                {"Д", "D"},
                {"Е", "E"},
                {"Є", "IE"},
                {"Ж", "ZH"},
                {"З", "Z"},
                {"И", "Y"},
                {"І", "I"},
                {"Ї", "I"},
                {"Й", "I"},
                {"К", "K"},
                {"Л", "L"},
                {"М", "M"},
                {"Н", "N"},
                {"О", "O"},
                {"П", "P"},
                {"Р", "R"},
                {"С", "S"},
                {"Т", "T"},
                {"У", "U"},
                {"Ф", "F"},
                {"Х", "KH"},
                {"Ц", "TS"},
                {"Ч", "CH"},
                {"Ш", "SH"},
                {"Щ", "SHCH"},
                {"Ь", ""},
                {"Ю", "IU"},
                {"Я", "IA"}
            };
        }
    }
}