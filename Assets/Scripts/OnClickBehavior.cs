using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickBehavior : MonoBehaviour
{
    Vector3 mousePos;
    private float speed = 25f;
    
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown() 
    {
        //select object
        mousePos = Input.mousePosition - GetMousePos();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.tag == "Clickable")
                {
                    Debug.Log("Selected");

                    //delete shape after holding delete and mouse left click
                    if(Input.GetKey(KeyCode.Delete))
                    {
                        Destroy(gameObject);
                    }
                }
            }

    }

    private void OnMouseDrag() 
    {
        //Drag selected object
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
        
        //Rotate selected object with hold R and left click
        if(Input.GetKey(KeyCode.R))
        {
            float rotateX = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
            float rotateY = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotateX);
            transform.Rotate(Vector3.right, rotateY);
        }
    }
}
