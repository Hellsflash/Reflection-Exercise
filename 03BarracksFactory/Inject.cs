using System;

namespace _03BarracksFactory
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
    }
}