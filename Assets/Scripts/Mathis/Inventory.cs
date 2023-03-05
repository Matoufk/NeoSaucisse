using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance = null;

    public static Inventory Instance
    {
        get { return instance; }
    }
    public bool Eau = false;
    public bool Fleur = false;
    public bool Regle = false;
    public bool Colle = false;
    public bool Affiche = false;
}
