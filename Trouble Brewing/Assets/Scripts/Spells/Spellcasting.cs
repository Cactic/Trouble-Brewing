using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spellcasting : MonoBehaviour
{
    public class SpellcasterEvent : UnityEvent<float>
    {
       
    }
    
    SFXManager sfxMan;
    TimerCooldown timer;

    public static SpellcasterEvent HealingSpell = new SpellcasterEvent();
    public static SpellcasterEvent FireSpell = new SpellcasterEvent();

    //Use this for initialization
    void Start()
    {
        sfxMan = FindObjectOfType<SFXManager>();
        timer = FindObjectOfType<TimerCooldown>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !timer.cooldownStart)
        {
            // Dit moet Via de event van de controller worden geregeld
            // LET OP: DENK ERAAN OM DIT OOK WEER WEG TE HALEN
            timer.cooldownStart = true;
            HealingSpell.Invoke(1);
            FireSpell.Invoke(1);
        }
    }
}

