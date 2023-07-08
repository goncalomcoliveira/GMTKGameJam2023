using System;
using Unity.VisualScripting;

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
}
