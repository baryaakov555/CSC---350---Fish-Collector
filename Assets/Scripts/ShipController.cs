using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float moveSpeed = 3f;

    private bool active = false;
    private GameObject currentTarget = null;

    private Fuel fuel;
    private float lowFuelThreshold = 20f;
    private bool refuelMode = false;

    private void Start()
    {
        fuel = new Fuel(50f, 100f);
    }

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

        if (fuel.Amount <= lowFuelThreshold)
        {
            refuelMode = true;
        }
        else if (refuelMode && fuel.Amount > lowFuelThreshold)
        {
            refuelMode = false;
        }

        if (currentTarget == null)
        {
            if (refuelMode)
            {
                currentTarget = GetNearestFuelTank();
            }
            else if (GameManager.Instance.fishList.Count > 0)
            {
                currentTarget = GameManager.Instance.fishList[0];
            }
        }

        if (currentTarget == null)
        {
            return;
        }

        MoveTowardTarget();
    }

    void MoveTowardTarget()
    {
        if (fuel.IsEmpty() || currentTarget == null)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, moveSpeed * Time.deltaTime);
        fuel.Consume(5f *Time.deltaTime);
        Debug.Log("Fuel: " + fuel.Amount);
    }

    GameObject GetNearestFuelTank()
    {
        GameObject nearest = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject tank in GameManager.Instance.fuelTanks)
        {
            if (tank == null) continue;

            float distance = Vector2.Distance(transform.position, tank.transform.position);

            if (distance < nearestDistance)
            {
                nearest = tank;
                nearestDistance = distance;
            }
        }

        return nearest;
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

        if (collision.CompareTag("Fuel"))
        {
            fuel.Add(25f);
            Destroy(collision.gameObject);
            return;
        }
    }
}