using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotator : MonoBehaviour
{
    void Update()
    {
        if(GameController.isEnded == false)
        {
            float moveHorizontal = Input.GetAxis("Horizontal") * 200f * Time.deltaTime;
            float moveVertical = Input.GetAxis("Vertical") * 200f * Time.deltaTime;

            transform.Rotate(moveVertical, -moveHorizontal, 0, Space.World);
        }    
    }
}
