namespace apiJuanXXIII.Controllers
{
    public class RegionesDTO
    {
        public RegionesDTO(int id_region, string nombre_region)
        {
            Id_region = id_region;
            Nombre_region = nombre_region;
        }

        public int Id_region { get; }
        public string Nombre_region { get; }
    }
}