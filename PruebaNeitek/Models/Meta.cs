namespace PruebaNeitek.Models
{
    public class Meta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreada { get; set; }
        public List<Tarea> Tareas { get; set; } = new List<Tarea>();

        public int CantidadTareasCompletadas => Tareas.Count(t => t.Completada);
        public double PorcientoCumplimiento => Tareas.Any() ? (double)CantidadTareasCompletadas / Tareas.Count * 100 : 0;
    }
}
