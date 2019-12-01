using System;

namespace _03_Unity_Broker
{
  public class FootballPlayer
  {
    [Publishes("score")]
    public event EventHandler PlayerScored;

    public string Name { get; set; }

    public void Score()
    {
      var ps = PlayerScored;
      if (ps != null)
        ps(this, new EventArgs());
    }
  }
}