using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _menuUI.SetActive(!_menuUI.activeSelf);
        }
    }
}