﻿using _4alleach.MCRecipeEditor.Docker.Database.Controllers.Base;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories;

namespace _4alleach.MCRecipeEditor.Docker.Database.Controllers;

public class ModTypeController : BaseController<ModTypeRepository, ModType>
{
    public ModTypeController(IAssetsContext context)
        : base(context)
    {

    }
}
