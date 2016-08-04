using UnityEngine;
using System.Collections;

public class SkullSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string att1 = "";
    [FMODUnity.EventRef]
    public string att2_1 = "";
    [FMODUnity.EventRef]
    public string att2_2 = "";

    public void att1sound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(att1, transform.position);
    }

    public void att2_1sound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(att2_1, transform.position);
    }

    public void att2_2sound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(att2_2, transform.position);
    }
}
