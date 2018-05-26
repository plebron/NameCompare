using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificacionPorCaracteres
{
    class Program
    {
        // Variables para primera prueba
        public static string SP1 = "Solicitud de prestamo", 
               SP2= "Solicitud de préstamo", 
               SP3= "Solicitud de Prestamo",
               SP4= "Solicitud de Préstamo";

        // Variables para segunda prueba
        public static string SPV1 = "Solicitud de préstamo vehículo",
               SPV2 = "Solicitud  de  prestamo  vehiculo",
               SPV3 = "Solicitud de  préstamo  vehiculo",
               SPV4 = "Solicitud de  prestamo  vehículo";

        // Variables para segunda prueba
        public static string SP5 = "Solicitud de prestamo",
               SP6 = "Solicitud prestamo";


        static void Main(string[] args)
        {
            Console.WriteLine("Inicio de pruebas a nombres");
            
            // Primera prueba
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Primera prueba");

            Console.WriteLine("Oraciones a comparar: ");
            Console.WriteLine(SP1);
            Console.WriteLine(SP2);
            Console.WriteLine(SP3);
            Console.WriteLine(SP4);
            Console.WriteLine("");

            Console.WriteLine("Resultado: ");
            if (CaseAccentInsentitive(SP1, SP2, SP3, SP4))
            {
                Console.Write("Prueba exitosa");
            } else
            {
                Console.Write("Prueba fallida");
            }

            // Segunda prueba
            Console.WriteLine("\n \n-----------------------------------------");
            Console.WriteLine("Segunda prueba");

            Console.WriteLine("Oraciones a comparar: ");
            Console.WriteLine(SPV1);
            Console.WriteLine(SPV2);
            Console.WriteLine(SPV3);
            Console.WriteLine(SPV4);
            Console.WriteLine("");

            Console.WriteLine("Resultado: ");
            if (CaseAccentSeparatorsInsentitive(SPV1, SPV2, SPV3, SPV4))
            {
                Console.Write("Prueba exitosa");
            }
            else
            {
                Console.Write("Prueba fallida");
            }

            // Tercera prueba
            Console.WriteLine("\n \n-----------------------------------------");
            Console.WriteLine("Tercera prueba");

            Console.WriteLine("Oraciones a comparar: ");
            Console.WriteLine(SP4);
            Console.WriteLine(SP5);
            Console.WriteLine("");

            Console.WriteLine("Resultado: ");
            if (ArticlesInsentitive(SP4, SP5))
            {
                Console.Write("Prueba exitosa");
            }
            else
            {
                Console.Write("Prueba fallida");
            }

            Console.ReadKey();
        }

        private static string RemoveAccent(string AccentedWord)
        {
            byte[] tempBytes;

            tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(AccentedWord);
            string asciiStr = Encoding.UTF8.GetString(tempBytes);

            return asciiStr;
        }

        private static string ClearName(string name)
        {
            // el, un, los, unos, la, una, las, unas, a, de, al, del, lo

            string ClearedName = RemoveAccent(name.ToLower())
                .Replace(" ", string.Empty)
                .Replace("el", string.Empty)
                .Replace("un", string.Empty)
                .Replace("los", string.Empty)
                .Replace("unos", string.Empty)
                .Replace("la", string.Empty)
                .Replace("una", string.Empty)
                .Replace("las", string.Empty)
                .Replace("unas", string.Empty)
                .Replace("a", string.Empty)
                .Replace("de", string.Empty)
                .Replace("al", string.Empty)
                .Replace("del", string.Empty)
                .Replace("lo", string.Empty);

            return ClearedName;
        }

        private static bool CaseAccentInsentitive(string NombreDocumento1, string NombreDocumento2, string NombreDocumento3, string NombreDocumento4)
        {
            bool result = true;            

            if (RemoveAccent(NombreDocumento1.ToLower()) != RemoveAccent(NombreDocumento2.ToLower()))
            {
                Console.WriteLine($"El nombre {NombreDocumento2} no es compatible");
                result = false;
            }
            if (RemoveAccent(NombreDocumento1.ToLower()) != RemoveAccent(NombreDocumento3.ToLower()))
            {
                Console.WriteLine($"El nombre {NombreDocumento3} no es compatible");
                result = false;
            }
            if (RemoveAccent(NombreDocumento1.ToLower()) != RemoveAccent(NombreDocumento4.ToLower()))
            {
                Console.WriteLine($"El nombre {NombreDocumento4} no es compatible");
                result = false;
            }

            return result;
        }

        private static bool CaseAccentSeparatorsInsentitive(string NombreDocumento1, string NombreDocumento2, string NombreDocumento3, string NombreDocumento4)
        {
            bool result = true;

            if (RemoveAccent(NombreDocumento1.ToLower()).Replace(" ", string.Empty) != RemoveAccent(NombreDocumento2.ToLower()).Replace(" ", string.Empty))
            {
                Console.WriteLine($"El nombre {NombreDocumento2} no es compatible");
                result = false;
            }
            if (RemoveAccent(NombreDocumento1.ToLower()).Replace(" ", string.Empty) != RemoveAccent(NombreDocumento3.ToLower()).Replace(" ", string.Empty))
            {
                Console.WriteLine($"El nombre {NombreDocumento3} no es compatible");
                result = false;
            }
            if (RemoveAccent(NombreDocumento1.ToLower()).Replace(" ", string.Empty) != RemoveAccent(NombreDocumento4.ToLower()).Replace(" ", string.Empty))
            {
                Console.WriteLine($"El nombre {NombreDocumento4} no es compatible");
                result = false;
            }

            return result;
        }

        private static bool ArticlesInsentitive(string NombreDocumento1, string NombreDocumento2)
        {
            
            bool result = true;

            if (ClearName(NombreDocumento1) != ClearName(NombreDocumento2))
            {
                Console.WriteLine($"El nombre {NombreDocumento2} no es compatible");
                result = false;
            }

            return result;
        }
    }
}
