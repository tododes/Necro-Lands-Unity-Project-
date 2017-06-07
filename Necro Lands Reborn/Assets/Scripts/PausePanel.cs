using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : AreYouSurePanel {

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Trigger();
        base.Update();
        if (Index == 1 && rect.localScale.x >= desiredSize)
            Time.timeScale = 0f;
        else if (Index == 0 && rect.localScale.x > 0)
            Time.timeScale = 1f;
    }
}
