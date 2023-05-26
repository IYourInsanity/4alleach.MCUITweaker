﻿using _4alleach.MCUITweaker.Client.Abstractions.Services;
using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;
using System;
using System.Collections.Generic;

namespace _4alleach.MCUITweaker.Client.Services;

internal sealed class BusinessModelConstructService : IBusinessModelConstructService
{
    private readonly Dictionary<string, Type> types;
    private readonly Dictionary<string, IDefaultBusinessModel> stash;

    private readonly IServiceHub serviceHub;

    public BusinessModelConstructService(IServiceHub serviceHub)
    {
        types = new Dictionary<string, Type>();
        stash = new Dictionary<string, IDefaultBusinessModel>();

        this.serviceHub = serviceHub;
    }

    public void Initialize()
    {
        
    }

    public void Register<TBusinessModel>(string name) where TBusinessModel : class, IDefaultBusinessModel
    {
        types.Add(name, typeof(TBusinessModel));
    }

    public TBusinessModel? GetModel<TBusinessModel>(string name) where TBusinessModel : class, IDefaultBusinessModel
    {
        if (stash.TryGetValue(name, out var model))
        {
            return model as TBusinessModel;
        }

        return default;
    }

    public void GenerateBusinessModelByName(string name)
    {
        if(types.TryGetValue(name, out var type))
        {
            var model = Activator.CreateInstance(type, serviceHub) as IDefaultBusinessModel;

            if(model != null)
            {
                stash.Add(name, model);
            }
        }
    }

    public void DisposeBusinessModelByName(string name)
    {
        if(stash.Remove(name, out var model))
        {
            model.Dispose();
        }
    }

}
