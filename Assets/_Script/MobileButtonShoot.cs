using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileButtonShoot : MonoBehaviour
{
    private bool fireTouch = false;

    public static MobileButtonShoot mbs;
    private void Awake() {
        if (mbs == null)
        {
            mbs = this;
        }
        else if (mbs != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetFireTouch(bool _b)
    {
        fireTouch = _b;
    }
    public bool GetFireTouch()
    {
        return fireTouch;
    }
}
