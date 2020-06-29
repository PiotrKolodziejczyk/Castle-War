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
        public PlayerMaterialsData(MaterialsTake takeScript)
        {
            woodQuantity = takeScript.player.Materials.wood.quantity;
            stoneQuantity = takeScript.player.Materials.stone.quantity;
            clayQuantity = takeScript.player.Materials.clay.quantity;
        }
        public PlayerMaterialsData(VillageScript takeScript)
        {
            woodQuantity = takeScript.player.materials.wood.quantity;
            stoneQuantity = takeScript.player.materials.stone.quantity;
            clayQuantity = takeScript.player.materials.clay.quantity;
        }
    }
}
