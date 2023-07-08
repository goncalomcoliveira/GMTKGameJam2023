using Unity.VisualScripting;

[System.Serializable]
public class Position
{
    public int x;
    public int y;

    public Position(int x, int y)
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
            Position p = (Position)obj;
            return (x == p.x) && (y == p.y);
        }
    }
    public override string ToString()
    {
        return "(" + x + " " + y + ")";
    }
}
