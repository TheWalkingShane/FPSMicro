using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float spinSpeed = 100f;
    public int coinValue = 1;  // You can set this in the Unity Inspector.

    private float bounceSpeed = 2f;
    private float bounceHeight = 0.2f;
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.1f;
    private Vector3 originalPosition;
    private Vector3 originalScale;

    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Spin
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        // Bounce
        float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = originalPosition + new Vector3(0, bounce, 0);

        // Scale Pulse
        float pulse = 1 + Mathf.PingPong(Time.time * pulseSpeed, pulseAmount);
        transform.localScale = originalScale * pulse;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Manager.instance.AddCoin(coinValue);
            Destroy(gameObject);
        }
    }
}


