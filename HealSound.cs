using UnityEngine;
using System.Collections;

public class HealSound : MonoBehaviour
{
    public float DDD;
    public float DT = 0;
    [FMODUnity.EventRef]
    public string inputSound = "";
    FMOD.Studio.EventInstance EI;
    public FMOD.Studio.ParameterInstance end;

    void Start ()
    {
        Destroy(gameObject, DDD);
        st();
        FMODUnity.RuntimeManager.PlayOneShot(inputSound, transform.position);
    }

    void st()
    {
        EI = FMODUnity.RuntimeManager.CreateInstance(inputSound);
        EI.getParameter("end", out end);
        end.setValue(1f);
    }

	void Update ()
    {

        DT += 1 * Time.deltaTime;

        if (DT >= 4f)
        {
            st();
            end.setValue(1f);
        }
	}
}
