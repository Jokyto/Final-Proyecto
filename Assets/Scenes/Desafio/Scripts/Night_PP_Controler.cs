using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Night_PP_Controler : MonoBehaviour
{
    private PostProcessVolume Global_volume;
    private ColorGrading colorEffect;

    private void Awake() 
    {
        Global_volume = GetComponent<PostProcessVolume>();
        Global_volume.profile.TryGetSettings(out colorEffect);
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            Turn_Night();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Turn_Day();
        }
    }
    private void Turn_Night()
    {
        colorEffect.active = true;
    }
    private void Turn_Day()
    {
        colorEffect.active = false;
    }

}
