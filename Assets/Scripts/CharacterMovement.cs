using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterMovement : MonoBehaviour
{
    public Transform sprite;
    public float moveSpeed = 7f;
    public Character character;

    public Rigidbody2D rb;
    public Camera cam;
    //public Animator anim;

    public Position position = new Position(1, 1);
    private List<Position> queue = new List<Position>();
    private Vector3 targetVector;
    private Position target;
    private bool walking = false;
    public bool local = false;

    void FixedUpdate()
    {
        if (!walking)
        {
            if (queue.Count > 0)
            {
                target = queue[0];
                targetVector = character.room.GetVector(target);
                queue.RemoveAt(0);
                walking = true;
                local = false;
            }
        }
        else
        {
            if (!transform.position.Equals(targetVector)) 
            {
                transform.position = Vector3.MoveTowards(transform.position, targetVector, moveSpeed);
            }
            else
            {
                transform.position = targetVector;
                position = target;
                walking = false;
                if (queue.Count == 0)
                {
                    local = true;
                }
            }
        }
    }

    public void SetPath(List<Position> queue)
    {
        walking = false;
        this.queue = queue;
    }
}
