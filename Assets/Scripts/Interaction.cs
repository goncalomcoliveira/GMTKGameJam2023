using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public Pair coordinates;
    public abstract int Execute();
    public abstract Pair Move();
}
