using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helpers
{
    public static class SoporteParaConfiguracion
    {
        static string archivo = "Config.dat";
        public static void CrearArchivoDeConfiguracion(string ruta_carpeta) {
            if (!Directory.Exists(ruta_carpeta)) {
                //Directory.CreateDirectory(ruta_carpeta);
                try
                {
                    Directory.CreateDirectory(ruta_carpeta);
                }
                catch (Exception ex) {
                    Console.WriteLine("Error: {0}", ex);
                    throw;
                }
            }
            if (!File.Exists(archivo)) {
                //File.Create(archivo);
                try {
                    File.Create(archivo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex);
                    throw;
                }
            }

            try
            {
                BinaryWriter Binario = new BinaryWriter(File.OpenWrite(archivo));
                Binario.Write(ruta_carpeta);
                Binario.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
                throw;
            }
        }

        public static string LeerConfiguracion() {
            BinaryReader Binario = new BinaryReader(File.OpenRead(archivo));
            return Binario.ReadString();
        }
    }
}
