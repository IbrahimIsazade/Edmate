﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{

    public class CategoryRepository : AsyncRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(DbContext db) : base(db) { }
	}

}
