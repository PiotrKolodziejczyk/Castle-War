using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SavingData
{
    [Serializable]
    public class PlayerMaterialsData
    {
        public int woodQuantity;
        public int stoneQuantity;
        public int clayQuantity;

        public PlayerMaterialsData(IMaterials materials)
        {
            woodQuantity = materials.Materials.wood.quantity;
            stoneQuantity = materials.Materials.stone.quantity;
            clayQuantity = materials.Materials.clay.quantity;
        }
    }
}
