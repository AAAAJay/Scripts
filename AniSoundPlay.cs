using UnityEngine;
using System.Collections;

public class AniSoundPlay : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string inputSound = "";

    public void SoundEvent()
    {
        FMODUnity.RuntimeManager.PlayOneShot(inputSound,transform.position);
    }


}
