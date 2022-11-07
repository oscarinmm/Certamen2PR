using System;

namespace apiJuanXXIII
{
    public record RegionesDTO(int id_region, string nombre_region);
    public record DepartamentoDTO(int cod_depto, string nombre_depto);
    public record SucursalesDTO(int cod_sucursal, string nombre_suc, int region, int depto, string jefe_suc);
    public record EmpleadosDTO (string rut, string nombre, string apellido, string direccion, int telefono, string cargo, string sucursal, string jefe);
    
}
