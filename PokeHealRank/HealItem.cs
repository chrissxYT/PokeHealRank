using System.Collections.Generic;

namespace PokeHealRank
{
    class HealItem
    {
        HealItem() { }

        public static HealItem New => new HealItem();

        public HealItem(string name, byte hp, ushort price)
        {
            this.name = name;
            this.hp = hp;
            this.price = price;
        }

        public string name;
        public byte hp;
        public ushort price;
        public double hpp => (double)((double)hp) / ((double)price);

        public override bool Equals(object obj) => obj is HealItem item && name == item.name && hp == item.hp && price == item.price && hpp == item.hpp;

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = -490350540 * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
                hashCode *= -1521134295;
                hashCode += hp.GetHashCode();
                hashCode = hashCode * -1521134295 + price.GetHashCode();
                hashCode = hashCode * -1521134295 + hpp.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() => string.Format("\"{0}\", HP: {1}, Price: {2}", name, hp, price);
    }
}
