﻿using Estoque.DAO;
using LancheWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancheWeb.DAO
{
    public class IngredienteLancheDAO
    {

        public void Adiciona(IngredienteLanche inglanche)
        {
            using (var context = new LancheContext())
            {
                context.IngredienteLanche.Add(inglanche);
                context.SaveChanges();
            }
        }


        public IngredienteLanche BuscaPorId(int idIngrediente, int idLanche)
        {
            using (var contexto = new LancheContext())
            {
                return contexto.IngredienteLanche
                    .Where(p => p.IdIngrediente == idIngrediente)
                    .Where(p => p.IdLanche == idLanche)
                    .FirstOrDefault();
            }
        }

        public List<IngredienteLanche> BuscaPorLancheId(int idLanche)
        {
            using (var contexto = new LancheContext())
            {
                return contexto.IngredienteLanche
                    .Where(p => p.IdLanche == idLanche).ToList();
            }
        }

        public void Atualiza(IngredienteLanche inglanche)
        {
            using (var contexto = new LancheContext())
            {
                contexto.Entry(inglanche).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Remove(IngredienteLanche ingLanche)
        {
            using (var contexto = new LancheContext())
            {
                contexto.Entry(ingLanche).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

    }
}
