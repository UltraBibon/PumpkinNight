using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandDetector : MonoBehaviour
{
    public static bool shootingleft = false;
    public static bool shootingright = false;
    public void SetLeftTrue()
    {
        shootingleft = true;
    }
    public void SetLeftFalse()
    {
        shootingleft = false;
    }

    public void SetRightTrue() 
    { 
        shootingright=true;
    }

    public void SetRightFalse()
    { 
        shootingright=false;
    }
}

