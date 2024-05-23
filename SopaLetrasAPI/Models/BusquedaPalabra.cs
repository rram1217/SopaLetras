using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SopaLetrasAPI.Models
{
    public class BusquedaPalabra
    {
        public bool Buscar(Sopa sopa)
        {
            bool contiene = false;
            char[] caracteresInvertidos = sopa.nombre.ToCharArray();
            Array.Reverse(caracteresInvertidos);
            string nombreInvertido = new string(caracteresInvertidos);

            if (sopa == null)
                return contiene;
            else
            {
                if (sopa.info == null || sopa.nombre == null)
                    return contiene;
                else
                {
                    //BUSQUEDA HORIZONTAL
                    foreach (var item in sopa.info)
                    {
                        if (item.Contains(sopa.nombre) || item.Contains(nombreInvertido))
                        {
                            contiene = true;
                            break;
                        }
                    }

                    //BUSQUEDA VERTICAL
                    if (!contiene)
                    {
                        for (int i = 0; i < sopa.info[0].Length; i++)
                        {
                            string col = "";
                            for (int j = 0; j < sopa.info.Length; j++)
                            {
                                col += sopa.info[j][i];
                            }
                            if (col.Contains(sopa.nombre) || col.Contains(nombreInvertido))
                            {
                                contiene = true;
                                break;
                            }
                        }
                    }

                    //BUSQUEDA DIAGONAL \
                    if (!contiene)
                    {
                        for (int i = 0; i < sopa.info[0].Length; i++)
                        {
                            string diagonalR = "";
                            string diagonalL = "";
                            for (int j = 0; j < (sopa.info.Length - i); j++)
                            {
                                diagonalR += sopa.info[j][i + j];
                                diagonalL += sopa.info[i + j][j];
                            }
                            if (diagonalR.Contains(sopa.nombre) || diagonalR.Contains(nombreInvertido) || diagonalL.Contains(sopa.nombre) || diagonalL.Contains(nombreInvertido))
                            {
                                contiene = true;
                                break;
                            }
                        }
                    }

                    //BUSQUEDA DIAGONAL /
                    if (!contiene)
                    {
                        for (int i = 0; i <= sopa.info.Length + sopa.info[0].Length - 2; i++)
                        {
                            string diagonal = "";
                            for (int fila = Math.Min(sopa.info.Length - 1, i); fila >= 0; fila--)
                            {
                                int columna = i - fila;
                                if (columna < sopa.info[0].Length && columna >= 0)
                                {
                                    diagonal += sopa.info[fila][columna];
                                }
                            }
                            if (diagonal.Contains(sopa.nombre) || diagonal.Contains(nombreInvertido))
                            {
                                contiene = true;
                                break;
                            }
                        }
                    }
                    return contiene;
                }
            }
        }
    }
}