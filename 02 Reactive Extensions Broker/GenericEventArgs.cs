using System;

namespace _02_Reactive_Extensions_Broker
{
  class GenericEventArgs : EventArgs
  {
    public GenericEventArgs(object sender, string data)
    {
      Sender = sender;
      Data = data;
    }

    public object Sender { get; set; }
    public string Data { get; set; }
  }
}