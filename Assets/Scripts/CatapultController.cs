using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class CatapultController : MonoBehaviour
{
    bool boulderfired = false;
    bool fired = false;
    float FrameTime;
    float Power;
    Transform arm;
    float t = 0.0f;
    Quaternion initialRotation;
    Quaternion targetRotation;
    public GameObject BoulderPhysical;
    public float ballSpeed = 25f;
    public float ballAngle = 45f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FrameTime = Time.deltaTime * 5;
        Power = 0;
        arm = transform.GetChild(3);
        initialRotation = arm.localRotation;
        targetRotation = initialRotation * Quaternion.AngleAxis(86, Vector3.right);
    }

    //function to spawn the boulders
    void SpawnBoulder()
    {
        GameObject boulder = Instantiate(BoulderPhysical, new Vector3(14.3f, 4.6f, -25.0f), Quaternion.identity);

        BoulderProjectile projectile = boulder.GetComponent<BoulderProjectile>();

        projectile.Initialize(ballSpeed, ballAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.up * FrameTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.down * FrameTime);
        }
        /*if (keyboard.leftArrowKey.isPressed)
        {
            transform.GetChild(3).Rotate((Vector3.left * Time.deltaTime) * 100);
        }
        if (keyboard.rightArrowKey.isPressed)
        {
            transform.GetChild(3).Rotate((Vector3.right * Time.deltaTime) * 100);
        }*/

        if (Input.GetKey(KeyCode.Space) && Power < 3 && GameManager.Instance.BoulderCount >=1 && fired == false)
        {
            Power += 1f * Time.deltaTime;
            GameManager.Instance.GMPower = Power;
        }

        if (Power > 0 && !Input.GetKey(KeyCode.Space) && GameManager.Instance.BoulderCount >= 1)
        {
            GameManager.Instance.loaded = false;
            t += Time.deltaTime * Power;
            arm.localRotation = Quaternion.Lerp(initialRotation, targetRotation, t);
            if (arm.rotation.eulerAngles.x >= 85 && !boulderfired)
            {
                fired = true;
                boulderfired = true;
                SpawnBoulder();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && fired == true)
        {                                                
            Power = 0;
            t = 0.0f;

            GameManager.Instance.loaded = true;
            boulderfired = false;
            fired = false;
            GameManager.Instance.BoulderCount = GameManager.Instance.BoulderCount - 1;

            arm.eulerAngles = new Vector3(0, 270, 0f);
        }

    }
}
