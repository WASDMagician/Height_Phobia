using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Movement_Interactible : Interactible {

    public AnimationClip timeline_asset;

    public override void Interact()
    {
        base.Interact();
        Player_Timeline_Controller timeline_controller = FindObjectOfType<Player_Timeline_Controller>();
        print("INTERACT");
        if(timeline_controller != null)
        {
            print("HAVE CONTROLLER");
        }
        if(timeline_asset != null)
        {
            print("HAVE ASSET");
        }
        if(timeline_controller != null && timeline_asset != null)
        {
            print("SET ASSET");
            timeline_controller.Set_Asset(timeline_asset);
        }
    }
}
