﻿/*
    * Jacob Cohen
    * Pistol.cs
    * Assignment #2
    * Controls the pistol weapon
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour, IRangedWeapon
{
    //weapon
    public Transform barrel;
    private float reloadTimeTatical = .5f;
    private float reloadTimeEmpty = 1;
    private int magSize = 16;
    private float fireRate = .01f;
    private int currentAmmo = 16;
    private bool reloading = false;
    private float attackWait;
    public GameObject muzzelFlash;

    //hud
    public Text currentText;
    public GameObject emptyText;
    public GameObject reloadingText;
    public Text magSizeText;
    public GameObject weaponImage;
    public Sprite weaponSprite;

    void OnEnable()
    {
        //show pistol hud
        HudUpdate();

        //prevent errors
        emptyText.SetActive(false);

        //resume reloading if needed
        if(reloading)
        {
            StartCoroutine(Reloading());
        }
    }

    void OnDisable()
    {
        muzzelFlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         //reload
        if(Input.GetButton("Reload") == true)
        {
            //call
            Reload();
        }

        //shoot
        if(Input.GetMouseButtonDown(0) == true)
        {
            //call
            Shoot();
        }
    }

    //update hud
    public void HudUpdate()
    {
        currentText.text = currentAmmo.ToString();
        magSizeText.text = magSize.ToString();
        reloadingText.SetActive(false);
        weaponImage.SetActive(true);
        reloadingText.SetActive(false);
        weaponImage.GetComponent<Image>().sprite = weaponSprite;
    }

    //shoot weapon
    public void Shoot() 
    {
        //check for ammo, fireRate, and reloading
        if(!reloading && currentAmmo > 0 && Time.time > attackWait)
        {
            //feedback
            StartCoroutine(Flash());

            //fireRate
            attackWait = Time.time + fireRate;

            //ammo
            currentAmmo--;

            //hud update
            currentText.text = currentAmmo.ToString();

            //raycast
            RaycastHit2D hit = Physics2D.Raycast(barrel.transform.position, Player.direction);

            //check to see what was hit
            if(hit.collider !=null)
            {
                //enemy hit
                if(hit.collider.CompareTag("enemy"))
                {

                    //notify
                    hit.transform.SendMessageUpwards("Shot");
                }
            }
        }
        //out of ammo
        else if(currentAmmo <= 0 && !reloading)
        {
            //feedback
            StartCoroutine(Empty());
        }

    }

    //actual reloading done here
    private IEnumerator Reloading()
    {
        //variable
        float waitTime;

        //prevent shooting/ double reload
        reloading = true;

        //hud update
        reloadingText.SetActive(true);

        //tactical reload
        if(currentAmmo > 0)
        {
            //set wait time
            waitTime = reloadTimeTatical;
        }
        //empty reload
        else
        {
            //set wait time
            waitTime = reloadTimeEmpty;
        }

        //wait
        yield return new WaitForSeconds(waitTime);

        //give ammo
        currentAmmo = magSize;

        //update hud
        currentText.text = currentAmmo.ToString();

        //done reloading
        reloading = false;

        //hud update
        reloadingText.SetActive(false);
    }

    //flash empty text
    private IEnumerator Empty()
    {
        //enable
        emptyText.SetActive(true);

        //wait
        yield return new WaitForSeconds(.5f);

        //turn off
        emptyText.SetActive(false);
    }

    //muzzle flash
    private IEnumerator Flash()
    {
        //enable
        muzzelFlash.SetActive(true);

        //wait
        yield return new WaitForSeconds(.05f);

        //turn off
        muzzelFlash.SetActive(false);
    }

    //reload
    public void Reload()
    {
        //check to make sure you can
        if(currentAmmo < magSize && !reloading)
        {
            StartCoroutine(Reloading());
        }
    }
}
