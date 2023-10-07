using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] private float maxPeople;

    public float getMaxPeople()
    {
        return maxPeople;
    }
}
