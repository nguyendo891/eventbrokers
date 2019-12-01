using System;
using Microsoft.Practices.Unity;

namespace _02_Reactive_Extensions_Broker
{
  class FootballPlayer
  {
    public string Name { get; set; }
    [Dependency]
    public EventBroker EventBroker { get; set; }

    public void Score()
    {
      Console.WriteLine("{0} scored!!!", Name);
      EventBroker.Publish(new ScoreEventArgs(this, Name));
    }
  }
}