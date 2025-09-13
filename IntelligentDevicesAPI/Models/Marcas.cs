using System;
using System.Collections.Generic;

namespace IntelligentDevicesApi.Data
{
    public class Marcas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Devices> Devices { get; set; }
    }
}
