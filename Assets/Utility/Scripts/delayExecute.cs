using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {

    public class delayExecute : MonoBehaviour
    {
        public IEnumerator DelaytoFrame(int delayframe,Action action)
        {
            for(int i = 0;i < delayframe; i++)
            {
                Debug.Log(i);
                yield return null;
            }
            action();
        }

        public IEnumerator DelaytoSecond(int delaysecond,Action action)
        {
            yield return new WaitForSeconds(delaysecond);
            action();
        }

        public void test()
        {
            Debug.Log("test");
        }
    }
}
