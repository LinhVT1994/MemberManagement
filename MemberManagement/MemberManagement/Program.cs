using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            Member member1 = new Member(null, "Vu", "vulinh.hust@gmail.com", "Saitama-shi Minami-ku Minamiurawa","01656994993");
            service.Register(member1);
            Console.Read();

        }
        public static void Execute()
        {

        }
    }
}
