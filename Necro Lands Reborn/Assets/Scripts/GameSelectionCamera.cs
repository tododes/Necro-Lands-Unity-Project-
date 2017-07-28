using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectionCamera : MonoBehaviour {

    public static GameSelectionCamera singleton;
    [SerializeField] private int index = 0;
    [SerializeField] private int maxIndex;

    void Awake(){
        singleton = this;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < 20f * index)
            transform.Translate(Vector3.right * 30f * Time.deltaTime);

        if (transform.position.x > 20f * index)
            transform.Translate(Vector3.left * 30f * Time.deltaTime);
    }

    public void inc(int i) {
        index += i;
        index = Mathf.Clamp(index, 0, maxIndex);
    }

    public int getIndex() { return index; }
}
