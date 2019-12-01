using System;

namespace _01_Simple_Broker
{
  public class FootballCoach
  {
    private readonly EventBroker broker;
    public FootballCoach(EventBroker broker)
    {
      this.broker = broker;
    }
    public void Watch(FootballPlayer player)
    {
      broker.Subscribe<EventArgs>("LeavingField",
                                  new EventHandler(PlayerIsLeavingField));
    }
    public void PlayerIsLeavingField(object sender, EventArgs args)
    {
      Console.WriteLine("Where are you going, {0}?",
                        (sender as FootballPlayer).Name);
    }
  }

}