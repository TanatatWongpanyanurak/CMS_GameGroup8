using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour
{
    [SerializeField] private int money;
    public int Money { get { return money; } set { money = value; } }

    [SerializeField] private List<Structure> structures = new List<Structure>();
    public List<Structure> Structures { get { return structures; } }


    public static Office instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddBuilding(Structure s)
    {
        structures.Add(s);
    }

    public void RemoveBuilding(Structure s)
    {
        structures.Remove(s);
        Destroy(s.gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
