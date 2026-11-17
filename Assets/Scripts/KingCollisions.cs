using UnityEngine;

public class KingCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("The King has hit the ground! +200 points");
            GameManager.Instance.AddScore(200);

            GameManager.Instance.GameOver();
        }
    }
}
