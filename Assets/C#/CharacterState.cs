using UnityEngine;
using UnityEngine.UI;

public class CharacterState : MonoBehaviour
{
    public static CharacterState state ;
    PlayerMovement playerMovement2;
    public static CharacterState States;
    Animator plAnm;
    EnemyCon Disable;
    Animator EnAnm;
    float maxhealth = 100;
    public float playerHealth { get; private set; }
    public float EnemyHealth { get; private set; }
    public float power = 10;
    int killscore = 200;
    public GameObject Panal;
private void Awake() {
    state = this;
}
    void Start()
    {
        Disable = GetComponent<EnemyCon>();
        plAnm = GetComponentInChildren<Animator>();
        EnAnm = GetComponentInChildren<Animator>();
        EnemyHealth = maxhealth;
        playerHealth = maxhealth;
    }
    public void change_Player_health(float Player)
    {

        playerHealth = Mathf.Clamp(playerHealth + Player, 0, maxhealth);
        if (playerHealth <= 0)
        {
            Die();
        }
    }
    public void change_Ememy_health(float Enemy)
    {

        EnemyHealth = Mathf.Clamp(EnemyHealth + Enemy, 0, maxhealth);
        if (EnemyHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (playerHealth == 0)
        {
            plAnm.SetTrigger("Die");
            Panal.SetActive(true);
            Disable.enabled = false;
        }
        if (EnemyHealth == 0)
        {
            LevelManger.instance.Score += killscore;
            EnAnm.SetTrigger("dead");
            Disable.enabled = false;
        }

    }
}
