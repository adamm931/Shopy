﻿using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk.Client
{
    public class CategoriesClient
    {
        private ShopyHttpClient _client;

        public CategoriesClient(ShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            var list = await _client.GetAsync<ListResponse<Category>>("categories/list");
            return list.Result;
        }

        public async Task<IEnumerable<CategoryLookup>> LookupAsync()
        {
            var list = await _client.GetAsync<ListResponse<CategoryLookup>>("categories/lookup");
            return list.Result;
        }

        public async Task<Category> GetAsync(Guid uid)
        {
            var response = await _client.GetAsync<Response<Category>>($"categories/{uid}/get");
            return response.Result;
        }

        public async Task<Category> AddAsync(Category category)
        {
            var response = await _client.PostAsync<Category, Response<Category>>("categories/add", category);
            return response.Result;
        }

        public async Task EditAsync(Category category)
        {
            await _client.PutAsync($"categories/{category.Uid}/edit", category);
        }

        public async Task DeleteAsync(Guid uid)
        {
            await _client.DeleteAsync($"categories/{uid}/delete");
        }
    }
}