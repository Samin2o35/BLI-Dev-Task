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
        SpawnSelectedShape();
    }

    public void SpawnSelectedShape()
    {
        //mouse left click
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //check if cube slected
            if (isPlacingCube && !isPlacingSphere)
            {
                //ray cast for placing at mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    //spawn cube at mouse position with no rotation
                    Instantiate(cubePrefab, hit.point, Quaternion.identity);
                }
            }

            //check if sphere slected
            if (isPlacingSphere && !isPlacingCube)
            {
                //ray cast for placing at mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    //spawn sphere at mouse position with no rotation
                    Instantiate(spherePrefab, hit.point, Quaternion.identity);
                }
            }
        }
    }
    
    public void SelectCubePrefab()
    {
        //indicate that we are now placing a cube
        isPlacingCube = true;
    }

    public void SelectSpherePrefab()
    {
        //indicate that we are now placing a sphere
        isPlacingSphere = true;
    }
}