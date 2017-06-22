using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TDictionary<TKey, TValue>
{
    [SerializeField] private List<TKey> keys;
    [SerializeField] private List<TValue> values;
    private int counter;

    public TDictionary(){
        keys = new List<TKey>();
        values = new List<TValue>();
        counter = 0;
    }

    public void Add(TKey k, TValue v){
        keys.Add(k);
        values.Add(v);
        counter++;
    }

    public TDictionary(TKey[] ks, TValue[] vs){
        keys = new List<TKey>(ks);
        values = new List<TValue>(vs);
    }

    public TValue ValueOf(TKey k){
        return values[keys.IndexOf(k)];
    }

    public TKey KeyOf(TValue v){
        return keys[values.IndexOf(v)];
    }

    public void Clear(){
        keys.Clear();
        values.Clear();
    }

    public void Remove(TKey key){
        int i = keys.IndexOf(key);
        keys.RemoveAt(i);
        values.RemoveAt(i);
    }

    public void Remove(TValue val){
        int i = values.IndexOf(val);
        keys.RemoveAt(i);
        values.RemoveAt(i);
    }

    public int count { get { return counter; } }
}
