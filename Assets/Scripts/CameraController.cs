using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 CameraOffset = new Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        CameraOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
        {
            transform.position = Player.transform.position + CameraOffset;
        }
    }
}
