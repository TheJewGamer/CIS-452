/*
    * Jacob Cohen
    * MachineGun.cs
    * Assignment #2
    * Controls the machinegun weapon
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGun : MonoBehaviour, IRangedWeapon
{
    //weapon
    public Transform barrel;
    private int reloadTimeTatical = 3;
    private int reloadTimeEmpty = 2;
    private int magSize = 31;
    private float fireRate = .1f;
    private int currentAmmo = 31;
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
        //update hud
        HudUpdate();

        //resume reloading if needed
        if(reloading)
        {
            StartCoroutine(Reloading());
        }
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
        if(Input.GetMouseButton(0) == true)
        {
            //call
            Shoot();
        }
        else
        {
            //feedback
            muzzelFlash.SetActive(false);
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
            muzzelFlash.SetActive(true);
            
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
            muzzelFlash.SetActive(false);

            StartCoroutine(Empty());
        }

    }

    private IEnumerator Reloading()
    {
        //variable
        int waitTime;

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

    private IEnumerator Empty()
    {
        //enable
        emptyText.SetActive(true);

        //wait
        yield return new WaitForSeconds(.5f);

        //turn off
        emptyText.SetActive(false);
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
