using UnityEngine;

public class FireFly : MonoBehaviour
{
    public float minY = -2f;
    public float maxY = 2f;
    public float minX = -2f;
    public float maxX = 2f;

    public float minSpeed = 1f;
    public float maxSpeed = 2f;
    public float directionChangeInterval = 2f;

    private float speed;
    private int directionY = 1;
    private int directionX = 1;
    private float timer;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        SetRandomSpeedAndDirection();
    }

    void Update()
    {
        Vector3 move = new Vector3(directionX, directionY, 0) * speed * Time.deltaTime;
        transform.Translate(move);

        float currentX = transform.position.x;
        float currentY = transform.position.y;

        if (currentY >= startPos.y + maxY && directionY == 1)
            directionY = -1;
        else if (currentY <= startPos.y + minY && directionY == -1)
            directionY = 1;

        if (currentX >= startPos.x + maxX && directionX == 1)
            directionX = -1;
        else if (currentX <= startPos.x + minX && directionX == -1)
            directionX = 1;

        timer += Time.deltaTime;
        if (timer >= directionChangeInterval)
        {
            timer = 0f;
            SetRandomSpeedAndDirection();
        }
    }

    void SetRandomSpeedAndDirection()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        directionY = Random.value > 0.5f ? 1 : -1;
        directionX = Random.value > 0.5f ? 1 : -1;
    }
}
