using UnityEngine;
using System.Collections;

public class FmSetpSound : MonoBehaviour
{
    private PlayerMove playermove;

    [FMODUnity.EventRef]
    public string step = "";
    FMOD.Studio.EventInstance EI;
    public FMOD.Studio.ParameterInstance texture;

    public void reset()
    {
        texture.setValue(1f);
    }

    void SoundEvent()
    {
        FMODUnity.RuntimeManager.PlayOneShot(step, transform.position);
    }

    void Start()
    {
        EI = FMODUnity.RuntimeManager.CreateInstance(step);
        EI.getParameter("texture", out texture);
        playermove = GameObject.Find("Albert2").GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (playermove.tagg == "Nor")
        {
            texture.setValue(2f);
        }

        if (playermove.tagg == "Event01")
        {
            texture.setValue(3f);
        }

        if (playermove.tagg == "Event02")
        {
            texture.setValue(4f);
        }

        else
        {
            reset();
        }
    }
}
