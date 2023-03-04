using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class pedestrianLightChange : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        Bloom bloom = postProcessVolume.profile.GetSetting<UnityEngine.Rendering.PostProcessing.Bloom>();
        var colorParameter = new UnityEngine.Rendering.PostProcessing.ColorParameter();
        if(GetLight()){
            //Change bloom to blue
            colorParameter.value = Color.blue;

            //Change pedestrian symbol panel to blue

        }
        else {
            //Change bloom to red
            colorParameter.value = Color.red;

            //Change pedestrian symbol panel to red
        }
    }

    //Mock.
    //Supposed to get light from Theo's script
    bool GetLight(){
        return false;
    }
}
