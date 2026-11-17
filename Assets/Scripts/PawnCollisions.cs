using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PawnCollision : MonoBehaviour
{
    private bool hasScored = false;

    //check for collisions
    private void OnCollisionEnter(Collision collision)
    {
        //check if the collision is the ground and whether or not it has scored previously
        if (collision.gameObject.CompareTag("Ground") && !hasScored)
        {
            //set it to having scored already
            hasScored = true;

            //check if the game is over
            if (!GameManager.Instance.gameOver)
            {
                //add score and display message
                GameManager.Instance.AddScore(100);
                Debug.Log("Pawn knocked down! +100 points");
            }
        }
    }
}
