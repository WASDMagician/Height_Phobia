using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class Player_Timeline_Controller : MonoBehaviour {

    private AnimationClip asset;
    public Animation animator;

	public void Set_Asset(AnimationClip _asset)
    {
        print("SET");
        asset = _asset;
        animator.clip = _asset;
        animator.Play();
        
    }
}
