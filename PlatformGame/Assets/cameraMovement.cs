using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform cameraPos;
    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraPos.position = new Vector2(playerPos.position.x, cameraPos.position.y);
    }
}
