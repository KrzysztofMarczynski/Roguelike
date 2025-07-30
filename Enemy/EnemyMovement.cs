// EnemyMovement.cs
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private readonly int movex = Animator.StringToHash("MoveX");
    private readonly int movey = Animator.StringToHash("MoveY");
    private readonly int moveing = Animator.StringToHash("Moveing");
    public readonly int DMGTake = Animator.StringToHash("DMGTake");
    public readonly int death = Animator.StringToHash("Death");


    [SerializeField] private Animator animator;

    [Header("Damage effect")]
    [SerializeField] private float damageAnimTime;
    [SerializeField] private float deathAnimTime;


    private Vector3 lastPosition;
    private bool wasMoving;
    private CapsuleCollider2D capsuleCollider2D;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        wasMoving = false;
    }

    private void Start()
    {
        lastPosition = transform.position;
        animator.SetBool(moveing, false);
    }

    private void LateUpdate()
    {
        Vector3 deltaPos = transform.position - lastPosition;
        lastPosition = transform.position;

        Vector2 delta2D = new Vector2(deltaPos.x, deltaPos.y);
        bool isMoving = delta2D.sqrMagnitude > 0.00001f;

        if (isMoving != wasMoving)
        {
            animator.SetBool(moveing, isMoving);
            wasMoving = isMoving;
        }

        if (isMoving)
        {
            Vector2 dir = delta2D.normalized;
            animator.SetFloat(movex, dir.x);
            animator.SetFloat(movey, dir.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            StartCoroutine(DamageAnimation());
        }
    }

    private System.Collections.IEnumerator DamageAnimation()
    {
        animator.SetBool(DMGTake, true);
        yield return new WaitForSeconds(damageAnimTime);
        animator.SetBool(DMGTake, false);
    }

    private System.Collections.IEnumerator DeathAnimation()
    {
        animator.SetBool(death, true);
        yield return new WaitForSeconds(deathAnimTime);
        animator.SetBool(death, false);
        Destroy(gameObject);
    }

    public void DeathAnim()
    {
        StartCoroutine(DeathAnimation());
    }
}
