using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _02_Reactive_Extensions_Broker
{
  class EventBroker : IObservable<EventArgs>
  {
    private readonly List<Subscription> subscribers =
      new List<Subscription>();

    public IDisposable Subscribe(IObserver<EventArgs> subscriber)
    {
      Subscription sub = new Subscription(this, subscriber);
      if (!subscribers.ToArray().Any(s => s.Subscriber == subscriber))
      {
        subscribers.Add(sub);
      }
      return sub;
    }

    public void Unsubscribe(IObserver<EventArgs> subscriber)
    {
      subscribers.RemoveAll(s => s.Subscriber == subscriber);
    }

    public void Publish<T>(T args) where T : EventArgs
    {
      foreach (var s in subscribers.ToArray())
        s.Subscriber.OnNext(args);
    }

    private class Subscription : IDisposable
    {
      private readonly EventBroker broker;
      public IObserver<EventArgs> Subscriber { get; private set; }
      public Subscription(EventBroker broker, IObserver<EventArgs> subscriber)
      {
        this.broker = broker;
        this.Subscriber = subscriber;
      }
      public void Dispose()
      {
        broker.Unsubscribe(Subscriber);
      }
    }

  }
}