﻿using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;
using _4alleach.MCRecipeEditor.Client.ViewModels.Controls;

namespace _4alleach.MCRecipeEditor.Client.Views.Controls;

public partial class MenuControl : ExtendedControl
{
    public MenuControl() : base(typeof(MenuControlViewModel), nameof(MenuControl))
    {
        InitializeComponent();
    }
}
