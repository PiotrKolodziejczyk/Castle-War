using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Clay
    {
        private static Clay m_oInstance = null;

        public static Clay GetClay
        {
            get
            {
                if (m_oInstance == null)
                {
                    m_oInstance = new Clay();
                }
                return m_oInstance;
            }
        }
        private int quantity;
        public int Quantity { get => quantity; set => quantity=value; }
    }
}
