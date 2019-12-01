using System;

namespace _03_Unity_Broker
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
  public class SubscribesToAttribute : Attribute
  {
    readonly string name;

    public SubscribesToAttribute(string name)
    {
      this.name = name;
    }

    public string Name
    {
      get { return name; }
    }
  }
}