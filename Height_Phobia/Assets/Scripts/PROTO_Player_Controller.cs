using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROTO_Player_Controller : MonoBehaviour {

    public GameObject head_object;
    public float move_speed, turn_speed;
    Rigidbody player_rigidbody;

	// Use this for initialization
	void Start () {
        player_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Handle_User_Input();
	}

    void Handle_User_Input()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float grav = player_rigidbody.velocity.y;
        Vector3 movement = (this.transform.forward * move_speed * ver) + (this.transform.right * move_speed * hor);
        movement.y = grav;
        player_rigidbody.velocity = movement;

        float m_hor = Input.GetAxis("Mouse X");
        float m_ver = Input.GetAxis("Mouse Y");
        this.transform.Rotate(new Vector3(0, turn_speed * m_hor * Time.deltaTime, 0));
        head_object.transform.Rotate(new Vector3(-turn_speed * m_ver * Time.deltaTime, 0, 0));
    }
    
}
