using NUnit.Framework;
using UnityEngine;

public class PauseController : MonoBehaviour
{
   public static bool isPaused { get; private set; } = false;

   public static void setPause(bool pause)
    {
        isPaused = pause;
        
    }
}
