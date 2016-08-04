using UnityEngine;
using System.Collections;

public class Boss1Sound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string laserH = "";
    [FMODUnity.EventRef]
    public string laserV = "";
    [FMODUnity.EventRef]
    public string die = "";

    public void laserHsound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(laserH, transform.position);
    }

    public void laserVsound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(laserV, transform.position);
    }

    public void diesound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(die, transform.position);
    }
}

