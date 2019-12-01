using System;
using System.Linq;

namespace _02_Reactive_Extensions_Broker
{
  class FootballCoach
  {
    private readonly EventBroker broker;
    public FootballCoach(EventBroker broker)
    {
      //broker.OfType<GenericEventArgs>().Subscribe(args =>
      //  Console.WriteLine("Well done, {0}!", args.Data));

      broker.OfType<GenericEventArgs>().Skip(2).Take(5).Subscribe(args =>
        Console.WriteLine("Well done, {0}!", args.Data));
    }
  }

}