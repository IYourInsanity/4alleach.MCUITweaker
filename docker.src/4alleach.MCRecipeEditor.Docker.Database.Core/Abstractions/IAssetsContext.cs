﻿namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;

public interface IAssetsContext : IDisposable
{
    IQueryHandler<TAsset> BuildHandler<TAsset>()
        where TAsset : Asset;
}
