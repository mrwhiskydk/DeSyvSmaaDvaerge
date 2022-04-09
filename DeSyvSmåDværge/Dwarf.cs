using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeSyvSmåDværge
{
    public enum DwarfAction
    {
        LastOnList,
        SummonDwarf,
        Disappear
    }

    internal class Dwarf
    {
        public readonly string name;
        private readonly string reactionLastOnList;
        private readonly string reactionSummonDwarf;
        private readonly string reactionDisappear;

        public Dwarf(string name, string reactionLastOnList, string reactionSummonDwarf, string reactionDisappear)
        {
            this.name = name;
            this.reactionLastOnList = reactionLastOnList;
            this.reactionSummonDwarf = reactionSummonDwarf;
            this.reactionDisappear = reactionDisappear;
        }

        //abstract public void UdførReaktion();
        public string ReactionLastOnList()
        {
            return $"{name} [LastOnList]: {reactionLastOnList}";
        }

        public string ReactionSummonDwarf(string dwarf)
        {
            return $"{name} [SummonDwarf]: " + String.Format(reactionSummonDwarf, dwarf);
        }

        public string ReactionDisappear()
        {
            return $"{name} [Disappear]: {reactionDisappear}";
        }
    }
}
