using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08TodoGuiAli
{
    class Todo
    {
        String Task; // 1-100 characters, made up of uppercase and lowercase letters, digits, space, %_-(),./\ only
        int Difficulty; // 1-5, as slider
        DateTime DueDate; // year 1900-2100 both inclusive, use formatted field
        public EStatus Status; // define an enumeration - one of: Pending, Done, Delegated - matches the ComboBox in GUI
        public enum EStatus { Pending, Done, Delegated };
    }
}
