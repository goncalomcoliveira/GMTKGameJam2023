using System;

[Serializable]
public class Pair
{
    public float x;
    public float y;

    public Pair(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(System.Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Pair p = (Pair)obj;
            return (x == p.x) && (y == p.y);
        }
    }
}
