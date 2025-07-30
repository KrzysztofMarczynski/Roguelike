using UnityEngine;

public class DropIteams : MonoBehaviour
{
    public void DropIteam(GameObject iteam)
    {
        Instantiate(iteam, transform.position, transform.rotation);
        Debug.Log("coś nie działa");
    }
}
