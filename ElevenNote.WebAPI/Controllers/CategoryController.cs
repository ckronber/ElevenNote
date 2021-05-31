using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            CategoryService category = CreateCategory();
            var cat = category.GetCategories();
            return Ok(cat);
        }

        public IHttpActionResult Get(int id)
        {
            var categoryService = CreateCategory();
            var cat = categoryService.GetCategoryById(id);
            return Ok(cat);
        }

        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategory();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok(service);
        }

        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategory();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok(service);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategory();

            if (!service.DeleteCategory(id))
                return InternalServerError();

            return Ok($"Category with Id #{id} has been deleted");
        }

        private CategoryService CreateCategory()
        {
            var CategoryService = new CategoryService();
            return CategoryService;
        }
    }
}
