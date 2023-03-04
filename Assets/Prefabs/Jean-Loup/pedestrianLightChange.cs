using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class pedestrianLightChange : MonoBehaviour
{
    public Material pedSymbolRedMat;
    public Material pedSymbolBlueMat;

    private GameObject NPC;
    private TrafficLightsHandler TFH;

    private bool isGreen = false; //True if pedestrian can cross. False otherwise.

    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.Find("PNJ");
        TFH = NPC.GetComponent<TrafficLightsHandler>();

        //We initiate at red light
        Material mymat = GetComponent<Renderer>().sharedMaterial;
        Color c = mymat.GetColor("_EmissionColor");


        //Change pedestrian symbol panel colour
        //if it used to be red (and was just changed to blue)
        if (c[0] < c[2])
        {
            //Change bloom colour to red
            mymat.SetColor("_EmissionColor", new Color(c[2], c[1], c[0], c[3]));
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("PedestrianSymbol"))
            {
                go.GetComponent<MeshRenderer>().material = pedSymbolRedMat;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Material mymat = GetComponent<Renderer>().sharedMaterial;
        Color c = mymat.GetColor("_EmissionColor");
        if (HasLightChanged())
        {
            //Change bloom colour
            mymat.SetColor("_EmissionColor", new Color(c[2], c[1], c[0], c[3]));

            //Change pedestrian symbol panel colour
            //if it used to be red (and was just changed to blue)
            if (c[0] > c[2])
            {
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("PedestrianSymbol"))
                {
                    go.GetComponent<MeshRenderer>().material = pedSymbolBlueMat;
                }
            }
            else //if the new colour is red
            {
                foreach (GameObject go in GameObject.FindGameObjectsWithTag("PedestrianSymbol"))
                {
                    go.GetComponent<MeshRenderer>().material = pedSymbolRedMat;
                }
            }
        }
    }

    /// <summary>
    /// Check if pedstrian lights have changed in the game to change them on the road and traffic lights.
    /// </summary>
    /// <returns>Returns true if the light changed. False otherwise.</returns>
    bool HasLightChanged(){

        if (TFH.GetLight() != isGreen)
        {
            isGreen = !isGreen;
            return true;

        }
        return false;
    }
}
