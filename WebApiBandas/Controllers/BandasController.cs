using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiBandas.Models;

namespace WebApiBandas.Controllers
{
    public class BandasController : ApiController
    {
        Entities db = new Entities();
        
        //ADICIONAR
        public string Post(Band band)
        {
            db.Bands.Add(band);
            db.SaveChanges();
            return "Musica adicionada!";
        }

        //EXIBIR
        public IEnumerable<Band> Get()
        {
            return db.Bands.ToList();
        }

        //PESQUISAR

        public Band Get(int id)
        {
            Band band = db.Bands.Find(id);
            return band;
            
        }

        //ATUALIZAR

        public string Put(int id, Band band)
        {
            var _banda = db.Bands.Find(id);
            _banda.Banda = band.Banda;
            _banda.Musica = band.Musica;

            db.Entry(_banda).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return "Musica atualizada !";
        }

        //DELETAR

    public string Delete (int id)
        {
            Band band = db.Bands.Find(id);
            db.Bands.Remove(band);
            db.SaveChanges();

            return "Musica deletada!";
        }


    }


}
