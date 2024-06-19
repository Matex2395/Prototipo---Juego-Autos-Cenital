using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerLapController : MonoBehaviour
{ 
    public float vuelta = 0;
    public float numVueltas = 2;
    [SerializeField] private Canvas menuWin;

    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    private bool checkpoint3 = false;
    private bool checkpoint4 = false;
    private bool checkpoint5 = false;

    public TextMeshProUGUI Vueltas;
    void Start()
    {
        vuelta = 0;
        numVueltas = 2;
    }

    void Update()
    {
            Vueltas.text = "  " + vuelta;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FinishLine")
        {

            if (checkpoint1 == true && checkpoint2 == true && checkpoint3 == true && checkpoint4 == true && checkpoint5 == true)
            {
                Debug.Log("Vuelta Completada");
                vuelta += 1;
                checkpoint1 = false;
                checkpoint2 = false;
                checkpoint3 = false;
                checkpoint4 = false;
                checkpoint5 = false;
            }
            if (vuelta==numVueltas)
            {
                Debug.Log("Has Ganado");
                menuWin.gameObject.SetActive(true);
                Time.timeScale = 0;
                
            }
        }

        if (other.gameObject.name == "Checkpoint1")
        {
            checkpoint1 = true;
            Debug.Log("1 Completado");
        }

        if (other.gameObject.name == "Checkpoint2")
        {
            checkpoint2 = true;
            Debug.Log("2 Completado");
        }

        if (other.gameObject.name == "Checkpoint3")
        {
            checkpoint3 = true;
            Debug.Log("3 Completado");
        }

        if (other.gameObject.name == "Checkpoint4")
        {
            checkpoint4 = true;
            Debug.Log("4 Completado");
        }

        if (other.gameObject.name == "FinishLine")
        {
            checkpoint5 = true;
            Debug.Log("Finish Line");
        }
    }
}
