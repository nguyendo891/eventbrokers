using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;

namespace _03_Unity_Broker
{
  public interface IEventBrokerPolicy : IBuilderPolicy
  {
    IEnumerable<KeyValuePair<string, MethodInfo>> Sinks { get; }
    IEnumerable<KeyValuePair<string, EventInfo>> Sources { get; }
  }
}