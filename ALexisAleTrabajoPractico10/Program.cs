using System;
using System.Collections.Generic;
using System.IO;

namespace ALexisAleTrabajoPractico10
{
    public enum TipoDeOperacion { Venta, Alquiler };
    public enum TipoDePropiedad { Departamento, Casa,  Duplex, Penthouse, Terreno };
    public enum Calles { SanJuan, Santiago, Mendoza, AvRoca, AvIndependencia, Suipacha };

    class Program
    {
        static void Main(string[] args)
        {
            //Crear lista de inmuebles
            List<Propiedades> Properties = new List<Propiedades>();

            //Cargar los datos de los inmuebles en la lista
            Console.WriteLine(" Propiedades Cargadas desde csv: ");
            string CsvFile = "propiedades.csv";
            PropertiesFromCsvToList(CsvFile, Properties);

            //Mostar todos las propiedades por pantalla
            ShowProperties(Properties);

            //Guardar la nueva lista en un csv
            string CsvFileToSave = "propiedades guardadas.csv";
            SaveListInCsv(Properties, CsvFileToSave);

            //Listar los discos y solicitar la unidad en la que se hara el backup
            Console.WriteLine("\nA continuacion se enlistaran los discos disponobles para el :");
            string backupDestino = SelectBackUpPath();
            BackUp(Properties, backupDestino);
            Console.ReadKey();

        }

        public static void BackUp(List<Propiedades> Properties, string nkDest)
        {
            string BackUpPath = nkDest + @"\Backup";
            string fileNumber = "";

            if (!Directory.Exists(BackUpPath))
            {
                Directory.CreateDirectory(BackUpPath);
            }
            else
            {
                string[] availableFiles = Directory.GetFiles(BackUpPath);
                fileNumber = Convert.ToString(availableFiles.Length);
            }

            string BackUpFile = BackUpPath + @"\backup" + fileNumber + ".bk";

            FileStream bk = File.Create(BackUpFile);
            using (StreamWriter bkWriter = new StreamWriter(bk))
            {
                string line;
                foreach (Propiedades pp in Properties)
                {
                    line = pp.ConcatenarDatos();
                    bkWriter.WriteLine(line);
                }
                bkWriter.Close();
            }

            Console.WriteLine("\nArchivo de backup creado: " + BackUpFile);
        }


        public static string SelectBackUpPath()
        {
            int i = 1;
            string[] availableDisks = Environment.GetLogicalDrives();
            Console.WriteLine();
            foreach (string drive in availableDisks)
            {
                Console.WriteLine("   " + i + ") " + drive);
                i++;
            }

            Console.Write("\nIngrese el numero correspondiente al disco elegido: ");
            int nro = Convert.ToInt16(Console.ReadLine());
            string selectedDirectory = @availableDisks[nro - 1];
            Console.WriteLine("\nOpcion seleccionada: " + selectedDirectory);

            return selectedDirectory;
        }

        public static void PropertiesFromCsvToList(string CsvFile, List<Propiedades> Properties)
        {
            string[] content = null;
            try
            {
                content = File.ReadAllLines(CsvFile);
            }
            catch (Exception error)
            {
                Console.WriteLine("\nLo sentimos, Ha ocurrido un error!\n");
                Console.WriteLine(error.Message);
            }

            Propiedades new_p;

            foreach (string line in content)
            {
                new_p = NewProperty(line);
                Properties.Add(new_p);
            }
        }

        public static Random rand = new Random();

        public static Propiedades NewProperty(string line)
        {
            string[] lineContent = line.Split(';');


            Propiedades new_p = new Propiedades();

            int _Id = rand.Next(100);
            string _TipoDePropiedad = lineContent[1];
            string _TipoDeOperacion = Enum.GetName(typeof(TipoDeOperacion), rand.Next(2));
            float _Tamanio = rand.Next(1001) + 1;
            int _CantidadBanhos = rand.Next(5) + 1;
            int _CantidadHabitaciones = rand.Next(10) + 1;
            string _Direccion = lineContent[0];
            int _Precio = rand.Next(2000000);
            bool BoolAux;
            if (rand.Next(2) == 1)
            {
                BoolAux = true;
            }
            else
            {
                BoolAux = false;
            }
            bool _Estado = BoolAux;

            new_p.Id = _Id;
            new_p.TipoDePropiedad = _TipoDePropiedad;
            new_p.TipoDeOperacion = _TipoDeOperacion;
            new_p.Tamanho = _Tamanio;
            new_p.CantidadBanhos = _CantidadBanhos;
            new_p.CantidadHabitaciones = _CantidadHabitaciones;
            new_p.Direccion = _Direccion;
            new_p.Precio = _Precio;
            new_p.Estado = _Estado;

            return new_p;

        }

        public static void ShowProperties(List<Propiedades> Properties)
        {
            foreach (Propiedades pro in Properties)
            {
                pro.ShowProperty();
            }
        }

        public static void SaveListInCsv(List<Propiedades> Properties, string CsvFileToSave)
        {
            string line;
            using (StreamWriter file = File.CreateText(CsvFileToSave))
            {
                foreach (Propiedades prop in Properties)
                {
                    line = prop.ConcatenarDatos();
                    file.WriteLine(line);
                }
                file.Close();
            }
        }
    }
}
