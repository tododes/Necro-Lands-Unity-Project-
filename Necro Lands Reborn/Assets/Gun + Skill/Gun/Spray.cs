using UnityEngine;
using System.Collections;

public class Spray : MonoBehaviour {

    [SerializeField]
    protected ParticleSystem[] particle;
    public bool isActive;
    // Use this for initialization
    protected void Start()
    {
        isActive = false;
    }

    protected bool CheckIsActive()
    {
        foreach (ParticleSystem p in particle)
        {
            if (!p.isPlaying)
                return false;
        }
        return true;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        isActive = CheckIsActive();
        if (Input.GetMouseButton(0))
        {
            foreach(ParticleSystem p in particle)
                p.Play();
        }
        else
        {
            foreach (ParticleSystem p in particle)
                p.Stop();
        }
    }
}
