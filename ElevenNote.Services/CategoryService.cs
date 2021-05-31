using ElevenNote.Data;
using ElevenNote.Models;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate category)
        {
            var entity = new Category()
            {
                Name = category.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Select(e => new CategoryListItem()
                { 
                    CatId = e.CatId,
                    Name = e.Name
                });
                
                return query.ToArray();
            }
        }

        public CategoryListItem GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CatId == id);

                return new CategoryListItem() {
                    CatId = entity.CatId,
                    Name = entity.Name
                };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CatId == model.CatId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CatId == CategoryId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
