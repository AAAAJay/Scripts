using UnityEngine;
using System.Collections;

public class RaptorSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string jumpatt = "";
    [FMODUnity.EventRef]
    public string att1 = "";
    [FMODUnity.EventRef]
    public string att2 = "";
    [FMODUnity.EventRef]
    public string die = "";

    public void jumpattsound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(jumpatt, transform.position);
    }

    public void att1sound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(att1, transform.position);
    }

    public void att2sound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(att2, transform.position);
    }

    public void diesound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(die, transform.position);
    }

}
