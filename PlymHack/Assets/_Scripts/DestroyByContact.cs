using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplode;
    public GameObject playerExplode;
    public int enemyScore;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); 
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Can't find Game Controller script");
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
        }
        

        if(other.tag == "Player")
        {
            Instantiate(playerExplode, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(enemyScore);
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
