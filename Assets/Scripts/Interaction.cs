using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public Position position;
    public abstract int Execute();
    public abstract Position Move();
}
