using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light _light;
    public NightMove nightMove;
    
   
    private void Update()
    {
        if(nightMove.IsNight)
         _light.intensity = 0f;
    }

   
}
