using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_interaction : MonoBehaviour {

    public Transform look_position;
    public float cast_distance, cast_radius, required_watch_time;
    float watch_time;
    bool has_interacted = false;

    private void Update()
    {
        Interaction_Trigger trigger = Cast_For_Trigger();
        if (trigger != null)
        {
            watch_time += Time.deltaTime;
            UI_Progress_Setter.ui_progress_setter.Update_Image(watch_time, required_watch_time);
            if(watch_time >= required_watch_time && has_interacted == false)
            {
                trigger.Interact();
                has_interacted = true;
            }
        }
        else
        {
            has_interacted = false;
            watch_time = 0;
            UI_Progress_Setter.ui_progress_setter.Stop_Watching();
        }
    }

    Interaction_Trigger Cast_For_Trigger()
    {
        Ray ray = new Ray(look_position.transform.position, look_position.transform.forward);
        RaycastHit hit_out;
        Physics.Raycast(ray, out hit_out, cast_distance);
        if(hit_out.collider != null)
        {
            Interaction_Trigger trigger = hit_out.collider.GetComponent<Interaction_Trigger>();
            return trigger;
        }
        return null;
    }

}
