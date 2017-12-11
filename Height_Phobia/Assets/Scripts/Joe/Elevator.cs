using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    KeyCode[] keycodes = new KeyCode[] { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };
    int[] floor_codes = new int[] { 0, 1, 2, 3, 4, 5, 6 };

    public float move_speed, floor_height;
    public Vector3 ground_position;

    public GameObject travelling_level;

    bool moving;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Handle_User_Input();
	}

    void Handle_User_Input()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < keycodes.Length; i++)
            {
                if (Input.GetKeyDown(keycodes[i]))
                {
                    Move(floor_codes[i]);
                }
            }
        }
    }

    private void Move(int _floor)
    {
        if (moving == false)
        {
            StartCoroutine(Move_Elevator(_floor));
        }
    }

    IEnumerator Move_Elevator(int _floor)
    {
        Vector3 target = this.transform.position;
        target.y = ground_position.y + (floor_height * _floor);

        if (travelling_level != null)
        {
            travelling_level.SetActive(false);
        }

        while (this.transform.position != target)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, move_speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        if (travelling_level != null)
        {
            travelling_level.SetActive(true);
            Vector3 level_position = travelling_level.transform.position;
            level_position.y = target.y;
            travelling_level.transform.position = level_position;
        }
    }
}
