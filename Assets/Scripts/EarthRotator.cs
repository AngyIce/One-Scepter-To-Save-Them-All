using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotator : MonoBehaviour
{
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * 250f * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * 250f * Time.deltaTime;

        transform.Rotate(moveVertical, -moveHorizontal,  0, Space.World);
    }
}
