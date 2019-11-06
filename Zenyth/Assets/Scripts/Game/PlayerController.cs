using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private static float MOVEMENT_SPEED
    {
        get
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                return 2.0f;
            else
                return 5.0f;
        }
    }

    private void Update()
    {
        float translationX = Input.GetAxis("Horizontal") * Time.deltaTime * MOVEMENT_SPEED;
        float translationY = Input.GetAxis("Vertical") * Time.deltaTime * MOVEMENT_SPEED;

        transform.Translate(translationX, translationY, 0);
    }
}
