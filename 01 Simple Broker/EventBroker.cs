using System;
using Wintellect.PowerCollections;

namespace _01_Simple_Broker
{
  public class EventBroker
  {
    private MultiDictionary<string, Delegate> subscriptions =
      new MultiDictionary<string, Delegate>(true);
    public void Publish<T>(string name, object sender, T args)
    {
      foreach (var h in subscriptions[name])
        h.DynamicInvoke(sender, args);
    }
    public void Subscribe<T>(string name, Delegate handler)
    {
      subscriptions.Add(name, handler);
    }
  }

}