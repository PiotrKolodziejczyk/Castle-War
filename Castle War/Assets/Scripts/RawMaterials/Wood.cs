using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Wood
    {
        private static Wood m_oInstance = null;

        public static Wood GetWood
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new Wood();
                }
                return m_oInstance;
            }
        }

        
        public int Quantity { get => quantity; set => quantity = value; }

        private int quantity = 0;
    }
}
