﻿using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;

public interface IRegisterControl
{
    void RegisterControl<VExtendedControl>(IExtendedControl? parent = default) where VExtendedControl : IExtendedControl;

    void UnregisterControl<VExtendedControl>() where VExtendedControl : IExtendedControl;

    void ShowControl<VExtendedControl>(params object[]? args) where VExtendedControl : IExtendedControl;

    void HideControl<VExtendedControl>() where VExtendedControl : IExtendedControl;

    void HideLatestControl();
}
