using Microsoft.Practices.Unity.ObjectBuilder;

namespace _03_Unity_Broker
{
  using Microsoft.Practices.Unity;

  public class BrokerExtension : UnityContainerExtension
  {
    private readonly EventBroker broker = new EventBroker();

    protected override void Initialize()
    {
      Context.Container.RegisterInstance(broker,
        new ExternallyControlledLifetimeManager());
      Context.Strategies.AddNew<BrokerReflectionStrategy>(
        UnityBuildStage.PreCreation);
      Context.Strategies.Add(new BrokerWireupStrategy(broker),
                              UnityBuildStage.Initialization);
    }

    public EventBroker Broker
    {
      get { return broker; }
    }
  }
}