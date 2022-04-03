using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeController : MonoBehaviour
{
    public float swipeThreshold = 50f;
    public float timeThreshold;

    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;

    private Vector2 fingerDown;
    private DateTime fingerDownTime;
    private Vector2 fingerUp;
    private DateTime fingerUpTime;

    private void Update()
    {
        if (!GameManager.instance._isWin)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.fingerDown = Input.mousePosition;
                this.fingerUp = Input.mousePosition;
                this.fingerDownTime = DateTime.Now;
            }
            if (Input.GetMouseButtonUp(0))
            {
                this.fingerDown = Input.mousePosition;
                this.fingerUpTime = DateTime.Now;
                this.CheckSwipe();
            }
        }
    }

    private void CheckSwipe()
    {

        float duration = (float)this.fingerUpTime.Subtract(this.fingerDownTime).TotalSeconds;
        if (duration > this.timeThreshold) return;
        float deltaX = this.fingerDown.x - this.fingerUp.x;
        float deltaY = fingerDown.y - fingerUp.y;
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if ((Mathf.Abs(deltaX) + 2) > this.swipeThreshold)
            {
                if (deltaX > 0)
                {
                    this.OnSwipeRight.Invoke();
                }
                else if (deltaX < 0)
                {
                    this.OnSwipeLeft.Invoke();
                }
            }
        }
        this.fingerUp = this.fingerDown;
    }
}
