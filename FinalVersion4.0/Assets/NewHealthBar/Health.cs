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
    void Start() {
        currentHealth = maxHealth;        
    }
    public void TakeDamage(int amount){
        currentHealth -= amount;
        if(currentHealth<=0)
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
        if ((currentHealth < maxHealth) && !isHealing && !isPlayerAttacked)
        {
            isHealing = true;
            StartCoroutine(SlowHeal());
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
