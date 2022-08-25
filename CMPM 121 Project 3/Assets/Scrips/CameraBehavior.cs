using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    GameObject player;
    public float rotateSpeed;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate() 
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime, Vector3.up) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
}
