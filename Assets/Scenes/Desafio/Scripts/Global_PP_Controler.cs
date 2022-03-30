using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class Global_PP_Controler : MonoBehaviour
{
    private PostProcessVolume Global_volume;
    private Vignette colorEffect;
    private ColorGrading Dead_effect;
    private bool IsRuntineDead = false;
    private bool IsRuntineDamage = false;

    private void Awake() 
    {
        Global_volume = GetComponent<PostProcessVolume>();
        Global_volume.profile.TryGetSettings(out colorEffect);
        Global_volume = GetComponent<PostProcessVolume>();
        Global_volume.profile.TryGetSettings(out Dead_effect);
    }
    private void Start() {
        FindObjectOfType<PlayerCollision>().onGetDamage += DamageEffect;
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (!IsRuntineDead)
            {
                Death();
            }
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            Alive();
        }
        if (Input.GetKey(KeyCode.F1))
        {       
                DamageEffect();      
        }
    }
    private void Death()
    {
        if (!IsRuntineDead)
        {
            Dead_effect.active = true;
            IsRuntineDead = true;
        } 
    }

    private void Alive()
    {
        Dead_effect.active = false;
        IsRuntineDead = false;
    }
    IEnumerator Damage()
    {
        colorEffect.active = true;
        yield return new WaitForSeconds(0.7f);
        colorEffect.active = false;       
    }


    public void DamageEffect()
    {
        if (!IsRuntineDamage && !IsRuntineDead)
        {
            StartCoroutine(Damage());
        }
    }
}
