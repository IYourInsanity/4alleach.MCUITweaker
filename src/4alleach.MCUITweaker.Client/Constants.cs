using System;

namespace _4alleach.MCUITweaker.Client;

internal struct Constants
{
    internal struct Path
    {
        internal static string Root => AppDomain.CurrentDomain.BaseDirectory;
    }

    internal struct File
    {
        internal static string ProjectFilter => "MCUITweaker Project (*.mcu)|*.mcu";
    }
}
