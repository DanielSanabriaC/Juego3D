using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 respawnPosition;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        respawnPosition = PlayerController.instance.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine(respawnCorutina());
    }


    public IEnumerator respawnCorutina()
    {
        PlayerController.instance.gameObject.SetActive(false);
        cameraController.instance.theCMBrain.enabled = false;
        Instantiate(deathEffect, PlayerController.instance.transform.position + new Vector3(0f,1f,0f), PlayerController.instance.transform.rotation);

        UIManager.instance.backToFade = true;
        yield return new WaitForSeconds(2f);
        HealthManager.instance.resetCurrentHealth();


        UIManager.instance.backFromFade = true;
        PlayerController.instance.transform.position = respawnPosition;
        cameraController.instance.theCMBrain.enabled = true;
        
        PlayerController.instance.gameObject.SetActive(true);
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
    }

}
