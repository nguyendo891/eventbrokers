using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace _01_Simple_Broker
{
  class Program
  {
    static void Main(string[] args)
    {
      var uc = new UnityContainer();
      uc.RegisterType<EventBroker>(
        new ContainerControlledLifetimeManager());
      var p = uc.Resolve<FootballPlayer>();
      p.Name = "Arshavin";
      var c = uc.Resolve<FootballCoach>();

      c.Watch(p);

      p.Injured();
      p.SentOff();


      Console.ReadKey();
    }
  }
}
