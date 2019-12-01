namespace _02_Reactive_Extensions_Broker
{
  class ScoreEventArgs : GenericEventArgs
  {
    public ScoreEventArgs(object sender, string data) : base(sender, data)
    {
    }
  }
}