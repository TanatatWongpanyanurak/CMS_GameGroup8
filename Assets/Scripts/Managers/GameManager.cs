using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    // main game valuable
    [SerializeField] private GameObject timeManager;

    [SerializeField] private GameObject[] existresidence;
    [SerializeField] private float maxCitizen;
    
    [SerializeField] private float numberofCurrent;

    [SerializeField]  float citizenCountdown;

    [SerializeField] public float Citizen;


    float timePassed;
    
    void Start()

    {
        timePassed = 0;
        citizenCountdown = 0;
        maxCitizen = 0;
        numberofCurrent = 0;
        Citizen = 0;
        // starting value
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 5f)
        {
            existresidence = GameObject.FindGameObjectsWithTag("Residence");
            maxCitizen = 0;
            foreach (GameObject existresidence in existresidence)
            {
                float citizenNum = existresidence.GetComponent<Build>().getMaxPeople();

                maxCitizen += citizenNum;
            }
            timePassed = 0f;
        }

        citizenCountdown += Time.deltaTime;
        if(citizenCountdown > 5f)
        {
            if(Citizen != maxCitizen)
            {
                Citizen += 5;
            }
            citizenCountdown = 0;
        }
    }

    public float getCitizen()
    {
        return Citizen;
    }
}
