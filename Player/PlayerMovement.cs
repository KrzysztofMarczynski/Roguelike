using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Confing")]
    [SerializeField] private float speed;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;

    public bool canMove = true;

    private readonly int movex = Animator.StringToHash("MoveX");
    private readonly int movey = Animator.StringToHash("MoveY");
    private readonly int moveing = Animator.StringToHash("Moveing");
    public readonly int DMGTake = Animator.StringToHash("DMGTake");

    private PlayerActions Actions;
    private Rigidbody2D rb2D;
    public Animator animator;
    private Vector2 moveDireciotn;

    private void Awake()
    {
        Actions = new PlayerActions();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2D.MovePosition(rb2D.position + moveDireciotn * (speed * Time.fixedDeltaTime));
    }

    private void ReadMovement()
    {
        if (canMove == true)
        {
            moveDireciotn = Actions.Movement.Move.ReadValue<Vector2>().normalized;
            if (moveDireciotn == Vector2.zero)
            {
                animator.SetBool(moveing, false);
                return;
            }
            animator.SetBool(moveing, true);
            animator.SetFloat(movex, moveDireciotn.x);
            animator.SetFloat(movey, moveDireciotn.y);
        }
    }

    private void OnEnable()
    {
        Actions.Enable();
    }

    private void OnDisable()
    {
        Actions.Disable();
    }

    public void StopMovement()
    {
        animator.SetBool(moveing, false);
        rb2D.linearVelocity = Vector2.zero;
        moveDireciotn = Vector2.zero;
    }
}
