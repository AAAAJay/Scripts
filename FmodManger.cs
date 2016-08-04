using UnityEngine;
using System.Collections;

public class FmodManger : MonoBehaviour
{

    static public int MonsterNum;
    static public int UINum;

    [FMODUnity.EventRef]
    public string Bgm = "";
    FMOD.Studio.EventInstance BgmNum;
    public FMOD.Studio.ParameterInstance enemy;
    public FMOD.Studio.ParameterInstance menu;
    public FMOD.Studio.ParameterInstance upgrade;
    public FMOD.Studio.ParameterInstance die;
    public FMOD.Studio.ParameterInstance ambient;
    public FMOD.Studio.ParameterInstance generator;

    public void ResetBgm()
    {
        BgmNum = FMODUnity.RuntimeManager.CreateInstance(Bgm);
        BgmNum.getParameter("enemy", out enemy);
        BgmNum.getParameter("menu", out menu);
        BgmNum.getParameter("upgrade", out upgrade);
        BgmNum.getParameter("die", out die);
        BgmNum.getParameter("ambient", out ambient);
        BgmNum.getParameter("generator", out generator);

        enemy.setValue(0f);
        menu.setValue(0f);
        upgrade.setValue(0f);
        die.setValue(0f);
        ambient.setValue(0f);
        generator.setValue(0f);

        BgmNum.start();
    }

    [FMODUnity.EventRef]
    public string Step = "";
    FMOD.Studio.EventInstance StepNum;
    public FMOD.Studio.ParameterInstance texture;

    public void ResetStep()
    {
        StepNum = FMODUnity.RuntimeManager.CreateInstance(Step);
        StepNum.getParameter("texture", out texture);

        texture.setValue(1f);

        StepNum.start();
    }

    void Start()
    {
        ResetBgm();
    }


    void Update()
    {

    }

}
