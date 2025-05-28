using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Restaurante
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AMoralesRestauranteEntities context = new DL.AMoralesRestauranteEntities())
                {
                    var query = context.RestauranteGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var objBD in query)
                        {
                            ML.Restaurante restaurante = new ML.Restaurante();

                            restaurante.IdRestaurante = objBD.IdRestaurante;
                            restaurante.Nombre = objBD.Nombre;
                            restaurante.Capacidad = objBD.Capacidad;
                            restaurante.Eslogan = objBD.Eslogan;
                            restaurante.FechaInaguracion = objBD.FechaInaguracion;

                            result.Objects.Add(restaurante);
                            result.Correct = true;
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros en la base de datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetById(int idRestaurante)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AMoralesRestauranteEntities context = new DL.AMoralesRestauranteEntities())
                {
                    var query = context.RestauranteGetById(idRestaurante).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Restaurante restaurante = new ML.Restaurante();
                        restaurante.Nombre = query.Nombre;
                        restaurante.Capacidad = query.Capacidad;
                        restaurante.Eslogan = query.Eslogan;
                        restaurante.FechaInaguracion = query.FechaInaguracion;

                        result.Object= restaurante;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existe ese restaurante";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Add(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AMoralesRestauranteEntities context = new DL.AMoralesRestauranteEntities())
                {
                    var rowsAffect = context.RestauranteAdd(restaurante.Nombre, restaurante.Capacidad, restaurante.Eslogan, DateTime.Parse(restaurante.FechaInaguracion.ToString()));

                    if (rowsAffect >0)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        public static ML.Result Update(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AMoralesRestauranteEntities context = new DL.AMoralesRestauranteEntities())
                {
                    var rowsAffect = context.RestauranteUpdate(restaurante.IdRestaurante, restaurante.Nombre, restaurante.Capacidad, restaurante.Eslogan, DateTime.Parse(restaurante.FechaInaguracion.ToString()));

                    if (rowsAffect > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Delete(int idRestaurante)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AMoralesRestauranteEntities context = new DL.AMoralesRestauranteEntities())
                {
                    var rowsAffect = context.RestauranteDelete(idRestaurante);

                    if (rowsAffect > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


    }
}
