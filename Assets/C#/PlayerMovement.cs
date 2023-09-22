using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider HealthBar;
    public Transform player1111posation;
    
    CharacterState State;
    public GameObject HitBox;
    Animator playerAnimation;
    CharacterController player;
    public float Speed = 5;
    public float Sprint = 2;
    public float grivty = -10;
    bool isrunning;
   
    void Start()
    {
        HealthBar.value=100;
        State = GetComponent<CharacterState>();
        playerAnimation = GetComponentInChildren<Animator>();
        player = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void FixedUpdate()

    {
        HealthBar.value=State.playerHealth;
        //------------------------------------------------------------------------------------ 
        float horizontal = Input.GetAxis("HO");
        float Vertical = Input.GetAxis("VE");
        Vector3 Movedirection = new Vector3(horizontal, 0, Vertical);
        playerAnimation.SetFloat("Speed", Mathf.Clamp(Movedirection.magnitude, 0, 0.5f) + (isrunning && Movedirection.magnitude > 0.1 ? 0.5f : 0));
        float angle = Mathf.Atan2(Movedirection.x, Movedirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnimation.SetTrigger("Attack");
        }
        if (Movedirection.magnitude > 0.1)

        {
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Movedirection = Camera.main.transform.TransformDirection(Movedirection);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed *= Sprint;
            isrunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed /= Sprint;
            isrunning = false;
        }

        Movedirection.y -= grivty;
        player.Move(Movedirection * Time.deltaTime * Speed);
        //------------------------------------------------------------------------------------


    }
    public void Attack()
    {
        HitBox.SetActive(true);

    }
    public void DisAttack()
    {
        HitBox.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("You have hit");
            
            State.change_Player_health(-other.GetComponentInParent<CharacterState>().power);


            playerAnimation.SetTrigger("IsAttack");
        }
        if (other.CompareTag("Health"))
        {
            State.change_Player_health(20);
            Destroy(other.gameObject);
            Instantiate(LevelManger.instance.particles[0], other.transform.position, other.transform.rotation);
        }
        if (other.CompareTag("Item"))
        {
            LevelManger.instance.Levelitems++;
            Instantiate(LevelManger.instance.particles[1], other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);

        }

    }
}

