using System;
using UnityEngine;

namespace Buildings.Attachment.Bulb
{
    [CreateAssetMenu(menuName = "Moon Pioner/Light Bulb")]
    public class LightBulbColor : ScriptableObject
    {
        public LightBulbType Type { get => _type; }
        public Material Material { get => _material; }

        [SerializeField] private LightBulbType _type;
        [SerializeField] private Material _material;
    }
}
