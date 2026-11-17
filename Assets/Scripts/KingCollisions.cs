using UnityEngine;

public class KingCollision : MonoBehaviour
{
    //Checking collisions
    private void OnCollisionEnter(Collision collision)
    {
        //checking collision is the ground and that game is not over
        if (collision.gameObject.CompareTag("Ground") && !GameManager.Instance.gameOver)
        {
            //Adding score for defeating the king
            Debug.Log("The King has hit the ground! +200 points");
            GameManager.Instance.AddScore(200);

            //Ending Game
            GameManager.Instance.GameOver();
        }
    }
}
