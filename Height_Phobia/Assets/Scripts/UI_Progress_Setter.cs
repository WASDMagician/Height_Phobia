using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Progress_Setter : MonoBehaviour {
    public static UI_Progress_Setter ui_progress_setter;
    [Range(0f, 1f)]
    public float max, current;
    public Image progress_image;
    bool reversing = false;

    private void Start()
    {
        ui_progress_setter = this;
        progress_image.fillAmount = 0;
    }

    public void Update_Image(float _current, float _max)
    {
        progress_image.fillAmount = _current / _max;
    }

    public void Stop_Watching()
    {
        if (reversing == false)
        {
            StartCoroutine(Reverse());
        }
    }

    IEnumerator Reverse()
    {
        reversing = true;
        while(progress_image.fillAmount > 0)
        {
            progress_image.fillAmount -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        reversing = false;
    }
}
