using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.Events;

public class TargetingController : MonoBehaviour, iAI
{
    public float attackRange = 1;
    public Alliance alliance;
    public MinionTypes minionType;

    public NavMeshAgent agent;
    MinionManager minionManager;

    public ArcherEnemyAttack archerMinion;
    public ArcherEnemyAttack mageMinion;
    ParticleSystem particleSystem;
    SFXManager sfxMan;

    float distance = float.PositiveInfinity;

    int turnSpeed = 10;

    public UnityAction<float> HealSpellAction;
    public UnityAction<float> FireSpellAction;

    #region Interface variables declaration

    // Gets a location for minion to follow
    public Vector3 Location
    {
        get
        {
            if (this == null) return Vector3.zero;
            return transform.position;
        }
    }

    public bool IsInRange
    {
        get
        {
            if (distance <= attackRange)
            {
                return true;
            }
            return false;
        }
    }

    public Coroutine AttackRoutine { get; set; }

    // Gets a target for the target in interface
    private iAI _target;

    public iAI Target
    {
        get { return _target; }
        set
        {
            _target = value;
        }
    }

    //returns Faction for the Faction in interface
    public Alliance Faction { get { return alliance; } }

    private StatsCollection statsC;

    //returns the stasCollection
    public StatsCollection StatsCol
    {
        get
        {
            return statsC;
        }
    }

    //returns the minonType
    public MinionTypes MinionType
    {
        get
        {
            return minionType;
        }
    }
    #endregion

    #region Spells
    //De Healthspell geeft elke minion van de speler health erbij.
    public void HealthSpell(float HealAmount)
    {
        if(this.alliance == Alliance.Player)
        {
            this.StatsCol.Health += HealAmount;
            sfxMan.healSpell.Play();
        }
    }

    //De firespell doet damage aan alle enemy minions.
    public void FireSpell(float DamageAmount)
    {
        if(this.alliance == Alliance.Enemy)
        {
            this.StatsCol.Health -= DamageAmount;
            sfxMan.fireSpell.Play();
        }
    }

    #endregion

    // Use this for initialization
    void Start()
    {
        minionManager = FindObjectOfType<MinionManager>();
        sfxMan = FindObjectOfType<SFXManager>();
        agent = GetComponent<NavMeshAgent>();
        statsC = GetComponent<StatsCollection>();
        archerMinion = GetComponent<ArcherEnemyAttack>();
        mageMinion = GetComponent<ArcherEnemyAttack>();
        particleSystem = GetComponent<ParticleSystem>();

        //if it is a friendly minion it changes the stats of the minion to the stats stat are stored in statsCollection
        if (Faction == Alliance.Player)
        {
            statsC.AddToStats(GameManager.Instance.StatsCollection[(byte)minionType]);
        }
        else
        {
            statsC.AddToStats(GameManager.Instance.Enemys[GameManager.Instance.Level].GetTypeStats(minionType)/*,minionClass*/);
        }

        agent.speed = statsC.MovementSpeed;

        HealSpellAction = new UnityAction<float>(HealthSpell);
        FireSpellAction = new UnityAction<float>(FireSpell);

        Spellcasting.HealingSpell.AddListener(HealSpellAction);
        Spellcasting.FireSpell.AddListener(FireSpellAction);
    }

    public void EmitHealParticles()
    {
        if(this.alliance == Alliance.Player)
        {
            particleSystem.Emit(2);
        }
    }

    public void EmitFireParticles()
    {
        if (this.alliance == Alliance.Enemy)
        {
            particleSystem.Emit(2);
        }
    }

    void Update()
    {
        Setdestination();

        if (this.statsC.Health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (agent.isStopped == true)
        {
            Quaternion direction = Quaternion.LookRotation(Target.Location - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation,direction,Time.deltaTime * turnSpeed);
        }

        if (Input.GetKeyDown(KeyCode.O))
            EmitFireParticles();
        else if (Input.GetKeyDown(KeyCode.I))
            EmitHealParticles();
    }

    /// <summary> Initially gets a target for the minions. </summary>
    public void Setdestination()
    {
        if (_target == null) return;

        //Onderstaande if statement word geregeld door de assigntarget.         
        if (minionManager.friendlyMinions.Count > 0 && minionManager.enemyMinions.Count > 0)
        {
            // Check for distance to change behavior
            distance = Vector3.Distance(_target.Location, transform.position);

            agent.SetDestination(_target.Location);
        }
    }

}
