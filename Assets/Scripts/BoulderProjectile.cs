
using UnityEngine;

public class BoulderProjectile : MonoBehaviour
{
    public float launchSpeed = 25f;
    public float launchAngle = 45f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize(float speed, float angle)
    {
        launchSpeed = speed;
        launchAngle = angle;

        float radians = angle * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(-Mathf.Cos(radians), Mathf.Sin(radians), 0f);

        rb.linearVelocity = direction * (speed * GameManager.Instance.GMPower);

        Debug.Log($"Ball launched: Speed {speed}, Angle {angle}");
    }
}
