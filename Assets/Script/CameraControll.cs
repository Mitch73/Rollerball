using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject player;
    // the offset value is private because it's going to be set in the script
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
     // this will set equal the camera position minus the camera player position
        offset = transform.position - player.transform.position;
    } 

    // late update will run after every other update is done
    // Update is called once per frame
    void LateUpdate()
    {
        // the camera gameobject is moved aligned with the player game object before the frame is displayed
        transform.position = player.transform.position + offset;
    }
}
