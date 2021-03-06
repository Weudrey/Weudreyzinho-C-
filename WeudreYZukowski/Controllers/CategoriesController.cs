﻿using System;
using System.Net;
using System.Web.Mvc;
using Model.Tables;
using Services.Tables;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using WeudreYZukowski.Models;

namespace WeudreYZukowski.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryService categoryService = new CategoryService();

        #region [ Actions ]

        #region [ Index ]

        // GET: Supplier
        public async Task<ActionResult> Index()
        {
            var apiModel = new CategoryListAPIModel();

            var resp = await FromAPI(null, response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    apiModel = JsonConvert.DeserializeObject<CategoryListAPIModel>(result);
                }
            });
            return View(apiModel.Result);
        }

        #endregion [ Index ]

        #region [ CREATE ]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            var apiModel = new CategoryAPIModel();

            var resp = await PostFromAPI(null, response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    apiModel = JsonConvert.DeserializeObject<CategoryAPIModel>(result);
                }
            }, category);

            return RedirectToAction("Index");
           
        }

        #endregion [ CREATE ]

        #region [ Edit ]

        public async Task<ActionResult> Edit(long? id)
        {
            return await GetCategoryById(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category category)
        {
            var apiModel = new CategoryAPIModel();

            var resp = await PostFromAPI(5, response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    apiModel = JsonConvert.DeserializeObject<CategoryAPIModel>(result);
                }
            }, category);

            return RedirectToAction("Index");
        }

        #endregion

        #region [ Delete ]

        public async Task<ActionResult> Delete(long? id)
        {
            return await GetCategoryById(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            try
            {
                var apiModel = new CategoryAPIModel();

                var resp = await DeleteFromAPI(id, response =>
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        apiModel = JsonConvert.DeserializeObject<CategoryAPIModel>(result);
                    }
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        #endregion

        #region [ Details ]

        public async Task<ActionResult> Details(long? id)
        {
            return await GetCategoryById(id);
        }

        #endregion

        #region [ Save ]
        private ActionResult SaveCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryService.Save(category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }
        #endregion

        #region [ Uteis ]
        // private ActionResult CategoryById(long? id)
        //{
        //   if (id == null)
        //   {
        //       return new HttpStatusCodeResult(
        //                       HttpStatusCode.BadRequest);
        //   }
        //   Category category = categoryService.CategoryById((long)id);
        //   if (category == null)
        //   {
        //       return HttpNotFound();
        //   }
        //   return View(category);
        //}

        private async Task<ActionResult> GetCategoryById(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Category item = null;

            var resp = await FromAPI(id.Value, response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<Category>(result);
                }
            });

            if (!resp.IsSuccessStatusCode)
                return new HttpStatusCodeResult(resp.StatusCode);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        private async Task<HttpResponseMessage> FromAPI(long? id, Action<HttpResponseMessage> action)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = string.Format("{0}://{1}", HttpContext.Request.Url.Scheme, HttpContext.Request.Url.Authority);
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                var url = "API/Categories";
                if (id != null)
                    url = "API/Categories/" + id;

                var request = await client.GetAsync(url);

                if (action != null)
                    action.Invoke(request);

                return request;
            }
        }

        private async Task<HttpResponseMessage> GetFromAPI(long? id, Action<HttpResponseMessage> action)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = string.Format("{0}://{1}", HttpContext.Request.Url.Scheme, HttpContext.Request.Url.Authority);
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                var url = "Api/Categories";
                if (id != null)
                    url = "Api/Categories/" + id;

                var request = await client.GetAsync(url);

                if (action != null)
                    action.Invoke(request);

                return request;
            }
        }

        private async Task<HttpResponseMessage> PostFromAPI(long? id, Action<HttpResponseMessage> action, Category category)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = string.Format("{0}://{1}", HttpContext.Request.Url.Scheme, HttpContext.Request.Url.Authority);
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                var url = "Api/Categories";

                if (id != null)
                    url = "Api/Categories/" + id;

                var request = await client.PostAsJsonAsync(url, category);
                await client.DeleteAsync(url);
                if (action != null)
                    action.Invoke(request);

                return request;
            }
        }

        private async Task<HttpResponseMessage> DeleteFromAPI(long id, Action<HttpResponseMessage> action)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = string.Format("{0}://{1}", HttpContext.Request.Url.Scheme, HttpContext.Request.Url.Authority);
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                var url = "Api/Categories/" + id;
                var request = await client.DeleteAsync(url);

                if (action != null)
                    action.Invoke(request);

                return request;
            }
        }
        #endregion

        #endregion [ Actions ]
    }
}