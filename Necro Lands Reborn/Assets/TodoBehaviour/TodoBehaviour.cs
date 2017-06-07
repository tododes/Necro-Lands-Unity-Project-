using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TodoBehaviour : MonoBehaviour {

    public Vector3 pos
    {
        get { return transform.position; }
        set { pos = value; }
    }

    public Quaternion rot
    {
        get { return transform.rotation; }
        set { rot = value; }
    }

    public Vector3 losca
    {
        get { return transform.lossyScale; }
        set { losca = value; }
    }

    public Vector3 lcsca
    {
        get { return transform.localScale; }
        set { lcsca = value; }
    }

    public T Cp<T>() where T : Component
    {
        return GetComponent<T>();
    }

    public T Cp_C<T>() where T : Component
    {
        return GetComponentInChildren<T>();
    }

    public T Cp_P<T>() where T : Component
    {
        return GetComponentInParent<T>();
    }

    public Transform par
    {
        get{ return transform.parent; }
        set { par = value; }
    }

    public List<T> ListObj<T>() where T : Component
    {
        List<T> ListT = new List<T>();
        T[] ts = FindObjectsOfType<T>();
        for (int i = 0; i < ts.Length; i++)
        {
            ListT.Add(ts[i]);
        }
        return ListT;
    }

    public void t_a(Vector3 dir, float speed)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void r_a(Vector3 dir, float speed)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void En(MonoBehaviour comp)
    {
        if(!comp.enabled)
            comp.enabled = true;
    }

    public void Ds(MonoBehaviour comp)
    {
        if (comp.enabled)
            comp.enabled = false;
    }

    public void Ac(GameObject g)
    {
        g.SetActive(true);
    }

    public void DeAc(GameObject g)
    {
        g.SetActive(false);
    }

    public void Ac(MonoBehaviour g)
    {
        g.gameObject.SetActive(true);
    }

    public void DeAc(MonoBehaviour g)
    {
        g.gameObject.SetActive(false);
    }
}
