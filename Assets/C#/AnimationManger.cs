using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManger : MonoBehaviour
{
    public GameObject winPanal;
    public GameObject Enemy;
    public GameObject Hitbox;
    public PlayerMovement player;
    public void PlayerAttack()
    {
        player.Attack();
    }
    public void PlayerdisAttack()
    {
        player.DisAttack();
    }
    public void PlayerDamage()
    {
        Hitbox.SetActive(true);
    }
    public void PlayerdisDamage()
    {
        Hitbox.SetActive(false);
    }
    public void Enemydeath()
    {
        Destroy(Enemy);
    }
    

    private void Update()
    {
        if (LevelManger.instance.Levelitems == 3)
        {
            winPanal.SetActive(true);
        }
    }
}
