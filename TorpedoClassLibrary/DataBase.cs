using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TorpedoClassLibrary
{
    public static class DataBase
    {
        private static XmlTextWriter writer;
        static DataBase()
        {
            writer = new XmlTextWriter("database.xml",Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("score");
            writer.WriteEndElement();
            writer.Close();
        }
        public static void AddPlayer(string name)
        {

        }
        public static void AddScore(string name, int score)
        {

        }
        public static void GetScore(string name, int score)
        {

        }
    }
}
