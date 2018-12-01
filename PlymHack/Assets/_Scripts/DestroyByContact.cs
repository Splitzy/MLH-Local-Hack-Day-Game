using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplode;
    public GameObject playerExplode;
    public int enemyScore;
    private GameController gameController;
    private CameraShake cameraShake;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject cameraShakeObject = GameObject.FindWithTag("CameraShake");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Can't find GameController script");
        }
        
        if(cameraShakeObject != null)
        {
            cameraShake = cameraShakeObject.GetComponent<CameraShake>();
        }
        else
        {
            Debug.Log("Can't find CameraShake script");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if(enemyExplode != null)
        {
            Instantiate(enemyExplode, transform.position, transform.rotation);
            cameraShake.ShakeIt();
        }
        

        if(other.tag == "Player")
        {
            Instantiate(playerExplode, other.transform.position, other.transform.rotation);
            cameraShake.ShakeIt();
            gameController.GameOver();
        }

        gameController.AddScore(enemyScore);
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
