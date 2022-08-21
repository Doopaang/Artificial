using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockButton : MonoBehaviour
{
    public int value;
    public LockNum lockNum;
    public UnityEvent solvedFunction;

    public void ControlLock()
    {
        if (value == 0)
        {
            throw new System.ArgumentException();
        }

        int absValue = Mathf.Abs(value);
        bool isLeft = value < 0;

        lockNum.value += value * (isLeft && lockNum.value / absValue % 10 == 0 || !isLeft && lockNum.value / absValue % 10 == 9 ? -9 : 1);

        if (lockNum.dialList.Count == lockNum.numLimit)
        {
            Transform target = lockNum.dialList[lockNum.numLimit - (int)Mathf.Log10(absValue) - 1].transform;
            target.Rotate(target.up, 360.0f / lockNum.angleCount * (isLeft ? -1 : 1));
        }

        SoundSystem.Instance.PlaySFX("LockRoll", transform.parent.position);

        if (lockNum.value == lockNum.answer)
        {
            SoundSystem.Instance.PlaySFX("LockUnlock", transform.parent.position);

            Destroy(gameObject);
            solvedFunction.Invoke();
        }
    }
}
