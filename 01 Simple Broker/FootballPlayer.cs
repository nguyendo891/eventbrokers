using System;

namespace _01_Simple_Broker
{
  public class FootballPlayer
  {
    private readonly EventBroker broker;
    public string Name { get; set; }
    public FootballPlayer(EventBroker broker)
    {
      this.broker = broker;
    }
    public void Injured()
    {
      broker.Publish("LeavingField", this, new EventArgs());
    }
    public void SentOff()
    { // event args can be different for this one
      broker.Publish("LeavingField", this, new EventArgs());
    }
  }

}