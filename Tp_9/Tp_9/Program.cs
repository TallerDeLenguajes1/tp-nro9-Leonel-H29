using Helpers;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_9
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta_carpeta = @"c:\Morse-Archivos";
            Prep_Carp(ruta_carpeta);
            string ruta_archi_morse = Conversor_Morse.CrearArchivoMorse();
            Conversor_Morse.LeerArchivoMorse(ruta_archi_morse);
            Conversor_Morse.CrearAudio(ruta_archi_morse);
            Console.ReadKey();
        }


        static void Prep_Carp(string carpeta) {

            try {
                SoporteParaConfiguracion.CrearArchivoDeConfiguracion(carpeta);
                carpeta = SoporteParaConfiguracion.LeerConfiguracion();

                foreach (string ruta_archi in Directory.GetFiles(Directory.GetCurrentDirectory())) {
                    if(Path.GetExtension(ruta_archi)==".mp3" || Path.GetExtension(ruta_archi) == ".txt")
                    {
                        if (!File.Exists(carpeta + @"\" + Path.GetFileName(ruta_archi)))
                        {
                            string rutaArchivoDestino = carpeta + @"\" + Path.GetFileName(ruta_archi);

                            Console.WriteLine("Copiando {0} a {1}", Path.GetFileName(ruta_archi), rutaArchivoDestino);

                            File.Copy(ruta_archi, rutaArchivoDestino);
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error = {0}", ex);
                throw;
            }
        }
    }
}
