using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuOpen : MonoBehaviour
{
    public void OpenPauseMenu() {
        PauseMenu.Instance.PauseGame();
    }
}
