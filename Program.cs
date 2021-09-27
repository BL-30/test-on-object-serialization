using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace TestSerialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            Xml_ex();
            Json_Ex_String();
            Json_Ex_Serialise();
            Console.ReadLine();

        }

        public static void Xml_ex()
        {

            Console.WriteLine("Serialiser (S) ou Désérialiser (D) ?");
            string a = Console.ReadLine();
            if (a == "S")
            {
                BD bd11 = new BD("978-2203001169", "On a marché sur la Lune", 62);
                Console.WriteLine(bd11);  // affichage pour débug

                // Code pour sérialiser l'objet bd11 en XML dans un fichier "bd11.xml"
                XmlSerializer xs = new XmlSerializer(typeof(BD));  // l'outil de sérialisation
                StreamWriter wr = new StreamWriter("bd11.xml");  // accès en écriture à un fichier (texte)
                xs.Serialize(wr, bd11); // action de sérialiser en XML l'objet bd11 
                                        // et d'écrire le résultat dans le fichier manipulé par wr
                wr.Close();
                Console.WriteLine("sérialisation dans fichier bd11.xml terminée");
            }
            else
            {
                BD nouvelleBD = null;

                // Désérialisation...
                XmlSerializer xs = new XmlSerializer(typeof(BD));
                StreamReader rd = new StreamReader("bd11.xml");

                nouvelleBD = xs.Deserialize(rd) as BD;

                rd.Close();

                // Bilan :
                Console.WriteLine(nouvelleBD);
                Console.ReadLine();
            }
        }
         
            static void Json_Ex_Serialise() 
        {
            BD bd1 = new BD("ABNS1234", "Aggripine");
            string output = JsonConvert.SerializeObject(bd1);
            Console.WriteLine(output);
            BD bd2 = JsonConvert.DeserializeObject<BD>(output);

        }

            static void Json_Ex_String() 
        {
            StreamReader reader = new StreamReader("chien.json");
            JsonTextReader jreader = new JsonTextReader(reader);
            while (jreader.Read())
            {

                if (jreader.Value != null)
                {
                    Console.WriteLine(jreader.TokenType.ToString() + " " + jreader.Value);
                }
                else
                {
                    Console.WriteLine(jreader.TokenType.ToString() + " ");
                }
            }
            jreader.Close();
            reader.Close();

        }



    }
}
