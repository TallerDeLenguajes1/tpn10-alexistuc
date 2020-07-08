using System;
using System.Collections.Generic;
using System.Text;

namespace ALexisAleTrabajoPractico10
{
    class Propiedades
    {
        int _Id;
        string _TipoPropiedad;
        string _TipoOperacion;
        float _Tamanho;
        int _CantidadBanhos;
        int _CantidadHabitaciones;
        string _Direccion;
        float _Precio;
        bool _Estado;

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string TipoDePropiedad
        {
            get
            {
                return _TipoPropiedad;
            }

            set
            {
                _TipoPropiedad = value;
            }
        }

        public string TipoDeOperacion
        {
            get
            {
                return _TipoOperacion;
            }

            set
            {
                _TipoOperacion = value;
            }
        }

        public float Tamanho
        {
            get
            {
                return _Tamanho;
            }

            set
            {
                _Tamanho = value;
            }
        }

        public int CantidadBanhos
        {
            get
            {
                return _CantidadBanhos;
            }

            set
            {
                _CantidadBanhos = value;
            }
        }

        public int CantidadHabitaciones
        {
            get
            {
                return _CantidadHabitaciones;
            }

            set
            {
                _CantidadHabitaciones = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }

        public float Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }

        public bool Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        public void ShowProperty()
        {
            Console.WriteLine("\n\n* Inmueble (Id " + _Id + ") :");
            Console.WriteLine("    Tipo de propiedad: " + _TipoPropiedad);
            Console.WriteLine("    Tipo de operacion: " + _TipoOperacion);
            Console.WriteLine("    Tamaño: " + _Tamanho + "m2");
            Console.WriteLine("    Cantidad de baños: " + _CantidadBanhos);
            Console.WriteLine("    Cantidad de habitaciones: " + _CantidadHabitaciones);
            Console.WriteLine("    Domicilio: " + _Direccion);
            Console.WriteLine("    Precio: $" + _Precio);
            if (_Estado)
            {
                Console.WriteLine("    Estado: Activo ");
            }
            else
            {
                Console.WriteLine("    Estado: Inactivo ");
            }

            Console.WriteLine("    Valor del Inmueble: $" + ValorDelInmueble());

        }

        double ValorDelInmueble()
        {
            double PrecioFinal = 0;
            if (_TipoOperacion == "Venta")
            {
                PrecioFinal = _Precio + (_Precio * 0.21) + (_Precio * 0.10) + 10000;
            }

            if (_TipoOperacion == "Alquiler")
            {
                PrecioFinal = (_Precio * 0.02) + (_Precio * 0.5);
            }

            return PrecioFinal;
        }

        public string ConcatenarDatos()
        {
            string aux;
            if (_Estado)
            {
                aux = "Activo";
            }
            else
            {
                aux = "Inactivo";
            }
            return _Id + ";" + _TipoPropiedad + ";" + _TipoOperacion + ";" + _Tamanho + ";" + _CantidadBanhos + ";" + _CantidadHabitaciones + ";" + _Direccion + ";" + _Precio + ";" + aux + ";" + ValorDelInmueble();
        }
    }
}
