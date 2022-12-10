using UnityEngine;

namespace Assets.Scripts.Interface
{
    public interface IInput
    {
        //UseForPlayer
        Vector2 direction { get; set; }
        bool attack { get; set; }
    }
}
