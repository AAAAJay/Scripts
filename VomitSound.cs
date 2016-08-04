using UnityEngine;
using System.Collections;

public class VomitSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string att = "";
    [FMODUnity.EventRef]
    public string jumpatt = "";

    public void attsound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(att);
    }

    public void jumpattsound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(jumpatt);
    }
}
