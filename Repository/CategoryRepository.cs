using CrudCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCodeFirst.Repository
{
    public class CategoryRepository : Irepository<Category>
    {
        private readonly myAppContext _context;
        public CategoryRepository(myAppContext context)
        {
            _context = context;
        }
        public void Add(Category Entity)
        {
            _context.Add(Entity);
            
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Category cat = GetById(id);
            _context.Remove(cat);
            //throw new NotImplementedException();
        }
     
        public IEnumerable<Category> GetAll()
        {
            //throw new NotImplementedException();
            return (IEnumerable<Category>) _context.Categories.ToList();
        }

        public CrudCodeFirst.Models.Category GetById(int id)
        {
           return _context.Categories.Where(a => a.Id == id).SingleOrDefault();
           //return _context.Categories.Find(id)
           // throw new NotImplementedException();
        }


        public void save()
        {
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Update(Category Entity)
        {
            _context.Categories.Update(Entity);
           // throw new NotImplementedException();
        }
    }
}

