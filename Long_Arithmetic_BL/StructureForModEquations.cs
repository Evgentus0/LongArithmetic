using System;
using System.Collections.Generic;
using System.Text;

namespace Long_Arithmetic_BL
{
    public class StructureForModEquations
    {
        public int index;
        public Number value;
        public Number mod;
        public Number multipleAllValues;
        public Number findingNumber;
        public StructureForModEquations(int index, Number value, Number mod, Number multipleValues=null, Number finding=null)
        {
            this.index = index;
            this.value = value;
            this.mod = mod;
            multipleAllValues = multipleValues;
            findingNumber = finding;
        }
    }
}
