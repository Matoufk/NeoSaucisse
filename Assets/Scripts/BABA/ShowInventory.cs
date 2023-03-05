using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{

    
    public Inventory inventory;
    public GameObject waterSprite;
    public GameObject GlueSprite;
    public GameObject RuleSprite;
    public GameObject AfficheSprite;
    public GameObject FleurSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory.Eau == true)
        {
            waterSprite.GetComponent<RawImage>().enabled = true;
        }
        if (inventory.Colle == true)
        {
            GlueSprite.GetComponent<RawImage>().enabled = true;
        }
        if (inventory.Regle == true)
        {
            RuleSprite.GetComponent<RawImage>().enabled = true;
        }
        if (inventory.Eau == false)
        {
            waterSprite.GetComponent<RawImage>().enabled = false;
        }
        if (inventory.Colle == false)
        {
            GlueSprite.GetComponent<RawImage>().enabled = false;
        }
        if (inventory.Regle == false)
        {
            RuleSprite.GetComponent<RawImage>().enabled = false;
        }
        if (inventory.Affiche == true)
        {
            AfficheSprite.GetComponent<RawImage>().enabled = true;
        }
        if (inventory.Affiche == false)
        {
            AfficheSprite.GetComponent<RawImage>().enabled = false;
        }
        if (inventory.Fleur == true)
        {
            FleurSprite.GetComponent<RawImage>().enabled = true;
        }
        if (inventory.Fleur == false)
        {
            FleurSprite.GetComponent<RawImage>().enabled = false;
        }
    }
}
