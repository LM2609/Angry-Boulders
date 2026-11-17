using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PawnCollision : MonoBehaviour
{
    private bool hasScored = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the pawn has hit the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Make sure this pawn hasn't already scored
            if (!hasScored)
            {
                hasScored = true;

                // Award 10 points
                if (!GameManager.Instance.gameOver)
                {
                    GameManager.Instance.AddScore(100);
                    Debug.Log("Pawn knocked down! +100 points");
                }
            }
        }
    }
}
