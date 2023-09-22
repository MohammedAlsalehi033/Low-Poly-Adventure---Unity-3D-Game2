using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyCon : MonoBehaviour

{
    public Slider Healthbar;
    CharacterState State;
    public Transform playerPositon;

    public int CooldownTime = 2;

    bool CanAttack = true;
    public GameObject HitBox;
    public float Health = 100;
    public float AttackRud = 10;
    NavMeshAgent Agent;
    Animator SkeletoMovement;
    public GameObject Skeleto;
    float Speed;
    // Start is called before the first frame update
    void Start()
    {
        State = GetComponent<CharacterState>();
        Healthbar.maxValue=100;
        SkeletoMovement = GetComponentInChildren<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
          float distanse = Vector3.Distance(transform.position,playerPositon.position);
        if (distanse < AttackRud)
        {
            Agent.SetDestination(playerPositon.position);
            Speed = 0.5f;
            if (distanse <= Agent.stoppingDistance)
            {
                if (CanAttack)
                {
                    StartCoroutine(CoolDown());
                    SkeletoMovement.SetTrigger("Attack");

                }
                Speed = 0f;
            }
        }
        if (distanse > AttackRud)
        {
            Speed = 0;
        }
        SkeletoMovement.SetFloat("SkeletoMovement", Speed);
        

        IEnumerator CoolDown()
        {
            CanAttack = false;
            yield return new WaitForSeconds(CooldownTime);
            CanAttack = true;
        }
  
        Healthbar.value=State.EnemyHealth;
  }
  private  void OnTriggerEnter(Collider other) {
      if (other.CompareTag("Player")){
          SkeletoMovement.SetTrigger("IsAttack");
    State.change_Ememy_health(-other.GetComponentInParent<CharacterState>().power);
       }

  
}
}