using System;
using System.Collections.Generic;

namespace IntelligentDevicesApi.Data
{
    public class Devices
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Anio { get; set; }
        public int MarcasId { get; set; }
        public string Imagen { get; set; }

        public Marcas Marcas { get; set; }
        public List<Comentarios> Comentarios { get; set; }
    }
}