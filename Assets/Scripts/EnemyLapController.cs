using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyLapController : MonoBehaviour
{ 
    public float vueltaEnemy;
    public float numVueltasEnemy;
    [SerializeField] private Canvas menuGameOver;
    [SerializeField] private AudioSource youLoseAudio;

    private bool checkpoint1E = false;
    private bool checkpoint2E = false;
    private bool checkpoint3E = false;
    private bool checkpoint4E = false;
    private bool checkpoint5E = false;
    void Start()
    {
        vueltaEnemy = 0;
        numVueltasEnemy = 2;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FinishLine")
        {

            if (checkpoint1E == true && checkpoint2E == true && checkpoint3E == true && checkpoint4E == true && checkpoint5E == true)
            {
                vueltaEnemy += 1;
                checkpoint1E = false;
                checkpoint2E = false;
                checkpoint3E = false;
                checkpoint4E = false;
                checkpoint5E = false;
            }
            if (vueltaEnemy>=numVueltasEnemy)
            {
                Debug.Log("Perdiste");
                menuGameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                youLoseAudio.Play();
            }
        }

        if (other.gameObject.name == "Checkpoint1")
        {
            Debug.Log("Enemigo 1");
            checkpoint1E = true;
        }

        if (other.gameObject.name == "Checkpoint2")
        {
            Debug.Log("Enemigo 2");
            checkpoint2E = true;
        }

        if (other.gameObject.name == "Checkpoint3")
        {
            Debug.Log("Enemigo 3");
            checkpoint3E = true;
        }

        if (other.gameObject.name == "Checkpoint4")
        {
            Debug.Log("Enemigo 4");
            checkpoint4E = true;
        }

        if (other.gameObject.name == "FinishLine")
        {
            Debug.Log("Enemigo Terminó Vuelta");
            checkpoint5E = true;
        }
    }
}
