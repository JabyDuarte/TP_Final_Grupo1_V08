using Datos;
using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public class TipoIvaLogica
    {
        private TipoIvaConsulta tipoIvaConsulta;

        public TipoIvaLogica()
        {
            tipoIvaConsulta = new TipoIvaConsulta();
        }

        public List<TipoIva> ObtenerTiposIva()
        {
            
            return tipoIvaConsulta.ObtenerTiposIva();
        }

        public void AgregarTipoIva(TipoIva nuevoTipoIva)
        {
            
            tipoIvaConsulta.AgregarTipoIva(nuevoTipoIva);
        }

        public bool EditarTipoIva(TipoIva tipoIva)
        {
            return tipoIvaConsulta.EditarTipoIva(tipoIva);
        }

        public bool EliminarTipoIva(int idTipoIva)
        {
            return tipoIvaConsulta.EliminarTipoIva(idTipoIva);
        }
    }
}
