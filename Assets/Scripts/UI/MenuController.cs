using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonAndDemons.UI
{
    public class MenuController : MonoBehaviour
    {
        public Vector2 HidePosition;
        public Vector2 ShowPosition;

        [SerializeField]
        private List<Menu> _menus = new List<Menu>();

        private Menu _currentMenu;

        private void Start()
        {
            SetStartMenusPositions();
        }

        public void EnableMenu(Menu menu)
        {
            _currentMenu.SetPosition(HidePosition, false, () => { _currentMenu = menu; _currentMenu.SetPosition(ShowPosition, false); });
        }

        private void SetStartMenusPositions()
        {
            foreach (Menu menu in _menus)
            {
                menu.gameObject.SetActive(true);
                menu.SetPosition(HidePosition, true);
            }

            _menus[0].gameObject.SetActive(true);
            _menus[0].SetPosition(ShowPosition, true);
            _currentMenu = _menus[0];
        }
    }
}