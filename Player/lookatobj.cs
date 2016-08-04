using UnityEngine;
using System.Collections;

public class lookatobj : MonoBehaviour {
    public Transform g;
    public LockMonter LM;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(g.position.x, g.position.y + 1.5f, g.position.z);
        transform.LookAt(g.position);

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            float D =10000;
            if (LM.monters.Length !=0) {
                foreach (GameObject gg in LM.monters)
                {
                    float dd = Vector3.Distance(gg.transform.position, transform.position);
                    if (dd < D)
                    {
                        D = dd;
                        g = gg.transform;
                    }
                }
            }
            else
            {

            }
            
        }
	}
}
