using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth,maxHealth;

    public float invincibleLenght = 2f;
    public float invinceCounter;

    

    private void Awake()
    {

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if(invinceCounter > 0)
        {
            invinceCounter -= Time.deltaTime;



            for (int i = 0; i < PlayerController.instance.playerPieces.Length; i++)
            {
                if (Mathf.Floor(invinceCounter * 5) % 2 == 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
                else
                {
                    PlayerController.instance.playerPieces[i].SetActive(false);
                }

                if(invinceCounter <= 0)
                {
                    PlayerController.instance.playerPieces[i].SetActive(true);
                }
            }
        }
    }

    public void Hurt()
    {

        if (invinceCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameManager.instance.Respawn();
            }
            else
            {
                PlayerController.instance.knockBack();
                invinceCounter = invincibleLenght;

                
            }
        }
    }

    public void resetCurrentHealth()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(int amountHeal)
    {
        currentHealth += amountHeal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
