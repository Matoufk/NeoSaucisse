using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance = null;

    public static Inventory Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    
    public bool Eau = false;
    public bool Fleur = false;
    public bool Regle = false;
    public bool Colle = false;
    public bool Affiche = false;
}
