using UnityEngine;

namespace Assets.Scripts.Interface
{
    public interface IInput
    {
        Vector2 direction { get; set; }

        bool attack { get; set; }
    }
}
