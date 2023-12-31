using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    [SerializeField] private bool isConstructing;
    [SerializeField] private bool isDemolishing;

    [SerializeField] private GameObject curBuildingPrefab;
    [SerializeField] private GameObject buildingParent;

    [SerializeField] private Vector3 curCursorPos;

    public GameObject buildingCursor;
    public GameObject demolishCursor;
    public GameObject gridPlane;

    private GameObject ghostBuilding;

    [SerializeField] private GameObject _curStructure; //Currently selected structure
    public GameObject CurStructure { get { return _curStructure; } set { _curStructure = value; } }

    [SerializeField] private GameObject[] structurePrefab;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
            CancelStructureMode();

        curCursorPos = Formula.instance.GetCurTilePosition();

        if (isConstructing) //Mode Construct
        {
            buildingCursor.transform.position = curCursorPos;
            gridPlane.SetActive(true);
            rotateGhost();
        }
        else if (isDemolishing)
        {
            demolishCursor.transform.position = curCursorPos;
            gridPlane.SetActive(true);
        }
       
        else //Mode Play
        {
            gridPlane.SetActive(false);
        }

        CheckLeftClick();
    }

    public void BeginNewBuildingPlacement(GameObject prefab)
    {
        isDemolishing = false;
        isConstructing = true;

        curBuildingPrefab = prefab;

        //Instantiage Ghost Building
        ghostBuilding = Instantiate(curBuildingPrefab, curCursorPos, Quaternion.identity);
        ghostBuilding.GetComponent<FindBuildingSite>().Plane.SetActive(true);

        buildingCursor = ghostBuilding;
        buildingCursor.SetActive(true);


    }
    private void PlaceBuilding()
    {
        if (buildingCursor.GetComponent<FindBuildingSite>().CanBuild == false)
            return;

        GameObject structureObj = Instantiate(curBuildingPrefab,
                                               curCursorPos,
                                               Quaternion.identity,
                                               buildingParent.transform);


        structureObj.transform.rotation = ghostBuilding.transform.rotation ;

        Structure s = structureObj.GetComponent<Structure>();


        //Add building in Office
        //Deduct Money
    }

    private void CheckLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isConstructing)
                PlaceBuilding(); //Real Construction
           else if (isDemolishing)
            {
                Destroy(GameObject.FindWithTag("Residence"));
            }
            
           
        }
    }
    private void CancelStructureMode()
    {
        isConstructing = false;

        if (buildingCursor != null)
            buildingCursor.SetActive(false);

        if (ghostBuilding != null)
            Destroy(ghostBuilding);
    }

    private void rotateGhost()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            ghostBuilding.transform.Rotate(0f, 45f, 0f, Space.Self);
        }
    }

    private void Demolish()
    {
        Structure s = Office.instance.Structures.Find(x => x.transform.position == curCursorPos);

        if (s != null)
        {
            Office.instance.RemoveBuilding(s);
        }
    }
   
     public void ToggleDemolish() //Map with Demolish Btn
    {
        isConstructing = false;
        isDemolishing = !isDemolishing;

        gridPlane.SetActive(isDemolishing);
        demolishCursor.SetActive(isDemolishing);
    } 


}


