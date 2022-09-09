using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easypartuturan.logic
{
    public enum BranchDirection { 
        TENGAH,
        ATAS,
        KANAN,
        BAWAH,
        KIRI
    }

    public class Tree
    {
        public string Name { get; set; }
        public List<Tree> Branch { get; set; }
        public BranchDirection Direction { get; set; }
    }
}
