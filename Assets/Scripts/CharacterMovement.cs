using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform sprite;
    public float moveSpeed = 7f;

    public Rigidbody2D rb;
    public Camera cam;
    //public Animator anim;

    private Vector2 moveDirection;

    private List<Position> queue;
    private bool walking = false;

    void Update()
    {
        
    }

    public void SetPath(List<Position> queue)
    {
        walking = false;
        this.queue = queue;
    }
}
