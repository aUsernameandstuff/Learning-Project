using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawning an Object
//Instantiation of an Object

// Mouse 0 -> Left Click
//Mouse 1 -> Right Click
public class GunController : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject bulletPoint;

    public AudioSource source;
    public AudioClip clip;

    public float WeaponShootingRate = 1f;

    //means when i fired a bullet
    public float ShotTime = 0;

    public int MagazineCount = 5;
    
    public int BulletsInMagazine = 15;
    
    private void Update()
    {
//        Debug.Log($"<color=yellow>Curent Time {Time.time}</color>");
        if (Input.GetMouseButton(0))
        {
            //Time.time = 6.1
            ////Time.time = 6.2
            /// Time.time = 7
            ///
            ///
            /// 
            if (Time.time > ShotTime)
            {
                // 6
                //Time.time = 6
                //duration for next bullet = 0.4 seconds
                // 6 + 0.4 = 6.4 seconds
                if (BulletsInMagazine == 0)
                {
                    Debug.Log("Reload");
                }
                else
                {
                    ShotTime = Time.time + WeaponShootingRate; //7
                    Instantiate(bulletObject, bulletPoint.transform.position, bulletPoint.transform.rotation);
                    BulletsInMagazine--;
                 //   Debug.Log($"<color=red>Shot Time {ShotTime}</color>");
                    source.PlayOneShot(clip);
                }
            }
        }

        else if(Input.GetMouseButtonDown(1))
        {
            if (MagazineCount == 0)
            {
                Debug.Log("No More Bullets");
            }
            else
            {
                BulletsInMagazine = 15;
                MagazineCount--;
            }
        }
    }
}
