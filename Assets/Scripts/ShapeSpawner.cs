using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    [SerializeField] private bool isPlacingCube;
    [SerializeField] private bool isPlacingSphere;

    void Start()
    {
        isPlacingCube = false;
        isPlacingSphere = false;
    }

    void Update()
    {
        //mouse left click
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //check if cube slected
            if (isPlacingCube && !isPlacingSphere)
            {
                SpawnCube();
            }
            //check if sphere slected
            if (isPlacingSphere && !isPlacingCube)
            {
                SpawnSphere();
            }
        }
    }

    public void SpawnCube()
    {
        //ray cast for placing at mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.tag == "Floor")
            {
                //spawn cube at mouse position with no rotation
                Instantiate(cubePrefab, hit.point, Quaternion.identity);
            }
        }
    }

    public void SpawnSphere()
    {
        //ray cast for placing at mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.tag == "Floor")
            {
                //spawn sphere at mouse position with no rotation
                Instantiate(spherePrefab, hit.point, Quaternion.identity);
            }
        }
    }
   
    public void SelectCubePrefab()
    {
        //button press for placing a cube
        isPlacingCube = !isPlacingCube;
    }

    public void SelectSpherePrefab()
    {
        //button press for placing a sphere
        isPlacingSphere = !isPlacingSphere;
    }
}