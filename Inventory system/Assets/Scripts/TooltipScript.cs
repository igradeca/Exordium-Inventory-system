using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipScript : MonoBehaviour {

    public static TooltipScript instance;

    [SerializeField]
    private Text tooltipText;

    void Awake() {

        if (instance != null) {
            Debug.LogWarning("Tooltip instance already exist!");
            return;
        } else {
            instance = this;
        }

        tooltipText = transform.GetChild(0).GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
