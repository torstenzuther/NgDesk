using System;

namespace NgDesk.Implementation;

[AttributeUsage(AttributeTargets.Assembly)]
public class NgDeskAttribute: Attribute
{
    public NgDeskAttribute(string path)
    {
        Path = path;
    }

    public string Path { get; }
}