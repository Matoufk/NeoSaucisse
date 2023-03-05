using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{

    
    public Inventory inventory;
    public SpriteRenderer waterSprite;
    public SpriteRenderer GlueSprite;
    public SpriteRenderer RuleSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory.Eau == true)
        {
            waterSprite.enabled = true;
        }
        if (inventory.Colle == true)
        {
            GlueSprite.enabled = true;
        }
        if (inventory.Regle == true)
        {
            RuleSprite.enabled = true;
        }
        if (inventory.Eau == false)
        {
            waterSprite.enabled = false;
        }
        if (inventory.Colle == false)
        {
            GlueSprite.enabled = false;
        }
        if (inventory.Regle == false)
        {
            RuleSprite.enabled = false;
        }
    }
}
