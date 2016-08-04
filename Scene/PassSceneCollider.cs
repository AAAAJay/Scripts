using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PassSceneCollider : MonoBehaviour {

    public GameObject NewerUI;
    public GameObject Black;
    public GameObject Player;
    public GameObject Camera;
    public GameObject CameraObj;
    public GameObject MainCamera;
    public GameObject AniObj;
    public GameObject[] Monster;
    public Animator Door;

    bool image_on = false;
    bool Fade = false;
    float darkness = 0;
    float count = 0;

    void Start() {

    }

    void Update() {
        if (image_on == true) {
            darkness += 3f * Time.deltaTime;
            count += 1f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
            NewerUI.SetActive(false);
            Camera.GetComponent<Camerainto>().enabled = true;
            NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 0f;
            Player.GetComponent<PlayerMove>().enabled = false;
            Player.GetComponent<Input_Handler>().enabled = false;
            MainCamera.GetComponent<MouseRotation>().enabled = false;
        }
        if (count >= 0.8f && Fade == false) {
            gameObject.GetComponent<Animator>().SetTrigger("testpass");
            Camera.GetComponent<Camerainto>().here = CameraObj;
            Camera.transform.position = new Vector3(CameraObj.transform.position.x, CameraObj.transform.position.y, CameraObj.transform.position.z);
            darkness -= 5f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
            image_on = false;
        }
        if (Fade == true) {
            darkness += 10f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
        }

        if (count >= 11.5f) {
        }

        /*if (count >= 7.5f && darkness >= 255f) {
            NewerUI.SetActive(true);
            Camera.GetComponent<Camerainto>().here = MainCamera;
            Camera.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
            darkness -= 1f * Time.deltaTime;
            Black.GetComponent<Image>().color = new Vector4(0, 0, 0, Mathf.Clamp(darkness, 0, 1));
            Camera.GetComponent<Camerainto>().enabled = false;
            NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 1f;
            Player.GetComponent<PlayerMove>().enabled = true;
            Player.GetComponent<Input_Handler>().enabled = true;
            MainCamera.GetComponent<MouseRotation>().enabled = true;
            Destroy(AniObj);
            Destroy(gameObject);
        }*/
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {    
            image_on = true;
            Black.SetActive(true);
            AniObj.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    void Out() {
        NewerUI.SetActive(true);      
        NewerUI.GetComponent<NewerUI>().Ani_albert.speed = 1f;
        Player.GetComponent<PlayerMove>().enabled = true;
        Player.GetComponent<Input_Handler>().enabled = true;
        foreach (GameObject A in Monster) {
            A.SetActive(true);
        }
        MainCamera.GetComponent<MouseRotation>().enabled = true;
        Camera.GetComponent<Camerainto>().here = MainCamera;
        Camera.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
        Camera.GetComponent<Camerainto>().enabled = false;
        Door.SetBool("Open", true);
        Black.SetActive(false);
        Destroy(AniObj);
        Destroy(gameObject);
    }

    void FadeOut() {
        Fade = true;
    }
}
