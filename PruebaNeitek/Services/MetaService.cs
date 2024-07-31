using PruebaNeitek.Models;

namespace PruebaNeitek.Services
{
    public class MetaService
    {
        private List<Meta> _metas = new List<Meta>();

        public List<Meta> ObtenerMetas() => _metas;

        public Meta ObtenerMeta(int id) => _metas.FirstOrDefault(m => m.Id == id);

        public void AgregarMeta(Meta meta)
        {
            meta.Id = _metas.Any() ? _metas.Max(m => m.Id) + 1 : 1;
            meta.FechaCreada = DateTime.Now;
            _metas.Add(meta);
        }

        public void EditarMeta(Meta meta)
        {
            var metaExistente = ObtenerMeta(meta.Id);
            if (metaExistente != null)
            {
                metaExistente.Nombre = meta.Nombre;
                metaExistente.Tareas = meta.Tareas;
            }
        }

        public void EliminarMeta(int id)
        {
            var meta = ObtenerMeta(id);
            if (meta != null)
            {
                _metas.Remove(meta);
            }
        }

        public void CompletarTarea(int metaId, int tareaId)
        {
            var meta = ObtenerMeta(metaId);
            if (meta != null)
            {
                var tarea = meta.Tareas.FirstOrDefault(t => t.Id == tareaId);
                if (tarea != null)
                {
                    tarea.Completada = true;
                }
            }
        }
    }
}
