using UnityEngine;
using System.Collections;

public class WaterSpray : Spray {

    [SerializeField]
    private ParticleEmitter[] emitter;

    protected override void Update()
    {
        foreach (ParticleEmitter pe in emitter)
        {
            pe.emit = Input.GetMouseButton(0);
        }
    }
}
