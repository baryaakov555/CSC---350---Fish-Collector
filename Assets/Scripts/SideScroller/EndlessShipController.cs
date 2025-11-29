using UnityEngine;

public class EndlessShipController : MonoBehaviour
{
    public float verticalSpeed = 5f;

    private float topBound;
    private float bottomBound;

    public ShipFuelData fuel;

    [SerializeField] private float fuelDrainRate = 5f;

    void Start()
    {
        float camHeight = Camera.main.orthographicSize;
        Vector3 camPos = Camera.main.transform.position;

        bottomBound = camPos.y - camHeight;
        topBound = camPos.y + camHeight;

        fuel = new ShipFuelData(100f);
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical");

        if (fuel.IsEmpty)
            v = 0f;

        transform.Translate(Vector2.up * v * verticalSpeed * Time.deltaTime, Space.World);

        fuel.Consume(Time.deltaTime * fuelDrainRate);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Collectible c = other.GetComponent<Collectible>();
        if (c != null)
        {
            c.ApplyEffect(this);
            return;
        }

        if (other.CompareTag("Fish"))
            Destroy(other.gameObject);

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("DEAD");
            Time.timeScale = 0;
        }
    }
}
