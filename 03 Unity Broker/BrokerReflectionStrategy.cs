using System;
using System.Reflection;
using Microsoft.Practices.ObjectBuilder2;

namespace _03_Unity_Broker
{
  public class BrokerReflectionStrategy : BuilderStrategy
  {
    public override void PreBuildUp(IBuilderContext context)
    {
      Type typeToBuild = context.BuildKey.Type;

      
      if (typeToBuild != null)
      {
        var policy = new EventBrokerPolicy();

        RegisterSinks(policy, typeToBuild);
        RegisterSources(policy, typeToBuild);

        if (!policy.IsEmpty)
          context.Policies.Set<IEventBrokerPolicy>(policy, context.BuildKey);
      }

      base.PreBuildUp(context);
    }

    static void RegisterSinks(EventBrokerPolicy policy,
                              Type type)
    {
      foreach (MethodInfo method in type.GetMethods())
        foreach (SubscribesToAttribute attr in method.GetCustomAttributes(typeof(SubscribesToAttribute), true))
          policy.AddSink(method, attr.Name);
    }

    static void RegisterSources(EventBrokerPolicy policy, Type type)
    {
      foreach (EventInfo @event in type.GetEvents())
        foreach (PublishesAttribute attr in @event.GetCustomAttributes(typeof(PublishesAttribute), true))
          policy.AddSource(@event, attr.Name);
    }
  }
}