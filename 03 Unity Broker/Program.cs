using System;
using Microsoft.Practices.Unity;

namespace _03_Unity_Broker
{
  class Program
  {
    static void Main(string[] args)
    {
      var uc = new UnityContainer();
      uc.AddNewExtension<BrokerExtension>();

      var p = uc.Resolve<FootballPlayer>();
      p.Name = "Maradona";
      var c = uc.Resolve<FootballCoach>();

      p.Score();
      p.Score();

      Console.ReadKey();
    }
  }
}
