using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

 
public class CAMERA : MonoBehaviour
{
    public float rangeofsight;
    public LayerMask layerMask;
    public GameObject cameraPoint;
    public GameObject bulletObject;
    public float WeaponShootingRate = 1f;
    public float ShotTime = 1;


    // Start is called before the first frame update
    public void OnDrawGizmos()
    {
        Debug.DrawRay(cameraPoint.transform.position, transform.forward.normalized * rangeofsight, Color.red);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Physics.Raycast(cameraPoint.transform.position, transform.forward, out RaycastHit raycasthit, rangeofsight,
            layerMask))
        {
            Debug.Log($"Raycast has hit {raycasthit.transform.gameObject}");
            if (Time.time > ShotTime)
            {
                ShotTime = Time.time + WeaponShootingRate; //7
                Instantiate(bulletObject, cameraPoint.transform.position, cameraPoint.transform.rotation);

            }
        }
    }
}
