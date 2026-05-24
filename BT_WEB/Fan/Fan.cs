namespace Fan;

using System;

class Fan
{
    public const int SLOW = 1;
    public const int MEDIUM = 2;
    public const int FAST = 3;

    private int speed = SLOW;
    private bool on = false;
    private double radius = 5;
    private string color = "blue";

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public bool On
    {
        get { return on; }
        set { on = value; }
    }

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Fan()
    {
    }

    public override string ToString()
    {
        if (on)
        {
            return "Fan is on\n" +
                   "Speed: " + speed +
                   "\nColor: " + color +
                   "\nRadius: " + radius;
        }
        else
        {
            return "Fan is off\n" +
                   "Color: " + color +
                   "\nRadius: " + radius;
        }
    }
}
