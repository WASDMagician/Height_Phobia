using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Trigger : MonoBehaviour {

    public Interactible interaction;

    public void Interact()
    {
        if(interaction != null)
        {
            interaction.Interact();
        }
    }
}
