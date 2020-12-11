using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;

    // Simply moves the enemy object forward and back on the x axis to add some difficulty
    private void Update()
    {
        Vector3 pos1 = new Vector3(-4, transform.position.y, transform.position.z);
        Vector3 pos2 = new Vector3(4, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}