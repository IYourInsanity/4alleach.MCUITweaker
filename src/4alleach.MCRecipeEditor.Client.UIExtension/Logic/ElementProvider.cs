﻿using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Helpers;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic;

internal sealed class ElementProvider<TElement, TViewModel> : IElementProvider<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    private readonly FrameworkElement host;

    private readonly IElementController<TElement, TViewModel> controller;

    public FrameworkElement Host => host;

    public Type HostType => host.GetType();

    public TViewModel? ViewModel => host?.DataContext as TViewModel;

    public IElementContainer? Container { get; set; }

    internal ElementProvider(TElement host)
    {
        this.host = host.Value;

        controller = new ElementController<TElement, TViewModel>(host);
    }

    public void Initialize()
    {
        controller.Initialize();
    }

    public TFrameworkElement? FindElement<TFrameworkElement>(string name)
        where TFrameworkElement : FrameworkElement
    {
        if (host == null)
        {
            return default;
        }

        return host.FindName(name) as TFrameworkElement;
    }

    public TFrameworkElement? FindElement<TFrameworkElement>(Func<DependencyObject, bool> funcCondition)
        where TFrameworkElement : FrameworkElement
    {
        var root = GetParent<ExtendedWindow>();

        if (root == null)
        {
            return null;
        }

        return UIHelper.TryFindChild(root, funcCondition) as TFrameworkElement;
    }

    public void SetParent<TParentElement>(TParentElement? parent)
        where TParentElement : FrameworkElement
    {
        ViewModel?.SetParent(parent);
    }

    public void SetArguments(params object[]? args)
    {
        ViewModel?.SetArguments(args);
    }

    public TFrameworkElement? GetParent<TFrameworkElement>()
        where TFrameworkElement : FrameworkElement
    {
        if(host is TFrameworkElement realHost)
        {
            return realHost;
        }

        var parent = host.Parent;

        while (parent != null)
        {
            if(parent is TFrameworkElement)
            {
                return parent as TFrameworkElement;
            }

            if(parent is FrameworkElement elementParent)
            {
                parent = elementParent.Parent;
            }
            else
            {
                break;
            }
        }

        return null;
    }

    public TExtendedViewModel? GetViewModel<TExtendedViewModel>()
        where TExtendedViewModel : TViewModel
    {
        if(ViewModel is TExtendedViewModel model)
        {
            return model;
        }

        return default;
    }

    #region Implementation of IExtendedControlController

    public void Show<TExtendedElement>(params object[]? args) 
        where TExtendedElement : TElement
    {
        controller.Show<TExtendedElement>(args);
    }

    public void Hide<TExtendedElement>() 
        where TExtendedElement : TElement
    {
        controller.Hide<TExtendedElement>();
    }

    public void HideLast()
    {
        controller.HideLast();
    }

    public void Register<TExtendedElement>(TElement? parent) 
        where TExtendedElement : TElement
    {
        controller.Register<TExtendedElement>(parent);
    }

    public void Unregister<TExtendedElement>() 
        where TExtendedElement : TElement
    {
        controller.Unregister<TExtendedElement>();
    }

    public void RegisterProviderModule<TProviderModuleInterface, TProviderModuleImplementation>(params object[]? args)
        where TProviderModuleInterface : IProviderModule<TElement, TViewModel>
        where TProviderModuleImplementation : class, IProviderModule<TElement, TViewModel>
    {
        controller.RegisterProviderModule<TProviderModuleInterface, TProviderModuleImplementation>(args);
    }

    public TProviderModule? GetProviderModule<TProviderModule>() 
        where TProviderModule : IProviderModule<TElement, TViewModel>
    {
        return controller.GetProviderModule<TProviderModule>();
    }

    #endregion

}
