using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Buildings.Attachment.Bulb
{
    public class LightBulbColorFactory : MonoBehaviour
    {
        [SerializeField] private LightBulbColor[] _colors;

        public LightBulbColor GetColor(LightBulbType type)
        {
            IReadOnlyCollection<LightBulbColor> gettedColors = _colors.Where(x => x.Type == type).ToList().AsReadOnly();

            if (gettedColors.Count == 0)
                throw new ArgumentException($"Cant find Color of Type {type.ToString()}");

            return gettedColors.First();
        }
    }
}
