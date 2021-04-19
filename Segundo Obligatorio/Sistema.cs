using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    public class Sistema
    {
        public List<Categoria> categorias = new List<Categoria>(); //Dependecia
        public List<Aviso> avisos = new List<Aviso>();
        public List<Articulo> articulos = new List<Articulo>();
        public int idAviso = 1;

        public Categoria BuscarCategoria(string CodigoCat)
        {
            Categoria categoria = null;
            foreach (Categoria cat in categorias)
            {
                if (cat.Codigo == CodigoCat)
                {
                    categoria = cat;
                }
            }
            return categoria;
        }

        public bool CategoriaenUso(string CodigoCat)
        {
            bool enUso = false;
            foreach (Aviso a in avisos)
            {
                if (a is Destacado || a is Comun)
                {
                    foreach (Categoria c in categorias)
                    {
                        if (c.Codigo == CodigoCat)
                        {
                            enUso = true;
                        }
                    }
                }
            }
            return enUso;
        }

        public void AgregarCategoria(Categoria pCategoria)
        {

            categorias.Add(pCategoria);
        }

        public Articulo BuscarArticulo(string CodigoArt)
        {
            Articulo articulo = null;
            foreach (Articulo art in articulos)
            {
                if (art.Codigo == CodigoArt)
                {
                    articulo = art;
                }
            }
            return articulo;
        }

        public bool ArticuloenUso(string CodigoArt)
        {
            bool enUso = false;
            foreach (Aviso a in avisos)
            {
                if (a is Destacado)
                {
                    foreach (Articulo art in articulos)
                    {
                        if (art.Codigo == CodigoArt)
                        {
                            enUso = true;
                        }
                    }
                }
            }
            return enUso;
        }

        public void AgregarArticulo(Articulo pArticulo)
        {
            articulos.Add(pArticulo);
        }

        public void AltaAviso(Aviso pAviso)
        {
            avisos.Add(pAviso);
            idAviso++;
        }

        public void EliminarCategoria(Categoria pCategoria)
        {
            categorias.Remove(pCategoria);
        }

        public List<Aviso> AvisosParaUnaFecha(DateTime fecha)
        {
            List<Aviso> aux = new List<Aviso>();

            foreach (Aviso aviso in avisos)
            {
                if (aviso.Publicacion == fecha)
                {
                    aux.Add(aviso);
                }
            }
            return aux;
        }

        public Aviso ConsultarAviso(int id)
        {
            Aviso aviso = null;
            foreach (Aviso avi in avisos)
            {
                if (avi.Numero == id)
                {
                    aviso = avi;
                }
            }
            return aviso;
        }

    }
}
