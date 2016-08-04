using UnityEngine;
using System.Collections;

public class E_aniSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputSound1 = "";
    [FMODUnity.EventRef]
    public string inputSound2 = "";

    void Event1()
    {
        FMODUnity.RuntimeManager.PlayOneShot(inputSound1, transform.position);
    }

    void Event2()
    {
        FMODUnity.RuntimeManager.PlayOneShot(inputSound2, transform.position);
    }
}
