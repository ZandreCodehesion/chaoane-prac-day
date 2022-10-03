﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using PracticalDay.Model;

namespace PracticalDay.Database;

public interface IAuthors
{
    Task<AuthorsModel> Create(AuthorsModel authorsModel);
    Task<AuthorsModel> Get(Guid guid);
    Task<EntityEntry<AuthorsModel>> Delete(Guid guid);
    
}