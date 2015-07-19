using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    class Week
    {
        public int Monday = 0;
        public int Tues = 1;
        public int Wed = 2;
        public int Thur = 3;


    }

    enum Gender
    {
   Male= 2,Female=3
    

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(getGender().GetHashCode());

            Console.Read();

        }

        public static Gender getGender()
        {
            return Gender.Male;
        }
    }
}
