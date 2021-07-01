using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace api.Data.Collections
{
    public class Infectados
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Infectados(DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}