using System;

namespace NgDesk.Implementation
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class NgDistAttribute: Attribute
    {
        public NgDistAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }
}