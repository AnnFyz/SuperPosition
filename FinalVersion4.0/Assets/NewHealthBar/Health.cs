using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isPlayerAttacked = false;
    public bool isHealing = false;
    public float healingFreq = 1f;
    public  int healingAmount = 1;
    public Animator playerAnim;
    void Start () {
        currentHealth = maxHealth;
        playerAnim = GetComponentInChildren<Animator>();
    }
    public void TakeDamage(int amount){
        currentHealth -= amount;
        isPlayerAttacked = true;
        playerAnim.SetBool("IsAttacking", true);
        if (currentHealth<=0)
        {
            currentHealth=0;
            /////GameOverScreen
        }
    }

   public void HealPlayer(int amount)
    {
        currentHealth += amount;

    }

    public void Update()
    {
        if ((currentHealth < maxHealth) && !isHealing && !isPlayerAttacked && currentHealth < 70)
        {

            isHealing = true;
            StartCoroutine(SlowHeal());
        }
       

        if (!isPlayerAttacked)
        {
            
            playerAnim.SetBool("IsAttacking", false);

        }
    }
    
    IEnumerator SlowHeal()
    {
        while (currentHealth < maxHealth && !isPlayerAttacked)
        {
            yield return new WaitForSeconds(healingFreq);

            currentHealth += healingAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            //SetHealthBar(currentHealth);
        }

        isHealing = false;
    }
}
