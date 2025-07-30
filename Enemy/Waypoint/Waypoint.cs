using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;

    public Vector3[] Points => points;
    public Vector3 EnityPosition { get; set; }

    private bool gameStarted;

    private void Start()
    {
        EnityPosition = transform.position;
        gameStarted = true;
    }

    public Vector3 GetPosition(int pointIndex)
    {
        return EnityPosition + points[pointIndex];
    }

    private void OnDrawGizmos()
    {
        if (gameStarted == false && transform.hasChanged)
        {
            EnityPosition = transform.position;
        }
    }
}
