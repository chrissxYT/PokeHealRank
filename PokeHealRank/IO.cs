using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PokeHealRank
{
    static class IO
    {
        public static void phr_save(string file, List<HealItem> items)
        {
            string xml = "<p>";
            foreach (HealItem i in items)
                xml += string.Format("<i n=\"{0}\" h=\"{1}\" p=\"{2}\" />", i.name.xml_esc(), i.hp, i.price);
            xml += "</p>";
            File.WriteAllText(file, xml);
        }

        public static List<HealItem> phr_load(string file)
        {
            XmlReader xml = XmlReader.Create(file);
            List<HealItem> his = new List<HealItem>();
            while (xml.Read())
                if (xml.Name == "i")
                    his.Add(new HealItem(xml.GetAttribute("n"), byte.Parse(xml.GetAttribute("h")), ushort.Parse(xml.GetAttribute("p"))));
            return his;
        }

        static string xml_esc(this string s) => s.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;");
    }
}
