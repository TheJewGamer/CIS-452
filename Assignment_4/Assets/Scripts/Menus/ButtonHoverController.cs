using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverController : MonoBehaviour
{
    //ranger button
    public GameObject RangerButton;
    private GameObject rangerDefaultText;
    private GameObject rangerHoverText;

    //spy button
    public GameObject SpyButton;
    private GameObject spyDefaultText;
    private GameObject spyHoverText;

    //Glasses button
    public GameObject glassesButton;
    private GameObject glassesDefaultText;
    private GameObject glassesHoverText;

    //heavy armor button
    public GameObject heavyButton;
    private GameObject heavyDefaultText;
    private GameObject heavyHoverText;

    //light armor button
    public GameObject lightButton;
    private GameObject lightDefaultText;
    private GameObject lightHoverText;

    //scope button
    public GameObject scopeButton;
    private GameObject scopeDefaultText;
    private GameObject scopeHoverText;

    // Start is called before the first frame update
    void Start()
    {
        //Ranger Button
        rangerDefaultText = RangerButton.transform.Find("Text").gameObject;
        rangerHoverText = RangerButton.transform.Find("Stats").gameObject;

        //spy button
        spyDefaultText = SpyButton.transform.Find("Text").gameObject;
        spyHoverText =  SpyButton.transform.Find("Stats").gameObject;

        //glasses button
        glassesDefaultText = glassesButton.transform.Find("Text").gameObject;
        glassesHoverText =  glassesButton.transform.Find("Stats").gameObject;

        //heavy button
        heavyDefaultText = heavyButton.transform.Find("Text").gameObject;
        heavyHoverText =  heavyButton.transform.Find("Stats").gameObject;

        //light button
        lightDefaultText = lightButton.transform.Find("Text").gameObject;
        lightHoverText =  lightButton.transform.Find("Stats").gameObject;

        //scope button
        scopeDefaultText = scopeButton.transform.Find("Text").gameObject;
        scopeHoverText =  scopeButton.transform.Find("Stats").gameObject;
    }

    public void RangerHoverEnter()
    {
        rangerDefaultText.SetActive(false);
        rangerHoverText.SetActive(true);
    }

    public void RangerHoverExit()
    {
        rangerDefaultText.SetActive(true);
        rangerHoverText.SetActive(false);
    }

    public void SpyHoverEnter()
    {
        spyDefaultText.SetActive(false);
        spyHoverText.SetActive(true);
    }

    public void SpyHoverExit()
    {
        spyDefaultText.SetActive(true);
        spyHoverText.SetActive(false);
    }

    public void GlassesHoverEnter()
    {
        glassesDefaultText.SetActive(false);
        glassesHoverText.SetActive(transform);

    }

    public void GlassesHoverExit()
    {
        glassesDefaultText.SetActive(transform);
        glassesHoverText.SetActive(false);
    } 

    public void HeavyHoverEnter()
    {
        heavyDefaultText.SetActive(false);
        heavyHoverText.SetActive(true);
    }

    public void HeavyHoverExit()
    {
        heavyDefaultText.SetActive(true);
        heavyHoverText.SetActive(false);
    }

    public void LightHoverEnter()
    {
        lightDefaultText.SetActive(false);
        lightHoverText.SetActive(true);
    }

    public void LightHoverExit()
    {
        lightDefaultText.SetActive(true);
        lightHoverText.SetActive(false);
    }

    public void ScopeHoverEnter()
    {
        scopeDefaultText.SetActive(false);
        scopeHoverText.SetActive(true);
    }

    public void ScopeHoverExit()
    {
        scopeDefaultText.SetActive(true);
        scopeHoverText.SetActive(false);
    }

}
