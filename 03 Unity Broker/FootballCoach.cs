using System;

namespace _03_Unity_Broker
{
  public class FootballCoach
  {
    [SubscribesTo("score")]
    public void PlayerScored(object sender, EventArgs args)
    {
      var p = sender as FootballPlayer;
      Console.WriteLine("Well done, {0}!", p.Name);
    }
  }
}