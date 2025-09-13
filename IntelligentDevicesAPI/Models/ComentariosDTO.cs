using System;
using System.Collections.Generic;

namespace IntelligentDevicesApi.Data
{
    public class ComentariosDTO
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public int DevicesId { get; set; }

    }
}