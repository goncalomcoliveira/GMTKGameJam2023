using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public abstract class Interaction
{
    public Position position;

    public abstract int Execute();
    public void Move(Position local, Room room, CharacterMovement movement)
    {
        Debug.Log("Movingo to " + position);
        List<Position> path = Pathfinding.Search(local, position, room);
        
        movement.SetPath(path);
    }
}
