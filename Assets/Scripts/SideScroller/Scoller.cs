using UnityEngine;

public class Scroller : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.left * ScrollManager.scrollSpeed * Time.deltaTime);

        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}
