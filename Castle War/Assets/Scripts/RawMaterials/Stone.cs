using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Stone
    {
        private static Stone m_oInstance = null;

        public static Stone GetStone
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new Stone();
                }
                return m_oInstance;
            }
        }

        
        public int Quantity { get => quantity; set => quantity = value; }

        private int quantity = 0;
    }
}
