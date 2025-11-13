using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private bool active = false;
    private GameObject currentTarget = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            float distance = Vector2.Distance(mousePosition, transform.position);

            if (distance < 0.5f)
            {
                active = true;
            }
        }

        if (!active)
        {
            return;
        }

        if (currentTarget == null && GameManager.Instance.fishList.Count > 0)
        {
            currentTarget = GameManager.Instance.fishList[0];
        }

        if (currentTarget == null)
        {
            return;
        }

        MoveTowardTarget();
    }

    void MoveTowardTarget()
    {
        if (currentTarget == null)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fish"))
        {
            GameObject fish = collision.gameObject;

            if (fish == currentTarget)
            {
                GameManager.Instance.fishList.Remove(fish);
                Destroy(fish);
                currentTarget = null;
            }
        }
    }
}
