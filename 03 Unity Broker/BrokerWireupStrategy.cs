using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;

namespace _03_Unity_Broker
{
  public class BrokerWireupStrategy : BuilderStrategy
  {
    private readonly EventBroker broker;

    public BrokerWireupStrategy(EventBroker broker)
    {
      this.broker = broker;
    }

    public override void PreBuildUp(IBuilderContext context)
    {
      var policy = context.Policies.Get<IEventBrokerPolicy>(context.BuildKey);
     
      if (policy != null && broker != null)
      {
        foreach (KeyValuePair<string, MethodInfo> kvp in policy.Sinks)
          broker.RegisterSink(context.Existing, kvp.Value, kvp.Key);

        foreach (KeyValuePair<string, EventInfo> kvp in policy.Sources)
          broker.RegisterSource(context.Existing, kvp.Value, kvp.Key);
      }

      base.PreBuildUp(context);
    }
  }
}