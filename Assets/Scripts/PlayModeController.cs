using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayModeController : MonoBehaviour {

    [SerializeField] private Renderer background;
    [SerializeField] private float range = 20;
    [SerializeField] private Transform rotator;
    [SerializeField] private AnimationCurve damageByRange = AnimationCurve.Linear(0,1,0,1);
    
    private float multiplier = 0;


    void Awake ()
    {
        if (GameController.instance == null)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        if(background != null && GameController.instance != null) background.material.mainTexture = GameController.instance.tex;
    }
    
    void Update()
    {
        transform.eulerAngles = new Vector3(0, SimpleInput.GetAxis("Horizontal") * range, 0);
        
        if (rotator != null) rotator.rotation = Quaternion.Euler(0, SimpleInput.GetAxis("Horizontal") * 300, 0);
        
        if (ShotButton.isPressed || Input.GetKey(KeyCode.Space))
        {
            Handheld.Vibrate();
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                if (hit.transform != null)
                    if (hit.transform.GetComponent<Enemy>() != null)
                        if (hit.transform.GetComponent<Enemy>().isDead != true)
                        {
                            float damage = PlayerPrefs.GetFloat("distance", 100)*2;
                            damage = hit.distance/damage;
                            damage = damageByRange.Evaluate(damage) *100;
                            hit.transform.GetComponent<Enemy>().KillMe(damage);
                        }

        }
    }
}
