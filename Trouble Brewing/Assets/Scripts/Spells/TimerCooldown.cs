using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCooldown : MonoBehaviour
{
    Image fillImg;
    float cooldown = 2.5f;
    float timer;
    public bool cooldownStart;
    public bool particleTimer;
    float particleTime = 0.5f;

    ParticleFeedback particleFeedback;
    TargetingController targetingController;
    Spellcasting spells;

    // Use this for initialization
    void Start()
    {
        fillImg = GetComponent<Image>();
        particleFeedback = FindObjectOfType<ParticleFeedback>();
        targetingController = FindObjectOfType<TargetingController>();
        spells = FindObjectOfType<Spellcasting>();

        timer = cooldown;
        cooldownStart = false;
        fillImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownStart)
        {
            fillImg.fillAmount = 1;
            fillImg.enabled = true;
            particleTimer = true;
            CountingDown();
        }

        if (particleTimer)
        {
            particleTime -= Time.deltaTime;

            if (particleTime < 0)
            {
                particleTimer = false;
                particleTime = 0.5f;
            }
        }
    }

    public void CountingDown()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            fillImg.fillAmount = timer / cooldown;
            return;
        }

        cooldownStart = false;
        timer = cooldown;
        fillImg.fillAmount = 0;
    }
}
