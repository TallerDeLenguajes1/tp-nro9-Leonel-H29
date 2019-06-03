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
                Directory.CreateDirectory(ruta_carpeta);
            }
            if (!File.Exists(archivo)) {
                File.Create(archivo);
            }

            BinaryWriter Binario = new BinaryWriter(File.OpenWrite(ruta_carpeta));
            Binario.Write(archivo);
            Binario.Close();
        }

        public static string LeerConfiguracion() {
            BinaryReader Binario = new BinaryReader(File.OpenRead(archivo));
            return Binario.ReadString();
        }
    }
}
