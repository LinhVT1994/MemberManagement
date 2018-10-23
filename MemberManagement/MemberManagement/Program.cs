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
            Member member1 = new Member("Linh", "Vu", "vulinh.hust@gmail.com", "Saitama-shi Minami-ku Minamiurawa","01656994993");
            Member result = service.Register(member1);
            if (result==null)
            {
                Console.WriteLine("Has something error");
                Console.WriteLine(service.ErrorStatus);
            }
            else
            {
                Console.WriteLine("-->Hi: "+ result.GetFullName() +" \n-->Welcome to our service. \n-->The registering is success.");
            }
            Console.WriteLine("---------------      ---------------");
            Member member2 = new Member("Linh", "Vu", "vulinh.hust@gmail.com", "Saitama-shi Minami-ku Minamiurawa", "01656994993");
            result = service.Register(member2);
            if (result == null)
            {
                Console.WriteLine("-->Has something error");
                Console.WriteLine("-->" + service.ErrorStatus);
            }
            else
            {
                Console.WriteLine("-->Hi: " + result.GetFullName() + " \n-->Welcome to our service. \n-->The registering is success.");
            }
            Console.WriteLine("---------------      ---------------");
            Member member3 = new Member("Linh", "Nguyen", "tuanlinh@takeuchi-const.com", "Saitama-shi Minami-ku Minamiurawa", "01656994993");
            result = service.Register(member3);
            if (result == null)
            {
                Console.WriteLine("Has something error");
                Console.WriteLine(service.ErrorStatus);
            }
            else
            {
                Console.WriteLine("-->Hi: " + result.GetFullName() + " \n-->Welcome to our service. \n-->The registering is success.");
            }
            Console.Read();

        }
        public static void Execute()
        {

        }
    }
}
