using System;

namespace _03_Unity_Broker
{
  [AttributeUsage(AttributeTargets.Event, AllowMultiple = true, Inherited = true)]
  public class PublishesAttribute : Attribute
  {
    readonly string name;

    public PublishesAttribute(string name)
    {
      this.name = name;
    }

    public string Name
    {
      get { return name; }
    }
  }
}