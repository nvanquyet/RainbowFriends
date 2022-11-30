using Assets.Scripts.Interface;
using UnityEngine;
namespace Assets.Scripts.InputCharacter
{
    public class InputCtrl : MonoBehaviour, IInput
    {
        public Vector2 direction { get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); set => throw new System.NotImplementedException(); }
        public bool attack { get => Input.GetMouseButtonDown(0); set => throw new System.NotImplementedException(); }
    }
}
