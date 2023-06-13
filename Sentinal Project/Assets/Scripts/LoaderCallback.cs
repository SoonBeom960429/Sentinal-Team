using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUptade = true;

    private void Update()
    {
        if (isFirstUptade)
        {
            isFirstUptade = false;

            Loader.LoaderCallback();
        }
    }
}
