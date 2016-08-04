using UnityEngine;
using System.Collections;

public class BosshandSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string att = "";

    public void attsound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(att, transform.position);
    }
}
