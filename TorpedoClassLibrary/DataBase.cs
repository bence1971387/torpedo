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
        private static XmlWriter writer;
        static DataBase()
        {
            writer = XmlWriter.Create("scores.xml");
        }
        static void AddPlayer(string name)
        {

        }
        static void AddScore(string name, int score)
        {

        }
        static void GetScore(string name, int score)
        {

        }
    }
}
