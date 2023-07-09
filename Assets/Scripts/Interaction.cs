using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Interaction : MonoBehaviour
{
    public Furniture furniture;
    public Position position;
    public bool random;

    public abstract int Execute();
    public void Move(Position local, Room room, CharacterMovement movement)
    {
        //Debug.Log("Moving");
        if (random)
        {
            do {
                position = new Position(Random.Range(0, room.ROOMSIZE), Random.Range(0, room.ROOMSIZE));
            } while (room.Matrix[position.x, position.y] is not EmptySpace);
        }

        //Debug.Log("Moving to " + position);
        List<Position> path = Pathfinding.Search(local, position, room);
        
        movement.SetPath(path);
    }

    public abstract void Finish();
}
