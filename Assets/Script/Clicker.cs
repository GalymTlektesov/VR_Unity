using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;

public class Clicker : MonoBehaviour
{
    public bool Clicked()
    {
        #if (UNITY_ANDROID || UNITY_IOS)
        return GvrUnitySdkVersion.GVR_SDK_VERSION.Any();
#else
            return Input.anyKeyDown;
#endif
    }
}
