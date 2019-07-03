using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Loading
{
    public class AudioNode
    {
        //Why do we use this???
        public string Name;
        public string AudioName;
        public AudioNode(){}
        public AudioNode(string name, string audioName)
        {
            Name = name;
            AudioName = audioName;
        }
    }
}
