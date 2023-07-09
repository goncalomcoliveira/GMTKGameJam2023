using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform sprite;
    public float moveSpeed;
    public Character character;

    public Animator anim;

    [HideInInspector]
    public Position position = new Position(1, 1);
    [HideInInspector]
    public bool local = false;

    private List<Position> queue = new List<Position>();
    private Vector3 targetVector;
    private Position target;
    private bool walking = false;

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

                anim.SetBool("Up", target.x - position.x <= -1);
                anim.SetBool("Down", target.x - position.x >= 1);
                anim.SetBool("Left", target.y - position.y <= -1);
                anim.SetBool("Right", target.y - position.y >= 1);
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
                    anim.SetInteger("Direction", 0);
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
